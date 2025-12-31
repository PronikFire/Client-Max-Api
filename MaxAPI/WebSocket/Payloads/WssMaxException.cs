using MaxAPI.Tls.Payloads;
using MsgPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket.Payloads;

public class WssMaxException : Exception
{
    public string localizedMessage;
    public string error;
    public string message;
    public string title;

    public override string Message => $"{error} : {message} ({localizedMessage})";

    private static readonly JsonSerializerOptions jsonOptions = new()
    {
        IncludeFields = true
    };

    public static void ThrowIfError(WssMaxMessage message)
    {
        if (message.cmd != CmdType.Error)
            return;

        var jsonElement = (JsonElement)message.payload;
        throw jsonElement.Deserialize<TlsMaxException>(jsonOptions);
    }
}
