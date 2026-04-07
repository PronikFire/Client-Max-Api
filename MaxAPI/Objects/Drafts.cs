using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Drafts
{
    [JsonInclude, JsonPropertyName("chats")]
    [Key("chats")]
    public object chats;

    [JsonInclude, JsonPropertyName("users")]
    [Key("users")]
    public object users;
}
