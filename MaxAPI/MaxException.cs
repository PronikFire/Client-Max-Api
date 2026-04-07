using MessagePack;
using System;
using System.Text.Json.Serialization;

namespace MaxAPI;

/// <summary>
/// Represents an exception that contains detailed error information returned from a Max protocol message or operation.
/// </summary>
[MessagePackObject(true)]
public class MaxException : Exception
{
    [JsonInclude, JsonPropertyName("localizedMessage")]
    [Key("localizedMessage")]
    public string localizedMessage = string.Empty;

    [JsonInclude, JsonPropertyName("error")]
    [Key("error")]
    public string error = string.Empty;

    [JsonInclude, JsonPropertyName("message")]
    [Key("message")]
    public string message = string.Empty;

    [JsonInclude, JsonPropertyName("title")]
    [Key("title")]
    public string title = string.Empty;

    [IgnoreMember]
    public override string Message => $"{error} : {message} ({localizedMessage})";

    public static bool TryParse(MaxMessage message, out MaxException exception)
    {
        exception = default!;

        if (message.cmd != CmdType.Error)
            return false;

        exception = message.DeserializePayload<MaxException>();
        return true;
    }

    public static void ThrowIfError(MaxMessage message)
    {
        if (!TryParse(message, out MaxException exception))
            return;

        throw exception;
    }
}

