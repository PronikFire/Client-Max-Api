using System.Text.Json.Serialization;

namespace MaxAPI;

public class Session
{
    [JsonInclude, JsonPropertyName("client")]
    public string client;
    [JsonInclude, JsonPropertyName("location")]
    public string location;
    [JsonInclude, JsonPropertyName("current")]
    public bool current = false;
    [JsonInclude, JsonPropertyName("time")]
    public long time;
    [JsonInclude, JsonPropertyName("info")]
    public string info;
}
