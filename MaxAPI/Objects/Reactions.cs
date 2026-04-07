using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Reactions
{
    [JsonInclude, JsonPropertyName("isActive")]
    [Key("isActive")]
    public bool isActive;

    [JsonInclude, JsonPropertyName("updateTime")]
    [Key("updateTime")]
    public long updateTime;
}

