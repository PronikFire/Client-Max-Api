using MaxAPI.Objects;
using MessagePack;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using K4os.Compression.LZ4;
using System.Diagnostics;

namespace MaxAPI;

public class MaxAppClient : MaxClient
{
    protected override bool IsConnected => tcpClient.Connected;

    private readonly TcpClient tcpClient = new();
    private SslStream stream;

    private const string MAX_HOST = "api.oneme.ru";

    public static async Task<MaxAppClient> SessionLoginAsync(string token, UserAgent? userAgent = null, MaxOptions? options = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(token, nameof(token));

        MaxAppClient client = new()
        {
            options = options ?? new(),
            Token = token,
            userAgent = userAgent ?? UserAgent.DefaultApp
        };

        await client.SessionInitAsync(cancellationToken);
        var loginResponse = await client.LoginAsync(token, userAgent: client.userAgent);
        client.Config = loginResponse.config;
        client.Profile = loginResponse.profile;
        client.chats = loginResponse.chats.ToDictionary(cb => cb.Id);
        client.contacts = loginResponse.contacts.ToDictionary(c => c.id);
        return client;
    }

    protected override async Task SendAsync(MaxMessage message, CancellationToken cancellationToken = default)
    {
        var binaryPayload = MessagePackSerializer.Serialize(message.payload!.GetType(), message.payload, cancellationToken: cancellationToken);

        int cof = 0;
        if (binaryPayload.Length > 32 && false)
        {
            Span<byte> compress = stackalloc byte[LZ4Codec.MaximumOutputSize(binaryPayload.Length)];
            int written = LZ4Codec.Encode(binaryPayload, compress);

            if (written > 0)
            {
                cof = (binaryPayload.Length / written) + 1;
                binaryPayload = compress[..written].ToArray();
            }
        }

        Memory<byte> memory = new byte[10 + binaryPayload.Length];
        var buffer = memory.Span;
        buffer[0] = message.version;
        buffer[1] = (byte)message.cmd;
        BinaryPrimitives.WriteUInt16BigEndian(buffer[2..4], message.seq);
        BinaryPrimitives.WriteUInt16BigEndian(buffer[4..6], message.opcode);
        buffer[6] = (byte)cof;
        buffer[7] = (byte)(binaryPayload.Length >> 16);
        buffer[8] = (byte)(binaryPayload.Length >> 8);
        buffer[9] = (byte)binaryPayload.Length;
        binaryPayload.CopyTo(buffer[10..]);

        Debug.Print(BitConverter.ToString(memory.ToArray()));
        await stream.WriteAsync(memory, cancellationToken);
    }

    protected override async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        await tcpClient.ConnectAsync(MAX_HOST, 443);
        stream = new SslStream(tcpClient.GetStream());
        stream.AuthenticateAsClient(MAX_HOST);
    }

    protected override async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        stream.Close();
        await stream.DisposeAsync();
        tcpClient.Close();
    }

    protected override async Task<MaxMessage> ReceiveAsync(CancellationToken cancellationToken = default)
    {
        Memory<byte> buffer = new byte[10];

        await stream.ReadExactlyAsync(buffer, cancellationToken);

        Span<byte> span = buffer.Span;

        MaxMessage instance = new()
        {
            version = span[0],
            cmd = (CmdType)span[1],
            seq = BinaryPrimitives.ReadUInt16BigEndian(span[2..4]),
            opcode = BinaryPrimitives.ReadUInt16BigEndian(span[4..6])
        };
        byte cof = span[6];
        int payloadLength = span[7] << 16 | span[8] << 8 | span[9];
        var payload = new byte[payloadLength];
        await stream.ReadExactlyAsync(payload, cancellationToken);

        if (cof > 0)
        {
            Span<byte> decompressPayload = stackalloc byte[cof * payloadLength];
            int written = LZ4Codec.Decode(payload, decompressPayload);
            payload = decompressPayload[..written].ToArray();
        }

        instance.payload = payload;

        return instance;
    }
}