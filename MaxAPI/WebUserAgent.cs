using System.Text.Json.Serialization;

namespace MaxAPI;

public class WebUserAgent : UserAgent
{
    [JsonInclude, JsonPropertyName("headerUserAgent")]
    public string headerUserAgent;

    public static WebUserAgent Default => new()
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