using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Objects;

[MessagePackObject]
public class ElementAttributes
{
    [JsonInclude, JsonPropertyName("url")]
    [Key("url")]
    public string url;
}
