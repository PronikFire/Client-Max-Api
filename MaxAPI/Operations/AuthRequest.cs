using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Operations;

public static class AuthRequest
{
    public const ushort OPCODE = 17;

    public struct Request(string phone)
    {
        [JsonInclude, JsonPropertyName("phone")]
        [Key("phone")]
        public string phone = phone;

        [JsonInclude, JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Key("type")]
        public AuthRequestType type = AuthRequestType.START_AUTH;
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("token")]
        [Key("token")]
        public string token;

        [JsonInclude, JsonPropertyName("codeLength")]
        [Key("codeLength")]
        public byte codeLength;

        [JsonInclude, JsonPropertyName("requestMaxDuration")]
        [Key("requestMaxDuration")]
        public int requestMaxDuration;

        [JsonInclude, JsonPropertyName("requestCountLeft")]
        [Key("requestCountLeft")]
        public byte requestCountLeft;

        [JsonInclude, JsonPropertyName("altActionDuration")]
        [Key("altActionDuration")]
        public int altActionDuration;
    }

    public enum AuthRequestType
    {
        START_AUTH,
        RESEND
    }
}
