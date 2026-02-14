using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public class MsgContactsByIds
{
    public const ushort OPCODE = 32;

    public struct Request(long[] contactIds)
    {
        [JsonInclude, JsonPropertyName("contactIds")]
        public long[] contactIds = contactIds;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("contacts")]
        public Contact[] contacts;
    }
}
