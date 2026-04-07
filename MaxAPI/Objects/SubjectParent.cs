using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class SubjectParent
{
    [JsonInclude, JsonPropertyName("organizationIds")]
    [Key("organizationIds")]
    public long[] organizationIds = [];
}
