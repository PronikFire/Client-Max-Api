using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class WssMaxClient
{
    private readonly ClientWebSocket webSocket = new();
    private const string MAX_WS_URL = "wss://ws-api.oneme.ru/websocket";
    protected ushort seq = 0;
    private readonly JsonSerializerOptions jsonOptions = new()
    {
        IncludeFields = true
    };

    public WssMaxClient()
    {
        // Если не поставить этот заголовок, то будет выдавать ошибку
        webSocket.Options.SetRequestHeader("Origin", "https://web.max.ru");
        webSocket.ConnectAsync(new Uri(MAX_WS_URL), CancellationToken.None).Wait();
    }

    public async Task SendAsync(WssMaxMessage message, bool useInternalSeq = true)
    {
        if (useInternalSeq)
            message.seq = seq++;

        var jsonMessage = JsonSerializer.Serialize(message, jsonOptions);
        var messageBytes = Encoding.UTF8.GetBytes(jsonMessage);
        await webSocket.SendAsync(messageBytes, WebSocketMessageType.Text, true, CancellationToken.None);
    }
     
    public async Task<WssMaxMessage> ReceiveAsync(int bufferSize = 1024)
    {
        string jsonMessage = string.Empty;
        Memory<byte> buffer = new byte[bufferSize];
        ValueWebSocketReceiveResult result;
        do
        {
            result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
            jsonMessage += Encoding.UTF8.GetString(buffer.Span[..result.Count]);

        } while (!result.EndOfMessage);
        return JsonSerializer.Deserialize<WssMaxMessage>(jsonMessage, jsonOptions);
    }
}
