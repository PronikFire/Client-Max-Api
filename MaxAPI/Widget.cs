using System.Text.Json.Serialization;

namespace MaxAPI;

public class Widget
{
    [JsonInclude, JsonPropertyName("startParam")]
    public string startParam;

    [JsonInclude, JsonPropertyName("background")]
    public string background;

    [JsonInclude, JsonPropertyName("appId")]
    public long appId;

    [JsonInclude, JsonPropertyName("name")]
    public string name;

    [JsonInclude, JsonPropertyName("description")]
    public string description;

    [JsonInclude, JsonPropertyName("id")]
    public long id;

    [JsonInclude, JsonPropertyName("iconUrl")]
    public string iconUrl;
}
