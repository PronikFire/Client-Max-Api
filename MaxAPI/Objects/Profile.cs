using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Profile
{
    [JsonInclude, JsonPropertyName("profileOptions")]
    [Key("profileOptions")]
    public object[] profileOptions;

    [JsonInclude, JsonPropertyName("contact")]
    [Key("contact")]
    public Contact contact;
}
