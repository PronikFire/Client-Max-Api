using System.Text.Json.Serialization;

namespace MaxAPI;

public struct Names()
{
    [JsonInclude, JsonPropertyName("name")]
    public string name = string.Empty;

    [JsonInclude, JsonPropertyName("firstName")]
    public string firstName = string.Empty;

    [JsonInclude, JsonPropertyName("lastName")]
    public string lastName = string.Empty;

    [JsonInclude, JsonPropertyName("type")]
    public string type = string.Empty;
}