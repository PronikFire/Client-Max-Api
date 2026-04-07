using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Session
{
    [JsonInclude, JsonPropertyName("client")]
    [Key("client")]
    public string client;
    [JsonInclude, JsonPropertyName("location")]
    [Key("location")]
    public string location;
    [JsonInclude, JsonPropertyName("current")]
    [Key("current")]
    public bool current = false;
    [JsonInclude, JsonPropertyName("time")]
    [Key("time")]
    public long time;
    [JsonInclude, JsonPropertyName("info")]
    [Key("info")]
    public string info;
}
