using MsgPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.MaxMessages;

public static class MsgSetClientInfo
{
    public const ushort OPCODE = 6;

    public struct Request(UserAgent userAgent, Guid deviceId)
    {
        [JsonInclude, JsonPropertyName("userAgent")]
        [MsgPackInclude, MsgPackName("userAgent")]
        public readonly UserAgent userAgent = userAgent;

        [JsonInclude, JsonPropertyName("deviceId")]
        [MsgPackInclude, MsgPackName("deviceId")]
        public readonly string deviceId = deviceId.ToString();

        /// <summary>
        /// Using only with App. Anyway you probably don't need change it.
        /// </summary>
        [MsgPackInclude, MsgPackName("clientSessionId")]
        public int clientSessionId = 0;
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("phone-auth-enabled")]
        [MsgPackInclude, MsgPackName("phone-auth-enabled")]
        public bool phoneAuthEnabled;

        [JsonInclude, JsonPropertyName("reg-country-code")]
        [MsgPackInclude, MsgPackName("reg-country-code")]
        public string[] regCountryCode;

        [JsonInclude, JsonPropertyName("location")]
        [MsgPackInclude, MsgPackName("location")]
        public string location;
    }
}