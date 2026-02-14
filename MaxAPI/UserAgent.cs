using MsgPack;
using System.Text.Json.Serialization;

namespace MaxAPI;

public abstract class UserAgent
{
    [JsonInclude, JsonPropertyName("deviceType")]
    [MsgPackInclude, MsgPackName("deviceType")]
    public string deviceType;

    [JsonInclude, JsonPropertyName("locale")]
    [MsgPackInclude, MsgPackName("locale")]
    public string locale;

    [JsonInclude, JsonPropertyName("deviceLocale")]
    [MsgPackInclude, MsgPackName("deviceLocale")]
    public string deviceLocale;

    [JsonInclude, JsonPropertyName("osVersion")]
    [MsgPackInclude, MsgPackName("osVersion")]
    public string osVersion;

    [JsonInclude, JsonPropertyName("deviceName")]
    [MsgPackInclude, MsgPackName("deviceName")]
    public string deviceName;

    [JsonInclude, JsonPropertyName("appVersion")]
    [MsgPackInclude, MsgPackName("appVersion")]
    public string appVersion;

    [JsonInclude, JsonPropertyName("screen")]
    [MsgPackInclude, MsgPackName("screen")]
    public string screen;

    [JsonInclude, JsonPropertyName("timezone")]
    [MsgPackInclude, MsgPackName("timezone")]
    public string timezone;
}
