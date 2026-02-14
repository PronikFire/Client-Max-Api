using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public static class MsgSetNames
{
    public const ushort OPCODE = 16;

    public struct Request(string firstName, string lastName)
    {
        [JsonInclude, JsonPropertyName("firstName")]
        public string firstName = firstName;

        [JsonInclude, JsonPropertyName("lastName")]
        public string lastName = lastName;

        [JsonInclude, JsonPropertyName("description")]
        public string description;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("profile")]
        public Profile profile;
    }
}
