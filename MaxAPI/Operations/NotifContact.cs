using MaxAPI.Objects;
using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Operations;

public static class NotifContact
{
    public const ushort OPCODE = 131;

    public struct Request()
    {
        [JsonInclude, JsonPropertyName("contact")]
        [Key("contact")]
        public Contact contact;
    }
}
