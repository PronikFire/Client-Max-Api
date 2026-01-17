using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MsgPack;

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

    public static void ThrowIfError(MaxMessage message)
    {
        if (message.cmd != CmdType.Error)
            return;
        MaxException exception = message.payload switch
        {
            byte[] binaryPayload => MsgPackSerialize.Deserialize<MaxException>(binaryPayload),
            JsonElement element => element.Deserialize<MaxException>()!,
            _ => throw new Exception("Not supported payload type."),
        };
        throw exception;
    }
}
