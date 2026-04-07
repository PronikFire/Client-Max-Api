using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Operations;

public static class Log
{
    public const ushort OPCODE = 5;

    public struct Request()
    {
        [JsonInclude, JsonPropertyName("type")]
        [Key("type")]
        public string type;
        [JsonInclude, JsonPropertyName("event")]
        [Key("event")]
        public string @event;
        [JsonInclude, JsonPropertyName("userId")]
        [Key("userId")]
        public long userId;
        [JsonInclude, JsonPropertyName("sessionId")]
        [Key("sessionId")]
        public long sessionId;
        [JsonInclude, JsonPropertyName("params")]
        [Key("params")]
        public object @params;
        [JsonInclude, JsonPropertyName("time")]
        [Key("time")]
        public long time;
    }
}
