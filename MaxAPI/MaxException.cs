using MsgPack;
using System;

namespace MaxAPI;

public class MaxException : Exception
{
    public string error;
    public string message;
    public string localizedMessage;
    public string title;

    public override string Message => $"{message} ({localizedMessage})";

    public static void ThrowIfException(MaxMessage message)
    {
        if (message.cmd != MaxCmdType.Error)
            return;

        throw MsgPackSerialize.Deserialize<MaxException>(message.payload);
    }
}
