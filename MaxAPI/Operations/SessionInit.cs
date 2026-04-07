using MaxAPI.Objects;
using MessagePack;
using System;
using System.Text.Json.Serialization;

namespace MaxAPI.Operations;

public static class SessionInit
{
    public const ushort OPCODE = 6;

    [MessagePackObject]
    public struct Request(UserAgent userAgent, Guid deviceId)
    {
        [JsonInclude, JsonPropertyName("userAgent")]
        [Key("userAgent")]
        public UserAgent userAgent = userAgent;

        [JsonInclude, JsonPropertyName("deviceId")]
        [Key("deviceId")]
        public string deviceId = deviceId.ToString();

        /// <summary>
        /// Using only with App. Anyway you probably don't need change it.
        /// </summary>
        [Key("clientSessionId")]
        public int clientSessionId = 0;
    }

    [MessagePackObject]
    public struct Response
    {
        [JsonInclude, JsonPropertyName("phone-auth-enabled")]
        [Key("phone-auth-enabled")]
        public bool phoneAuthEnabled;

        [JsonInclude, JsonPropertyName("reg-country-code")]
        [Key("reg-country-code")]
        public string[] regCountryCode;

        [JsonInclude, JsonPropertyName("location")]
        [Key("location")]
        public string location;
    }
}