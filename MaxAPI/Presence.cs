using System.Text.Json.Serialization;

namespace MaxAPI;

public class Presence
{
    [JsonInclude, JsonPropertyName("seen")]
    public long seen;
    [JsonInclude, JsonPropertyName("status")]
    public int status;
}
