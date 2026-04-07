using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public struct Name()
{
    [JsonInclude, JsonPropertyName("name")]
    [Key("name")]
    public string name = string.Empty;

    [JsonInclude, JsonPropertyName("firstName")]
    [Key("firstName")]
    public string firstName = string.Empty;

    [JsonInclude, JsonPropertyName("lastName")]
    [Key("lastName")]
    public string lastName = string.Empty;

    [JsonInclude, JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Key("type")]
    public NameType type;
}