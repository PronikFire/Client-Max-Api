using MsgPack;
using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public static class MsgCheckCode
{
    public const ushort OPCODE = 0x0012;

    public struct Request(string token, string verifyCode)
    {
        [JsonInclude, JsonPropertyName("token")]
        [MsgPackInclude, MsgPackName("token")]
        public string token = token;

        [JsonInclude, JsonPropertyName("verifyCode")]
        [MsgPackInclude, MsgPackName("verifyCode")]
        public string verifyCode = verifyCode;

        [JsonInclude, JsonPropertyName("authTokenType")]
        [MsgPackInclude, MsgPackName("authTokenType")]
        public string authTokenType = "CHECK_CODE";
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("tokenAttrs")]
        [MsgPackInclude, MsgPackName("tokenAttrs")]
        public TokenAttributes tokenAttributes;
    }
}
