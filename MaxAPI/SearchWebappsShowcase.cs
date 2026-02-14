using System.Text.Json.Serialization;

namespace MaxAPI;

public class SearchWebappsShowcase
{
    [JsonInclude, JsonPropertyName("items")]
    public Item[] items;
}
