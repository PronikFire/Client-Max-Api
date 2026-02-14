using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public static class MsgGetSessions
{
    public const ushort OPCODE = 96;

    public struct Request() { }
    public struct Response()
    {
        [JsonInclude, JsonPropertyName("sessions")]
        public Session[] sessions;
    }
}
