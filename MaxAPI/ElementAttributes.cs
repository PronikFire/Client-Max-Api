using System.Text.Json.Serialization;

namespace MaxAPI;

public class ElementAttributes
{
    [JsonInclude, JsonPropertyName("url")]
    public string url;
}
