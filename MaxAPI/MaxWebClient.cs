using System;
using System.IO;
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
    public bool IsConnected => webSocket?.State == WebSocketState.Open;
    public int ReceiveBufferSize { get; init; } = 1024;

    private ClientWebSocket? webSocket = new();

    public async Task ConnectAsync(CancellationToken ct = default)
    {
        if (IsConnected)
            throw new InvalidOperationException("Client is already connected.");

        webSocket?.Dispose();
        webSocket = new ClientWebSocket();

        // Необходимый заголовок для сервера
        webSocket.Options.SetRequestHeader("Origin", "https://web.max.ru");
        await webSocket.ConnectAsync(new Uri("wss://ws-api.oneme.ru/websocket"), ct).ConfigureAwait(false);
    }

    public async Task<MaxMessage> ReceiveAsync(CancellationToken ct = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client is not connected.");

        using MemoryStream binaryStream = new();
        Memory<byte> buffer = new byte[ReceiveBufferSize];
        ValueWebSocketReceiveResult result;
        do
        { 
            result = await webSocket!.ReceiveAsync(buffer, ct);
            binaryStream.Write(buffer.Span[..result.Count]);
        } while (!result.EndOfMessage);

        if (result.MessageType == WebSocketMessageType.Close)
        {
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, ct);
            throw new WebSocketException("Server closed connection. Reason: " + webSocket.CloseStatusDescription);
        }

        var jsonMessage = Encoding.UTF8.GetString(binaryStream.ToArray());
        return JsonSerializer.Deserialize<MaxMessage>(jsonMessage);
    }

    public async Task SendAsync(MaxMessage message, CancellationToken ct = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client is not connected.");

        var jsonMessage = JsonSerializer.Serialize(message);
        var messageBytes = Encoding.UTF8.GetBytes(jsonMessage);
        await webSocket!.SendAsync(messageBytes, WebSocketMessageType.Text, true, ct);
    }

    public async Task DisconnectAsync(CancellationToken ct = default)
    {
        if (!IsConnected)
            throw new InvalidOperationException("Client already isn't connected.");

        await webSocket!.CloseAsync(WebSocketCloseStatus.NormalClosure, null, ct);
        webSocket.Dispose();
        webSocket = null;
    }
    public void Dispose()
    {
        if (IsConnected)
            DisconnectAsync().Wait();
        GC.SuppressFinalize(this);
    }
}