using MaxAPI.Tls.Payloads;
using MsgPack;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MaxAPI.Tls;

public class TlsMaxClient
{
    public bool InteractivePing { get; set; } = true;

    private readonly TcpClient tcpClient = new(MAX_HOST, 443);
    private readonly Stream networkStream;
    private readonly SslStream sslStream;
    protected ushort seq = 0;

    //Я конечно понимаю что это "Beta", но всё же...
    //Даже в бету можно было бы поставить нормальный хост
    //При всём этом у них есть домен api.max.ru XD
    private const string MAX_HOST = "api.oneme.ru";

    [Obsolete("Don't work. Use WebSocket")]
    public TlsMaxClient()
    {
        networkStream = tcpClient.GetStream();
        //SSL для TCP\Tls
        sslStream = new SslStream(networkStream);
        sslStream.AuthenticateAsClient(MAX_HOST);
    }

    public async Task SendAsync(TlsMaxMessage message, bool useInternalSeq = true)
    {
        Memory<byte> memory = new byte[10 + message.payload.Length];
        var buffer = memory.Span;
        buffer[0] = message.ver;
        buffer[1] = (byte)message.cmd;
        if (useInternalSeq)
            BinaryPrimitives.WriteUInt16BigEndian(buffer[2..4], seq++);
        else
            BinaryPrimitives.WriteUInt16BigEndian(buffer[2..4], message.seq);
        BinaryPrimitives.WriteUInt16BigEndian(buffer[4..6], message.opcode);
        buffer[6] = message.extMode;
        buffer[7] = (byte)(message.payload.Length >> 16);
        buffer[8] = (byte)(message.payload.Length >> 8);
        buffer[9] = (byte)message.payload.Length;
        message.payload.CopyTo(buffer[10..]);

        await sslStream.WriteAsync(memory);
    }

    public async Task<TlsMaxMessage> ReceiveAsync()
    {
        Memory<byte> buffer = new byte[10];

        await sslStream.ReadExactlyAsync(buffer);

        Span<byte> span = buffer.Span;

        TlsMaxMessage instance = new()
        {
            ver = span[0],
            cmd = (CmdType)span[1],
            seq = BinaryPrimitives.ReadUInt16BigEndian(span[2..4]),
            opcode = BinaryPrimitives.ReadUInt16BigEndian(span[4..6]),
            extMode = span[6]

        };

        int payloadLength = span[7] << 16 | span[8] << 8 | span[9];
        instance.payload = new byte[payloadLength];
        await sslStream.ReadExactlyAsync(instance.payload);

        return instance;
    }

    public async Task<string> StartAuth(string phone)
    {
        Dictionary<object, object?> payload = new()
        {
            { "phone" , phone},
            { "type" , "START_AUTH"}
        };

        TlsMaxMessage message = new()
        {
            opcode = 0x0011,
            payload = MsgPackSerialize.Serialize(payload)
        };

        await SendAsync(message);
        var response = await ReceiveAsync();
        TlsMaxException.ThrowIfException(response);

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

        TlsMaxMessage message = new()
        {
            opcode = 0x0012,
            payload = MsgPackSerialize.Serialize(payload)
        };

        await SendAsync(message);
        var response = await ReceiveAsync();
        if (response.cmd == CmdType.Response)
        {
            MsgPackSerialize.Deserialize(response.payload.AsSpan(2));
            return true;
        }
           

        if (response.cmd != CmdType.Error)
            throw new Exception("Unexpected package type");

        var exception = MsgPackSerialize.Deserialize<TlsMaxException>(response.payload);
        if (exception.error != "verify.code")
            throw exception;
        return false;
    }
}
