using System.Text.Json.Serialization;

namespace MaxAPI;

public class Profile
{
    [JsonInclude, JsonPropertyName("profileOptions")]
    public object[] profileOptions;

    [JsonInclude, JsonPropertyName("contact")]
    public Contact contact;
}
