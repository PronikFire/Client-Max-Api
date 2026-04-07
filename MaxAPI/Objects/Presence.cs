using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Presence
{
    [JsonInclude, JsonPropertyName("seen")]
    [Key("seen")]
    public long seen;
    [JsonInclude, JsonPropertyName("status")]
    [Key("status")]
    public int status;
}
