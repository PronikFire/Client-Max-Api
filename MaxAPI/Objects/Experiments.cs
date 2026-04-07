using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Experiments
{
    [JsonInclude, JsonPropertyName("app.ab.test.exp")]
    [Key("app.ab.test.exp")]
    public bool appAbTestExp = false;
}
