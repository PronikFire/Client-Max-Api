using MaxAPI.Objects;
using System.Text.Json.Serialization;

namespace MaxAPI.Operations;

public static class SessionsInfo
{
    public const ushort OPCODE = 96;

    public struct Request() { }
    public struct Response()
    {
        [JsonInclude, JsonPropertyName("sessions")]
        public Session[] sessions;
    }
}
