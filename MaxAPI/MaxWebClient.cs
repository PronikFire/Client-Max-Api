using MaxAPI.MaxMessages;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MaxAPI;

/// <summary>
/// Provides a client for connecting to, sending, and receiving messages from a remote server using the WebSocket
/// protocol.
/// </summary>
public class MaxWebClient : IDisposable
{
    private bool IsConnected => webSocket?.State == WebSocketState.Open;
    public int ReceiveBufferSize { get; init; } = 1024;
    public WebUserAgent UserAgent { get; init; } = new WebUserAgent();
    public long KeepAlivePeriod { get; init; } = 30000;
    public Config? Config { get; private set; }

    public long receiveTimeout = 5000;
    public long receiveCheckPeriod = 30;
    public bool interactive = true;
    public readonly string token;
    public event NewMessageEventHandler? OnNewMessage;

    private ClientWebSocket? webSocket = new();
    private long lastSendTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    private int seq = 0;
    private CancellationTokenSource? loopCTS;
    private Task? reconnectTask;
    private readonly ConcurrentDictionary<ushort, TaskCompletionSource<MaxMessage>> pendingResponses = new();
    private readonly Uri serverUri = new("wss://ws-api.oneme.ru/websocket");

    public static async Task<(MaxWebClient, MsgLogin.Response)> Connect(string token, WebUserAgent userAgent, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(token, nameof(token));

        MaxWebClient client = new(token) { UserAgent = userAgent };

        await client.ConnectAsync(cancellationToken).ConfigureAwait(false);

        var jsonLoginResponse = await client.SendAndWaitAsync(MsgLogin.OPCODE, new MsgLogin.Request(token), cancellationToken);
        MaxException.ThrowIfError(jsonLoginResponse);
        var loginResponse = jsonLoginResponse.JsonDeserializePayload<MsgLogin.Response>();

        client.Config = loginResponse.config;

        return (client, loginResponse);
    }

    public async Task<MaxMessage> CallAsync(ushort opcode, object? payload, CancellationToken cancellationToken = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client is not connected.");

        reconnectTask?.Wait(cancellationToken);

        if (seq == ushort.MaxValue)
        {
            var newTask = Task.Run(async () =>
            {
                var tasks = pendingResponses.Values.Select(p => p.Task).ToArray();
                if (tasks.Length > 0)
                    await Task.WhenAll(tasks).ConfigureAwait(false);

                await DisconnectAsync().ConfigureAwait(false);

                await ConnectAsync().ConfigureAwait(false);

                var loginResponse = await SendAndWaitAsync(MsgLogin.OPCODE, new MsgLogin.Request(token) { configHash = Config!.hash }, cancellationToken);
                MaxException.ThrowIfError(loginResponse);
            }, CancellationToken.None);

            _ = Interlocked.CompareExchange(ref reconnectTask, newTask, null);

            reconnectTask.Wait(cancellationToken);
        }

        return await SendAndWaitAsync(opcode, payload, cancellationToken);
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

        try
        {
            await SendAsync(message, cancellationToken).ConfigureAwait(false);

            using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            var delayTask = Task.Delay(TimeSpan.FromMilliseconds(receiveTimeout), timeoutCts.Token);
            var completed = await Task.WhenAny(tcs.Task, delayTask).ConfigureAwait(false);
            if (completed == tcs.Task)
            {
                timeoutCts.Cancel();
                return await tcs.Task.ConfigureAwait(false);
            }

            pendingResponses.TryRemove(seq, out _);
            throw new TimeoutException($"Timeout waiting for response seq={seq}.");
        }
        finally
        {
            pendingResponses.TryRemove(seq, out _);
        }
    }

    private async Task SendAsync(MaxMessage message, CancellationToken cancellationToken = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client is not connected.");

        var jsonMessage = JsonSerializer.Serialize(message);
        var messageBytes = Encoding.UTF8.GetBytes(jsonMessage);
        await webSocket!.SendAsync(messageBytes, WebSocketMessageType.Text, true, cancellationToken);

        Interlocked.Exchange(ref lastSendTime, DateTimeOffset.Now.ToUnixTimeMilliseconds());
    }

    private async Task<MaxMessage> ReceiveAsync(CancellationToken cancellationToken = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client is not connected.");

        using MemoryStream memoryStream = new();
        Memory<byte> buffer = new byte[ReceiveBufferSize];
        ValueWebSocketReceiveResult result;
        do
        {
            result = await webSocket!.ReceiveAsync(buffer, cancellationToken);
            if (result.Count > 0)
                memoryStream.Write(buffer.Span[..result.Count]);
        } while (!result.EndOfMessage);

        if (result.MessageType == WebSocketMessageType.Close)
        {
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken).ConfigureAwait(false);
            throw new WebSocketException("Server closed connection. Reason: " + webSocket.CloseStatusDescription);
        }

        var jsonMessage = Encoding.UTF8.GetString(memoryStream.ToArray());
        return JsonSerializer.Deserialize<MaxMessage>(jsonMessage);
    }

    private async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        seq = 0;
        webSocket = new ClientWebSocket();

        // Необходимый заголовок для сервера
        webSocket.Options.SetRequestHeader("Origin", "https://web.max.ru");
        await webSocket.ConnectAsync(serverUri, cancellationToken).ConfigureAwait(false);

        loopCTS = new CancellationTokenSource();
        _ = Task.Run(() => ReceiveLoop(loopCTS.Token), cancellationToken);
        _ = Task.Run(() => KeepAliveLoop(loopCTS.Token), cancellationToken);

        var clientInfoResponse = await SendAndWaitAsync(MsgSetClientInfo.OPCODE, new MsgSetClientInfo.Request(UserAgent, Guid.NewGuid()), cancellationToken);
        MaxException.ThrowIfError(clientInfoResponse);
    }

    private async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        await loopCTS!.CancelAsync().ConfigureAwait(false);
        loopCTS.Dispose();

        foreach (var kv in pendingResponses)
            kv.Value.SetCanceled(cancellationToken);
        pendingResponses.Clear();

        await webSocket!.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
        webSocket.Dispose();
        webSocket = null;
    }

    private async Task KeepAliveLoop(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var next = lastSendTime + KeepAlivePeriod;
            var delay = next - DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (delay <= 0)
            {
                await CallAsync(MsgInteractivePing.OPCODE, new MsgInteractivePing.Request(interactive), cancellationToken).ConfigureAwait(false);
                continue;
            }

            await Task.Delay((int)delay, CancellationToken.None).ConfigureAwait(false);
        }
    }

    private async Task ReceiveLoop(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var message = await ReceiveAsync(cancellationToken);
            switch (message.cmd)
            {
                case CmdType.Request:
                    await ServerRequestHandler(message);
                    break;
                default:
                    // Если клиент получает неожиданный seq. Можно поставить throw
                    if (!pendingResponses.ContainsKey(message.seq))
                        continue;

                    pendingResponses[message.seq].SetResult(message);
                    break;
            }
        }
    }

    private async Task ServerRequestHandler(MaxMessage requestMessage)
    {
        switch (requestMessage.opcode)
        {
            case MsgNewMessageEvent.OPCODE:
                var request = requestMessage.JsonDeserializePayload<MsgNewMessageEvent.Request>();

                OnNewMessage?.Invoke(this, request);

                var response = new MsgNewMessageEvent.Response()
                {
                    chatId = request.chatId,
                    messageId = request.message.id
                };

                MaxMessage responseMessage = new()
                {
                    opcode = requestMessage.opcode,
                    seq = requestMessage.seq,
                    cmd = CmdType.Response,
                    payload = response
                };
                await SendAsync(responseMessage);
                break;
        }
    }

    public void Dispose()
    {
        if (IsConnected)
            DisconnectAsync().Wait();
        GC.SuppressFinalize(this);
    }

    private MaxWebClient(string token)
    {
        this.token = token ?? throw new ArgumentNullException(nameof(token));
    }

    ~MaxWebClient()
    {
        Dispose();
    }

    public delegate void NewMessageEventHandler(object sender, MsgNewMessageEvent.Request messageInfo);
}