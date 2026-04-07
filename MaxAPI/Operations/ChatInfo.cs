using MaxAPI.Objects;
using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Operations;

public static class ChatInfo
{
    public const ushort OPCODE = 48;

    public struct Request(long[] chatIds)
    {
        [JsonInclude, JsonPropertyName("chatIds")]
        [Key("chatIds")]
        public long[] chatIds = chatIds;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("chats")]
        [Key("chats")]
        public Chat[] chats;
    }
}
