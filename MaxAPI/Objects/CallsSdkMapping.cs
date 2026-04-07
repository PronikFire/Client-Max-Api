using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class CallsSdkMapping
{
    [JsonInclude, JsonPropertyName("off")]
    [Key("off")]
    public bool off;
}
