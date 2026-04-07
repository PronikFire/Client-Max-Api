using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Link
{
    [JsonInclude, JsonPropertyName("type")]
    [Key("type")]
    public string type;

    [JsonInclude, JsonPropertyName("message")]
    [Key("message")]
    public Message message;

    [JsonInclude, JsonPropertyName("chatId")]
    [Key("chatId")]
    public long chatId;
}
