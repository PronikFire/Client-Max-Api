using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Image
{
    [JsonInclude, JsonPropertyName("_type")]
    [Key("_type")]
    public string _type;

    [JsonInclude, JsonPropertyName("width")]
    [Key("width")]
    public int width;

    [JsonInclude, JsonPropertyName("url")]
    [Key("url")]
    public string url;

    [JsonInclude, JsonPropertyName("height")]
    [Key("height")]
    public int height;
}
