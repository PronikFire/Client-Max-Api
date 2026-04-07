using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class SearchWebappsShowcase
{
    [JsonInclude, JsonPropertyName("items")]
    [Key("items")]
    public Item[] items;
}
