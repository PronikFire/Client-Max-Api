using MaxAPI.Objects;
using MaxAPI.Operations;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaxAPI;

/// <summary>
/// Provides a client for connecting to, sending, and receiving messages from a remote server using the WebSocket
/// protocol.
/// </summary>
public abstract class MaxClient : IDisposable
{
    public Config Config { get; protected set; }
    public long UserId { get; protected set; }
    public string Token { get; protected set; }
    public Objects.Profile Profile { get; protected set; }
    public ReadOnlyDictionary<long, Chat> Chats => chats.AsReadOnly();
    public ReadOnlyDictionary<long, Contact> Contacts => contacts.AsReadOnly();
    public DateTimeOffset LastLogin { get; private set; }

    public bool interactive = true;
    public event NewMessageEventHandler? OnNewMessage;

    protected abstract bool IsConnected { get; }

    protected MaxOptions options;
    protected Dictionary<long, Chat> chats;
    protected Dictionary<long, Contact> contacts;
    protected UserAgent userAgent;

    private long lastSendTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    private int seq = 0;
    private CancellationTokenSource? loopCTS;
    private Task? reconnectTask = null;
    private readonly ConcurrentDictionary<ushort, TaskCompletionSource<MaxMessage>> pendingResponses = new();

    #region Public Calls
    public async Task<FoldersGet.Response> GetFoldersAsync(int folderSync = 0)
    {
        FoldersGet.Request request = new()
        {
            folderSync = folderSync
        };
        var maxResponse = await CallAsync(FoldersGet.OPCODE, request);
        MaxException.ThrowIfError(maxResponse);
        var response = maxResponse.DeserializePayload<FoldersGet.Response>();
        return response;
    }

    /// <summary>
    /// Get messages in a specific period in a chat
    /// </summary>
    /// <param name="chatId">Chat id from which messages will be collected</param>
    /// <param name="from">The point in time around which messages will be collected</param>
    /// <param name="forward">Number of messages after the time point.</param>
    /// <param name="backward">Number of messages before the time point.</param>
    /// <param name="getMessages"></param>
    /// <returns>Returns an array of messages</returns>
    public async Task<Message[]> GetChatHistoryAsync(
        long chatId,
        DateTimeOffset from,
        int forward = 30,
        int backward = 30,
        bool getMessages = true)
    {
        ChatHistory.Request request = new()
        {
            chatId = chatId,
            from = from.ToUnixTimeMilliseconds(),
            forward = forward,
            backward = backward,
            getMessages = getMessages
        };
        var maxResponse = await CallAsync(ChatHistory.OPCODE, request);
        MaxException.ThrowIfError(maxResponse);
        var response = maxResponse.DeserializePayload<ChatHistory.Response>();
        return response.messages;
    }

    public async Task<Chat[]> GetChatsInfoAsync(long[] ids)
    {
        ChatInfo.Request request = new()
        {
            chatIds = ids
        };
        var maxResponse = await CallAsync(ChatInfo.OPCODE, request);
        MaxException.ThrowIfError(maxResponse);
        var response = maxResponse.DeserializePayload<ChatInfo.Response>();
        return response.chats;
    }

    public async Task<Contact[]> GetContactsInfoAsync(long[] ids)
    {
        ContactInfo.Request request = new()
        {
            contactIds = ids
        };
        var maxResponse = await CallAsync(ContactInfo.OPCODE, request);
        MaxException.ThrowIfError(maxResponse);
        var response = maxResponse.DeserializePayload<ContactInfo.Response>();
        return response.contacts;
    }

    public async Task<Session[]> GetSessionsInfoAsync()
    {
        var maxResponse = await CallAsync(SessionsInfo.OPCODE, new SessionsInfo.Request());
        MaxException.ThrowIfError(maxResponse);
        var response = maxResponse.DeserializePayload<SessionsInfo.Response>();
        return response.sessions;
    }

    public async Task MessageSendAsync(
        long chatId,
        Message message,
        bool notify = true)
    {
        message.Cid = -DateTimeOffset.Now.ToUnixTimeMilliseconds();
        MsgSend.Request request = new(chatId, message)
        {
            notify = notify
        };
        var maxResponse = await CallAsync(MsgSend.OPCODE, request);
        MaxException.ThrowIfError(maxResponse);
    }

    public async Task SetProfileAsync(
        string firstName = "",
        string lastName = "",
        string? description = null
        )
    {
        Operations.Profile.Request request = new()
        {
            firstName = firstName,
            lastName = lastName,
            description = description
        };
        var maxResponse = await CallAsync(Operations.Profile.OPCODE, request);
        MaxException.ThrowIfError(maxResponse);
    }
    #endregion

    public async Task<MaxMessage> CallAsync(ushort opcode, object? payload, CancellationToken cancellationToken = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client doesn't connected.");

        reconnectTask?.Wait(cancellationToken);

        if (seq == ushort.MaxValue)
        {
            var newTask = Task.Run(async () => ReLoginAsync(), cancellationToken);

            _ = Interlocked.CompareExchange(ref reconnectTask, newTask, null);

            reconnectTask.Wait(cancellationToken);
        }

        return await SendAndWaitAsync(opcode, payload, cancellationToken);
    }

    #region Abstractions
    protected abstract Task SendAsync(MaxMessage message, CancellationToken cancellationToken = default);
    protected abstract Task<MaxMessage> ReceiveAsync(CancellationToken cancellationToken = default);
    protected abstract Task ConnectAsync(CancellationToken cancellationToken = default);
    protected abstract Task DisconnectAsync(CancellationToken cancellationToken = default);
    #endregion

    #region Internal
    protected async Task<Login.Response> LoginAsync(
        string token,
        bool interactive = true,
        int chatsCount = 40,
        long lastLogin = default,
        long chatsSync = 0,
        long presenceSync = -1,
        long draftsSync = 0,
        string? configHash = null,
        UserAgent? userAgent = null
        )
    {
        Login.Request request = new()
        {
            interactive = interactive,
            token = token,
            chatsCount = chatsCount,
            lastLogin = lastLogin,
            chatsSync = chatsSync,
            presenceSync = presenceSync,
            draftsSync = draftsSync,
            configHash = configHash,
            userAgent = userAgent

        };
        var maxResponse = await CallAsync(Operations.Login.OPCODE, request);
        MaxException.ThrowIfError(maxResponse);
        var response = maxResponse.DeserializePayload<Login.Response>();
        return response;
    }

    private async Task ReLoginAsync(CancellationToken cancellationToken = default)
    {
        await ReconnectAsync(cancellationToken);

        var loginResponse = await LoginAsync(Token, interactive, configHash: Config.hash, lastLogin: LastLogin.ToUnixTimeMilliseconds());
        Config.hash = loginResponse.config.hash;
        Profile = loginResponse.profile;
        foreach (var chatBase in loginResponse.chats)
            chats[chatBase.Id] = chatBase;
    }

    private async Task<MaxMessage> SendAndWaitAsync(ushort opcode, object? payload, CancellationToken cancellationToken = default)
    {
        ushort seq = (ushort)Interlocked.Increment(ref this.seq);

        var message = new MaxMessage()
        {
            opcode = opcode,
            seq = seq,
            payload = payload
        };

        var tcs = new TaskCompletionSource<MaxMessage>(TaskCreationOptions.RunContinuationsAsynchronously);

        if (!pendingResponses.TryAdd(seq, tcs))
            throw new InvalidOperationException("Failed to register pending response.");

        await SendMaxMessageAsync(message, cancellationToken);

        using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var delayTask = Task.Delay(TimeSpan.FromMilliseconds(options.ReceiveTimeout), timeoutCts.Token);
        var completed = await Task.WhenAny(tcs.Task, delayTask);
        pendingResponses.TryRemove(seq, out _);
        timeoutCts.Cancel();
        if (completed == delayTask)
        {
            throw new TimeoutException($"Timeout waiting for response seq={seq}.");
        }
        return await tcs.Task;
    }

    private async Task SendMaxMessageAsync(MaxMessage message, CancellationToken cancellationToken = default)
    {
        await SendAsync(message, cancellationToken);
        Interlocked.Exchange(ref lastSendTime, DateTimeOffset.Now.ToUnixTimeMilliseconds());
    }

    private async Task ReconnectAsync(CancellationToken cancellationToken = default)
    {
        var tasks = pendingResponses.Values.Select(p => p.Task).ToArray();
        if (tasks.Length > 0)
            await Task.WhenAll(tasks);

        await SessionExitAsync(cancellationToken);

        await SessionInitAsync(cancellationToken);
    }

    protected async Task SessionInitAsync(CancellationToken cancellationToken = default)
    {
        await ConnectAsync(cancellationToken);

        loopCTS = new CancellationTokenSource();
        _ = Task.Run(() => ReceiveLoop(loopCTS.Token), cancellationToken);
        _ = Task.Run(() => KeepAliveLoop(loopCTS.Token), cancellationToken);

        var clientInfoResponse = await SendAndWaitAsync(SessionInit.OPCODE, new SessionInit.Request(userAgent, Guid.NewGuid()), cancellationToken);
        MaxException.ThrowIfError(clientInfoResponse);
    }

    protected async Task SessionExitAsync(CancellationToken cancellationToken = default)
    {
        if (loopCTS != null)
        {
            await loopCTS!.CancelAsync();
            loopCTS.Dispose();
            loopCTS = null;
        }

        foreach (var kv in pendingResponses)
            kv.Value.SetCanceled(CancellationToken.None);
        pendingResponses.Clear();

        await DisconnectAsync(cancellationToken);
        seq = 0;
    }

    private async Task KeepAliveLoop(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested && IsConnected)
        {
            var next = lastSendTime + options.KeepAlivePeriod;
            var delay = next - DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (delay <= 0)
            {
                try
                {
                    await CallAsync(Ping.OPCODE, new Ping.Request(interactive), cancellationToken);
                }
                catch
                {
                    return;
                }
                continue;
            }

            await Task.Delay((int)delay, CancellationToken.None);
        }
    }

    private async Task ReceiveLoop(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested && IsConnected)
        {
            MaxMessage message;
            try
            {
                message = await ReceiveAsync(cancellationToken);

                switch (message.cmd)
                {
                    case CmdType.Request:
                        _ = Task.Run(() => ServerRequestHandler(message), cancellationToken);
                        break;
                    default:
                        if (!pendingResponses.TryGetValue(message.seq, out var val))
                            continue;

                        val.SetResult(message);
                        break;
                }
            }
            catch
            {
                return;
            }
        }
    }

    private async Task ServerRequestHandler(MaxMessage requestMessage)
    {
        switch (requestMessage.opcode)
        {
            case NotifMessage.OPCODE:
                {
                    var request = requestMessage.DeserializePayload<NotifMessage.Request>();

                    if (request.chat != null)
                        chats.Add(request.chatId, request.chat);
                    else if (chats.ContainsKey(request.chatId))
                    {
                        Chat chat = (await GetChatsInfoAsync([request.chatId]))[0];
                        chats[request.chatId] = chat;
                    }
                    else
                    {
                        Chat chat = (await GetChatsInfoAsync([request.chatId]))[0];
                        chats.Add(request.chatId, chat);
                    }

                    try
                    {
                        OnNewMessage?.Invoke(this, request);
                    }
                    catch
                    {

                    }

                    var response = new NotifMessage.Response()
                    {
                        chatId = request.chatId,
                        messageId = request.message.Id
                    };

                    MaxMessage responseMessage = new()
                    {
                        opcode = requestMessage.opcode,
                        seq = requestMessage.seq,
                        cmd = CmdType.Response,
                        payload = response
                    };
                    await SendMaxMessageAsync(responseMessage);
                    break;
                }
            case NotifContact.OPCODE:
                {
                    var request = requestMessage.DeserializePayload<NotifContact.Request>();

                    contacts.Add(request.contact.id, request.contact);
                    break;
                }
        }
    }
    #endregion

    public virtual void Dispose()
    {
        chats.Clear();
        GC.SuppressFinalize(this);
    }

    protected MaxClient() { }

    ~MaxClient()
    {
        Dispose();
    }

    public delegate void NewMessageEventHandler(object sender, NotifMessage.Request messageInfo);
}
