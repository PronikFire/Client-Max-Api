using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public struct AdminParticipants()
{
    [JsonInclude, JsonPropertyName("id")]
    [Key("id")]
    public long id;

    [JsonInclude, JsonPropertyName("alias")]
    [Key("alias")]
    public string alias = string.Empty;
}
