using System.Text.Json.Serialization;

namespace MaxAPI;

public class Drafts
{
    [JsonInclude, JsonPropertyName("chats")]
    public object chats;

    [JsonInclude, JsonPropertyName("users")]
    public object users;
}
