using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public class MsgNewMessageEvent
{
    public const ushort OPCODE = 128;

    public struct Request()
    {
        [JsonInclude, JsonPropertyName("chatId")]
        public long chatId;

        [JsonInclude, JsonPropertyName("unread")]
        public long unread;

        [JsonInclude, JsonPropertyName("chat")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Chat? chat;

        [JsonInclude, JsonPropertyName("message")]
        public Message message;

        [JsonInclude, JsonPropertyName("ttl")]
        public bool ttl;

        [JsonInclude, JsonPropertyName("mark")]
        public long mark;

        [JsonInclude, JsonPropertyName("prevMessageId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? prevMessageId = null;
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("chatId")]
        public long chatId;

        [JsonInclude, JsonPropertyName("messageId")]
        public string messageId;
    }
}
