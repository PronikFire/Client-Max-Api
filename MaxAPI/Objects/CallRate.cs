using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class CallRate
{
    [JsonInclude, JsonPropertyName("limit")]
    [Key("limit")]
    public int limit;

    [JsonInclude, JsonPropertyName("duration")]
    [Key("duration")]
    public int duration;

    [JsonInclude, JsonPropertyName("sdk-limit")]
    [Key("sdk-limit")]
    public int sdklimit;

    [JsonInclude, JsonPropertyName("delay")]
    [Key("delay")]
    public int delay;
}
