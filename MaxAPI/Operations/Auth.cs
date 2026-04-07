using MaxAPI.Objects;
using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Operations;

public static class Auth
{
    public const ushort OPCODE = 18;

    public struct Request(string token, string verifyCode)
    {
        [JsonInclude, JsonPropertyName("token")]
        [Key("token")]
        public string token = token;

        [JsonInclude, JsonPropertyName("verifyCode")]
        [Key("verifyCode")]
        public string verifyCode = verifyCode;

        [JsonInclude, JsonPropertyName("authTokenType")]
        [Key("authTokenType")]
        public string authTokenType = "CHECK_CODE";
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("tokenAttrs")]
        [Key("tokenAttrs")]
        public TokenAttributes tokenAttributes;
    }
}
