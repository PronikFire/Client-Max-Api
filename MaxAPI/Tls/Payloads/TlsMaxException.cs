using MaxAPI.WebSocket;
using MsgPack;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaxAPI.Tls.Payloads;

public class TlsMaxException : Exception
{
    public string localizedMessage;
    public string error;
    public string message;
    public string title;

    public override string Message => $"{error} : {message} ({localizedMessage})";

    public static void ThrowIfException(TlsMaxMessage message)
    {
        if (message.cmd != CmdType.Error)
            return;

        throw MsgPackSerialize.Deserialize<TlsMaxException>(message.payload);
    }
}
