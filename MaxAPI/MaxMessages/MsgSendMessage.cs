using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public static class MsgSendMessage
{
    public const ushort OPCODE = 64;

    public struct Request(long chatId, Message message)
    {
        [JsonInclude, JsonPropertyName("chatId")]
        public long chatId = chatId;

        [JsonInclude, JsonPropertyName("message")]
        public Message message = message;

        [JsonInclude, JsonPropertyName("notify")]
        public bool notify = true;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("chatId")]
        public long chatId;

        [JsonInclude, JsonPropertyName("message")]
        public Message message;

        [JsonInclude, JsonPropertyName("message")]
        public long unread;

        [JsonInclude, JsonPropertyName("message")]
        public long mark;
    }
}
