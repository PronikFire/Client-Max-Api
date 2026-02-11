using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.MaxMessages;

public class MsgNewMessageEvent
{
    public const ushort OPCODE = 128;

    public struct Request
    {
        [JsonInclude, JsonPropertyName("chatId")]
        public int chatId;

        [JsonInclude, JsonPropertyName("unread")]
        public int unread;

        [JsonInclude, JsonPropertyName("message")]
        public Message message;

        [JsonInclude, JsonPropertyName("ttl")]
        public bool ttl;

        [JsonInclude, JsonPropertyName("mark")]
        public long mark;

        [JsonInclude, JsonPropertyName("prevMessageId")]
        public string prevMessageId;
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("chatId")]
        public int chatId;

        [JsonInclude, JsonPropertyName("messageId")]
        public string messageId;
    }
}
