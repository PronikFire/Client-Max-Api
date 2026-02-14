using System.Text.Json.Serialization;

namespace MaxAPI;

public struct Names()
{
    [JsonPropertyName("name")]
    public string name = string.Empty;

    [JsonPropertyName("firstName")]
    public string firstName = string.Empty;

    [JsonPropertyName("lastName")]
    public string lastName = string.Empty;

    [JsonPropertyName("type")]
    public string type = string.Empty;
}