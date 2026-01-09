using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket.Payloads;

public static class MsgSetClientInfo
{
    public const ushort OPCODE = 6;

    public readonly struct Request(UserAgent userAgent, Guid deviceId)
    {
        [JsonInclude, JsonPropertyName("userAgent")]
        public readonly UserAgent userAgent = userAgent;
        [JsonInclude, JsonPropertyName("deviceId")]
        public readonly string deviceId = deviceId.ToString();
    }


    public struct Response
    {
        [JsonInclude, JsonPropertyName("phone-auth-enabled")]
        public bool phoneAuthEnabled;
        [JsonInclude, JsonPropertyName("reg-country-code")]
        public string[] regCountryCode;
        [JsonInclude, JsonPropertyName("location")]
        public string location;
    }

    public struct UserAgent
    {
        [JsonInclude, JsonPropertyName("deviceType")]
        public string deviceType;
        [JsonInclude, JsonPropertyName("locale")]
        public string locale;
        [JsonInclude, JsonPropertyName("deviceLocale")]
        public string deviceLocale;
        [JsonInclude, JsonPropertyName("osVersion")]
        public string osVersion;
        [JsonInclude, JsonPropertyName("deviceName")]
        public string deviceName;
        [JsonInclude, JsonPropertyName("headerUserAgent")]
        public string headerUserAgent;
        [JsonInclude, JsonPropertyName("appVersion")]
        public string appVersion;
        [JsonInclude, JsonPropertyName("screen")]
        public string screen;
        [JsonInclude, JsonPropertyName("timezone")]
        public string timezone;

        public static UserAgent Default => new()
        {
            deviceType = "WEB",
            locale = "ru",
            deviceLocale = "ru",
            osVersion = "Windows",
            deviceName = "Edge",
            headerUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/143.0.0.0 Safari/537.36 Edg/143.0.0.0",
            appVersion = "25.12.14",
            screen = "1080x1920 1.0x",
            timezone = "Europe/Moscow"
        };
    }
}