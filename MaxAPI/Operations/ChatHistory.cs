using MaxAPI.Objects;
using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Operations;

public static class ChatHistory
{
    public const ushort OPCODE = 49;

    public struct Request(long chatId, long from)
    {
        [JsonInclude, JsonPropertyName("chatId")]
        [Key("chatId")]
        public long chatId = chatId;
        [JsonInclude, JsonPropertyName("from")]
        [Key("from")]
        public long from = from;
        [JsonInclude, JsonPropertyName("forward")]
        [Key("forward")]
        public int forward = 30;
        [JsonInclude, JsonPropertyName("backward")]
        [Key("backward")]
        public int backward = 30;
        [JsonInclude, JsonPropertyName("getMessages")]
        [Key("getMessages")]
        public bool getMessages = true;
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("messages")]
        [Key("messages")]
        public Message[] messages;
    }
}
