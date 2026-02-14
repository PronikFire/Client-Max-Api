using System.Text.Json.Serialization;

namespace MaxAPI;

public class Link
{
    [JsonInclude, JsonPropertyName("type")]
    public string type;

    [JsonInclude, JsonPropertyName("message")]
    public Message message;

    [JsonInclude, JsonPropertyName("chatId")]
    public long chatId;
}
