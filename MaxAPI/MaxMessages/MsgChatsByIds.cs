using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public static class MsgChatsByIds
{
    public const ushort OPCODE = 48;

    public struct Request(long[] chatIds)
    {
        [JsonInclude, JsonPropertyName("chatIds")]
        public long[] chatIds = chatIds;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("chats")]
        public ChatBase[] chats;
    }
}
