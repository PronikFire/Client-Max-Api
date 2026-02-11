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

    public long receiveTimeout = 5000;
    public long receiveCheckPeriod = 30;
    public bool interactive = true;
    public readonly string token;
    public event Action<MaxMessage>? onServerRequest;

    private ClientWebSocket? webSocket = new();
    private long lastSendTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    private int seq = 0;
    private CancellationTokenSource? loopCTS;
    private Task? reconnectTask;
    private readonly ConcurrentDictionary<ushort, TaskCompletionSource<MaxMessage>> pendingResponses = new();
    private readonly Uri serverUri = new("wss://ws-api.oneme.ru/websocket");
    private bool disposed = false;

    public static async Task<(MaxWebClient, MsgLogin.Response)> Connect(string token, WebUserAgent userAgent, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(token, nameof(token));

        MaxWebClient client = new(token) { UserAgent = userAgent };

        var response = await client.ConnectAsync(cancellationToken).ConfigureAwait(false);

        return (client, response);
    }

    public async Task<MaxMessage> SendAsync(ushort opcode, object? payload, CancellationToken cancellationToken = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client is not connected.");

        reconnectTask?.Wait(cancellationToken);

        if (this.seq == ushort.MaxValue)
        {
            var newTask = Task.Run(async () =>
            {
                var tasks = pendingResponses.Values.Select(p => p.Task).ToArray();
                if (tasks.Length > 0)
                    await Task.WhenAll(tasks).ConfigureAwait(false);

                await DisconnectAsync().ConfigureAwait(false);
                await ConnectAsync().ConfigureAwait(false);
            }, CancellationToken.None);

            Interlocked.CompareExchange(ref reconnectTask, newTask, null);

            reconnectTask.Wait(cancellationToken);
        }

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

    private MaxWebClient(string token)
    {
        this.token = token ?? throw new ArgumentNullException(nameof(token));
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

    private async Task<MsgLogin.Response> ConnectAsync(CancellationToken cancellationToken = default)
    {
        if (IsConnected)
            throw new InvalidOperationException("Client was already connected.");

        seq = 0;
        webSocket = new ClientWebSocket();

        // Необходимый заголовок для сервера
        webSocket.Options.SetRequestHeader("Origin", "https://web.max.ru");
        await webSocket.ConnectAsync(serverUri, cancellationToken).ConfigureAwait(false);

        loopCTS = new CancellationTokenSource();
        _ = Task.Run(() => ReceiveLoop(loopCTS!.Token), CancellationToken.None);
        _ = Task.Run(() => KeepAliveLoop(loopCTS.Token), CancellationToken.None);

        var clientInfoResponse = await SendAsync(MsgSetClientInfo.OPCODE, new MsgSetClientInfo.Request(UserAgent, Guid.NewGuid()), cancellationToken);
        MaxException.ThrowIfError(clientInfoResponse);

        var loginResponse = await SendAsync(MsgLogin.OPCODE, new MsgLogin.Request(token), cancellationToken);
        MaxException.ThrowIfError(loginResponse);
        return loginResponse.JsonSerializePayload<MsgLogin.Response>();
    }

    private async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        if (!IsConnected)
            return;

        await loopCTS!.CancelAsync().ConfigureAwait(false);
        loopCTS.Dispose();

        foreach (var kv in pendingResponses)
            kv.Value.SetCanceled();
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
                await SendAsync(MsgInteractivePing.OPCODE, new MsgInteractivePing.Request(interactive), cancellationToken).ConfigureAwait(false);
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
                    onServerRequest?.Invoke(message);
                    break;
                default:
                    pendingResponses[message.seq].SetResult(message);
                    break;
            }
        }
    }

    public void Dispose()
    {
        if (IsConnected)
            DisconnectAsync().Wait();

        GC.SuppressFinalize(this);
    }

    ~MaxWebClient()
    {
        Dispose();
    }
}