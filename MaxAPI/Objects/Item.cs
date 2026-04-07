using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Item
{
    [JsonInclude, JsonPropertyName("icon")]
    [Key("icon")]
    public string icon;

    [JsonInclude, JsonPropertyName("title")]
    [Key("title")]
    public string title;

    [JsonInclude, JsonPropertyName("id")]
    [Key("id")]
    public long id;
}
