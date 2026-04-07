using MaxAPI.Objects;
using System;
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
public class MaxWebClient : MaxClient
{
    protected override bool IsConnected => webSocket != null && webSocket.State == WebSocketState.Open;

    private ClientWebSocket? webSocket = new();
    private readonly Uri uri = new("wss://ws-api.oneme.ru/websocket");

    public static async Task<MaxWebClient> SessionLoginAsync(string token, UserAgent? userAgent = null, MaxOptions? options = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(token, nameof(token));

        MaxWebClient client = new()
        {
            options = options ?? new(),
            Token = token,
            userAgent = userAgent ?? UserAgent.DefaultWeb
        };

        await client.SessionInitAsync(cancellationToken);

        var loginResponse = await client.LoginAsync(token);

        client.Config = loginResponse.config;
        client.Profile = loginResponse.profile;
        client.chats = loginResponse.chats.ToDictionary(cb => cb.Id);
        client.contacts = loginResponse.contacts.ToDictionary(c => c.id);

        return client;
    }

    protected override async Task SendAsync(MaxMessage message, CancellationToken cancellationToken = default)
    {
        var jsonMessage = JsonSerializer.Serialize(message);
        var messageBytes = Encoding.UTF8.GetBytes(jsonMessage);
        await webSocket!.SendAsync(messageBytes.AsMemory(), WebSocketMessageType.Text, true, cancellationToken);
    }

    protected override async Task<MaxMessage> ReceiveAsync(CancellationToken cancellationToken = default)
    {
        using MemoryStream memoryStream = new();
        Memory<byte> buffer = new byte[options.ReceiveBufferSize];
        ValueWebSocketReceiveResult result;
        do
        {
            result = await webSocket!.ReceiveAsync(buffer, cancellationToken);
            if (result.Count > 0)
                memoryStream.Write(buffer.Span[..result.Count]);
        } while (!result.EndOfMessage);

        if (result.MessageType == WebSocketMessageType.Close)
        {
            string closeStatusDescription = webSocket.CloseStatusDescription;
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
            await DisconnectAsync(cancellationToken);
            throw new WebSocketException("Server closed connection. Reason: " + closeStatusDescription);
        }

        var jsonMessage = Encoding.UTF8.GetString(memoryStream.ToArray());
        return JsonSerializer.Deserialize<MaxMessage>(jsonMessage);
    }

    protected override async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        webSocket = new ClientWebSocket();

        webSocket.Options.SetRequestHeader("Origin", "https://web.max.ru");
        await webSocket.ConnectAsync(uri, cancellationToken);
    }

    protected override async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        if (IsConnected)
            await webSocket!.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
        webSocket?.Dispose();
        webSocket = null;
    }

    public override void Dispose()
    {
        if (webSocket != null)
            SessionExitAsync().GetAwaiter().GetResult();
        base.Dispose();
    }
}