using System.Text.Json.Serialization;

namespace MaxAPI;

public struct AdminParticipants()
{
    [JsonInclude, JsonPropertyName("id")]
    public long id;

    [JsonInclude, JsonPropertyName("alias")]
    public string alias = string.Empty;
}
