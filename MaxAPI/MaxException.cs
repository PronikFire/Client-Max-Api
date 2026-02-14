using MsgPack;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaxAPI;

/// <summary>
/// Represents an exception that contains detailed error information returned from a Max protocol message or operation.
/// </summary>
public class MaxException : Exception
{
    [JsonInclude, JsonPropertyName("localizedMessage")]
    [MsgPackInclude, MsgPackName("localizedMessage")]
    public string localizedMessage = string.Empty;

    [JsonInclude, JsonPropertyName("error")]
    [MsgPackInclude, MsgPackName("error")]
    public string error = string.Empty;

    [JsonInclude, JsonPropertyName("message")]
    [MsgPackInclude, MsgPackName("message")]
    public string message = string.Empty;

    [JsonInclude, JsonPropertyName("title")]
    [MsgPackInclude, MsgPackName("title")]
    public string title = string.Empty;

    public override string Message => $"{error} : {message} ({localizedMessage})";

    public static bool TryParse(MaxMessage message, out MaxException exception)
    {
        exception = default!;

        if (message.cmd != CmdType.Error)
            return false;

        exception = message.payload switch
        {
            byte[] binaryPayload => MsgPackSerialize.Deserialize<MaxException>(binaryPayload)!,
            JsonElement element => element.Deserialize<MaxException>()!,
            _ => default!,
        };
        return true;
    }

    public static void ThrowIfError(MaxMessage message)
    {
        if (!TryParse(message, out MaxException exception))
            return;

        throw exception;
    }
}
