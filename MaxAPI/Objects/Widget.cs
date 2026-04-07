using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Widget
{
    [JsonInclude, JsonPropertyName("startParam")]
    [Key("startParam")]
    public string startParam;

    [JsonInclude, JsonPropertyName("background")]
    [Key("background")]
    public string background;

    [JsonInclude, JsonPropertyName("appId")]
    [Key("appId")]
    public long appId;

    [JsonInclude, JsonPropertyName("name")]
    [Key("name")]
    public string name;

    [JsonInclude, JsonPropertyName("description")]
    [Key("description")]
    public string description;

    [JsonInclude, JsonPropertyName("id")]
    [Key("id")]
    public long id;

    [JsonInclude, JsonPropertyName("iconUrl")]
    [Key("iconUrl")]
    public string iconUrl;
}
