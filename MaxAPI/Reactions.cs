using System.Text.Json.Serialization;

namespace MaxAPI;

public class Reactions
{
    [JsonInclude, JsonPropertyName("isActive")]
    public bool isActive;

    [JsonInclude, JsonPropertyName("updateTime")]
    public long updateTime;
}

