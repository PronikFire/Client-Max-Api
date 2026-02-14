using System.Text.Json.Serialization;

namespace MaxAPI;

public class SubjectParent
{
    [JsonInclude, JsonPropertyName("organizationIds")]
    public long[] organizationIds = [];
}
