using System.Text.Json.Serialization;

namespace MaxAPI.Operations;

public static class Profile
{
    public const ushort OPCODE = 16;

    public struct Request(string firstName, string lastName)
    {
        [JsonInclude, JsonPropertyName("firstName")]
        public string firstName = firstName;

        [JsonInclude, JsonPropertyName("lastName")]
        public string lastName = lastName;

        [JsonInclude, JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? description = null;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("profile")]
        public Objects.Profile profile;
    }
}
