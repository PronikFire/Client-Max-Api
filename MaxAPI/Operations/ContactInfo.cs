using MaxAPI.Objects;
using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Operations;

public class ContactInfo
{
    public const ushort OPCODE = 32;

    public struct Request(long[] contactIds)
    {
        [JsonInclude, JsonPropertyName("contactIds")]
        [Key("contactIds")]
        public long[] contactIds = contactIds;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("contacts")]
        [Key("contacts")]
        public Contact[] contacts;
    }
}
