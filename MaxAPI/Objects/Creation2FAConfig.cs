using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Creation2FAConfig
{
    [JsonInclude, JsonPropertyName("pass_min_len")]
    [Key("pass_min_len")]
    public int pass_min_len;

    [JsonInclude, JsonPropertyName("pass_max_len")]
    [Key("pass_max_len")]
    public int pass_max_len;

    [JsonInclude, JsonPropertyName("hint_max_len")]
    [Key("hint_max_len")]
    public int hint_max_len;

    [JsonInclude, JsonPropertyName("enabled")]
    [Key("enabled")]
    public bool enabled;
}
