using MsgPack;
using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public static class MsgAuthPhone
{
    public const ushort OPCODE = 0x0011;

    public struct Request(string phone)
    {
        [JsonInclude, JsonPropertyName("phone")]
        [MsgPackInclude, MsgPackName("phone")]
        public string phone = phone;

        //Когда будет не лень, надо сделать конвертацию Enum в строку как в Json
        //Ну и соответственно сделать Enum для этого поля
        [JsonInclude, JsonPropertyName("type")]
        [MsgPackInclude, MsgPackName("type")]
        public string type = "START_AUTH";
        // RESEND
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("token")]
        [MsgPackInclude, MsgPackName("token")]
        public string token;

        [JsonInclude, JsonPropertyName("codeLength")]
        [MsgPackInclude, MsgPackName("codeLength")]
        public byte codeLength;

        [JsonInclude, JsonPropertyName("requestMaxDuration")]
        [MsgPackInclude, MsgPackName("requestMaxDuration")]
        public int requestMaxDuration;

        [JsonInclude, JsonPropertyName("CountLeft")]
        [MsgPackInclude, MsgPackName("CountLeft")]
        public byte countLeft;

        [JsonInclude, JsonPropertyName("altAction")]
        [MsgPackInclude, MsgPackName("altAction")]
        public object altAction;
    }
}
