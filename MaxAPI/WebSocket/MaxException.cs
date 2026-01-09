using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaxAPI.WebSocket;

public class MaxException : Exception
{
    [JsonInclude, JsonPropertyName("localizedMessage")]
    public string localizedMessage = string.Empty;
    [JsonInclude, JsonPropertyName("error")]
    public string error = string.Empty;
    [JsonInclude, JsonPropertyName("message")]
    public string message = string.Empty;
    [JsonInclude, JsonPropertyName("title")]
    public string title = string.Empty;

    public override string Message => $"{error} : {message} ({localizedMessage})";

    private static readonly JsonSerializerOptions jsonOptions = new()
    {
        IncludeFields = true
    };

    public static void ThrowIfError(MaxMessage message)
    {
        if (message.cmd != CmdType.Error)
            return;

        if (message.payload is not JsonElement)
            throw new Exception("Cannot deserialize payload. Payload is not JsonElement");

        var jsonElement = (JsonElement)message.payload;
        throw jsonElement.Deserialize<MaxException>(jsonOptions)!;
    }
}
