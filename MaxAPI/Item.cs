using System.Text.Json.Serialization;

namespace MaxAPI;

public class Item
{
    [JsonInclude, JsonPropertyName("icon")]
    public string icon;

    [JsonInclude, JsonPropertyName("title")]
    public string title;

    [JsonInclude, JsonPropertyName("id")]
    public long id;
}
