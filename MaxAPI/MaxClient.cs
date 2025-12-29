using MsgPack;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MaxAPI;

public class MaxClient
{
    public bool InteractivePing { get; set; } = true;

    private TcpClient tcpClient = new(MAX_HOST, 443);
    private Stream networkStream;
    private SslStream sslStream;
    private ushort seq = 0;

    //Я конечно понимаю что это "Beta", но всё же...
    //Даже в бету можно было бы поставить нормальный хост
    //При всём этом у них есть домен api.max.ru XD
    private const string MAX_HOST = "api.oneme.ru";

    public MaxClient()
    {
        networkStream = tcpClient.GetStream();
        //SSL для TCP\Tls
        sslStream = new SslStream(networkStream);
        sslStream.AuthenticateAsClient(MAX_HOST);
    }

    public async Task SendAsync(MaxMessage message, bool useInternalId = true)
    {
        Memory<byte> memory = new byte[10 + message.payload.Length];
        var buffer = memory.Span;
        buffer[0] = 0x0B;
        buffer[1] = (byte)message.cmd;
        if (useInternalId)
            BinaryPrimitives.WriteUInt16BigEndian(buffer[2..4], seq++);
        else
            BinaryPrimitives.WriteUInt16BigEndian(buffer[2..4], message.seq);
        BinaryPrimitives.WriteUInt16BigEndian(buffer[4..6], message.opcode);
        buffer[6] = message.countMetadata;
        buffer[7] = (byte)(message.payload.Length >> 16);
        buffer[8] = (byte)(message.payload.Length >> 8);
        buffer[9] = (byte)message.payload.Length;
        message.payload.CopyTo(buffer[10..]);

        await sslStream.WriteAsync(memory);
    }

    public async Task<MaxMessage> ReceiveAsync()
    {
        Memory<byte> buffer = new byte[10];
        do
        {
            await sslStream.ReadExactlyAsync(buffer);
        } 
        while (buffer.Span[0] != 0xB);


        MaxMessage instance = new()
        {
            cmd = (MaxCmdType)buffer.Span[1],
            seq = BinaryPrimitives.ReadUInt16BigEndian(buffer.Span[2..4]),
            opcode = BinaryPrimitives.ReadUInt16BigEndian(buffer.Span[4..6]),
            countMetadata = buffer.Span[6]
        };

        int payloadLength = buffer.Span[7] << 16 | buffer.Span[8] << 8 | buffer.Span[9];
        instance.payload = new byte[payloadLength];
        await sslStream.ReadExactlyAsync(instance.payload.AsMemory());

        return instance;
    }

    public async Task SetClientInfo(UserAgent userAgent)
    {
        Dictionary<string, object> authPayload = new()
        {
            { "userAgent", userAgent },
            { "deviceId",  0},
            { "clientSessionId", 0 }
        };

        MaxMessage message = new()
        {
            opcode = 0x0006,
            payload = MsgPackSerialize.Serialize(authPayload)
        };

        await SendAsync(message);
        var response = await ReceiveAsync();
        MaxException.ThrowIfException(response);
    }

    public async Task<string> StartAuth(string phone)
    {
        Dictionary<object, object?> payload = new()
        {
            { "phone" , phone},
            { "type" , "START_AUTH"}
        };

        MaxMessage message = new()
        {
            opcode = 0x0011,
            payload = MsgPackSerialize.Serialize(payload)
        };

        await SendAsync(message);
        var response = await ReceiveAsync();
        MaxException.ThrowIfException(response);

        var result = MsgPackSerialize.Deserialize(response.payload.AsSpan(2)) as Dictionary<object, object?>;
        return result["token"] as string;
    }

    public async Task<bool> CheckCode(string token, string verifyCode)
    {
        Dictionary<string, string> payload = new()
        {
            { "token", token },
            { "verifyCode", verifyCode },
            { "authTokenType", "CHECK_CODE" }
        };

        MaxMessage message = new()
        {
            opcode = 0x0012,
            payload = MsgPackSerialize.Serialize(payload)
        };

        await SendAsync(message);
        var response = await ReceiveAsync();
        if (response.cmd == MaxCmdType.Ok)
        {
            MsgPackSerialize.Deserialize(response.payload.AsSpan(2));
            return true;
        }
           

        if (response.cmd != MaxCmdType.Error)
            throw new Exception("Unexpected package type");

        var exception = MsgPackSerialize.Deserialize<MaxException>(response.payload);
        if (exception.error != "verify.code")
            throw exception;
        return false;
    }
}
