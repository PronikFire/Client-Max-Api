using System.Text.Json.Serialization;

namespace MaxAPI;

public class Image
{
    [JsonInclude, JsonPropertyName("_type")]
    public string _type;

    [JsonInclude, JsonPropertyName("width")]
    public int width;

    [JsonInclude, JsonPropertyName("url")]
    public string url;

    [JsonInclude, JsonPropertyName("height")]
    public int height;
}
