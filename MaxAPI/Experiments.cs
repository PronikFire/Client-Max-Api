using System.Text.Json.Serialization;

namespace MaxAPI;

public class Experiments
{
    [JsonInclude, JsonPropertyName("app.ab.test.exp")]
    public bool appAbTestExp = false;
}
