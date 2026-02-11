using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.MaxMessages;

public class MsgContactsByIds
{
    public const ushort OPCODE = 32;

    public struct Request(long[] contactIds)
    {
        [JsonInclude, JsonPropertyName("contactIds")]
        public readonly long[] contactIds = contactIds;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("contacts")]
        public Contact[] contacts;
    }
}
