using System.Text.Json.Serialization;

namespace MaxAPI;

public class CallsSdkMapping
{
    [JsonInclude, JsonPropertyName("off")]
    public bool off;
}
