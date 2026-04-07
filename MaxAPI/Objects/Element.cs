using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Element
{
    [JsonInclude, JsonPropertyName("length")]
    [Key("length")]
    public int length;

    [JsonInclude, JsonPropertyName("from")]
    [Key("from")]
    public int from;

    [JsonInclude, JsonPropertyName("attributes")]
    [Key("attributes")]
    public ElementAttributes attributes;

    [JsonInclude, JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Key("type")]
    public ElementType type;
}
