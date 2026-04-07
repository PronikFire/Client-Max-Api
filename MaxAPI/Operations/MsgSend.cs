using MaxAPI.Objects;
using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Operations;

public static class MsgSend
{
    public const ushort OPCODE = 64;

    public struct Request(long chatId, Message message)
    {
        [JsonInclude, JsonPropertyName("chatId")]
        [Key("chatId")]
        public long chatId = chatId;

        [JsonInclude, JsonPropertyName("message")]
        [Key("message")]
        public Message message = message;

        [JsonInclude, JsonPropertyName("notify")]
        [Key("notify")]
        public bool notify = true;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("chatId")]
        [Key("chatId")]
        public long chatId;

        [JsonInclude, JsonPropertyName("message")]
        [Key("message")]
        public Message message;

        [JsonInclude, JsonPropertyName("unread")]
        [Key("unread")]
        public long unread;

        [JsonInclude, JsonPropertyName("mark")]
        [Key("mark")]
        public long mark;
    }
}
