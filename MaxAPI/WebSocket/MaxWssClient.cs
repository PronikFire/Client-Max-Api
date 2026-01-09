using MaxAPI.WebSocket.JsonExtensions;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class MaxWssClient
{
    public bool IsConnected => isConnected && webSocket.State == WebSocketState.Open;
    public ushort Seq { get; private set; } = 0;

    public readonly JsonSerializerOptions jsonOptions = new()
    {
        Converters =
        {
            new ContactConverter()
        }
    };

    private readonly ClientWebSocket webSocket = new();
    private bool isConnected = false;

    public async Task ConnectAsync(CancellationToken ct = default)
    {
        if (IsConnected)
            throw new InvalidOperationException("Client is already connected.");

        // Если не поставить этот заголовок, то будет выдавать ошибку
        webSocket.Options.SetRequestHeader("Origin", "https://web.max.ru");
        await webSocket.ConnectAsync(new Uri("wss://ws-api.oneme.ru/websocket"), ct);
        isConnected = true;
    }

    public async Task<MaxMessage> ReceiveAsync(CancellationToken ct = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client is not connected.");

        string jsonMessage = string.Empty;
        Memory<byte> buffer = new byte[1024];
        ValueWebSocketReceiveResult result;
        do
        {
            result = await webSocket.ReceiveAsync(buffer, ct);
            jsonMessage += Encoding.UTF8.GetString(buffer.Span[..result.Count]);

        } while (!result.EndOfMessage);

        return JsonSerializer.Deserialize<MaxMessage>(jsonMessage, jsonOptions);
    }

    public async Task SendAsync(ushort opcode, object? payload, CancellationToken ct = default)
    {
        if (Seq == ushort.MaxValue)
            throw new Exception("Seq reached its limit. Reconnection required.");

        var maxMessage = new MaxMessage()
        {
            seq = Seq++,
            opcode = opcode,
            payload = payload,
        };

        await SendAsync(maxMessage, ct);
    }

    public async Task SendAsync(MaxMessage message, CancellationToken ct = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client is not connected.");

        var jsonMessage = JsonSerializer.Serialize(message, jsonOptions);
        var messageBytes = Encoding.UTF8.GetBytes(jsonMessage);
        await webSocket.SendAsync(messageBytes, WebSocketMessageType.Text, true, ct);
    }

    public async Task Disconnect(CancellationToken ct = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client already isn't connected.");

        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, ct);
        isConnected = false;
    }

    ~MaxWssClient()
    {
        webSocket?.Dispose();
    }
}