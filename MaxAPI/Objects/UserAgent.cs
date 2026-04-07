using MessagePack;
using MessagePack.Formatters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class UserAgent
{
    public static UserAgent DefaultApp => new()
    {
        deviceType = DeviceType.Desktop,
        locale = "ru",
        deviceLocale = "ru",
        osVersion = "Windows 10 Version 22H2",
        deviceName = "DESKTOP",
        buildNumber = 40698,
        appVersion = "25.21.1",
        screen = "1.0x",
        timezone = "Europe/Moscow"
    };

    public static UserAgent DefaultWeb => new()
    {
        deviceType = DeviceType.Web,
        locale = "ru",
        deviceLocale = "ru",
        osVersion = "Windows",
        deviceName = "Edge",
        headerUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/143.0.0.0 Safari/537.36 Edg/143.0.0.0",
        appVersion = "25.12.14",
        screen = "1080x1920 1.0x",
        timezone = "Europe/Moscow"
    };

    [JsonInclude, JsonPropertyName("deviceType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Key("deviceType")]
    public DeviceType deviceType;

    [JsonInclude, JsonPropertyName("locale")]
    [Key("locale")]
    public string locale;

    [JsonInclude, JsonPropertyName("deviceLocale")]
    [Key("deviceLocale")]
    public string deviceLocale;

    [JsonInclude, JsonPropertyName("osVersion")]
    [Key("osVersion")]
    public string osVersion;

    [JsonInclude, JsonPropertyName("deviceName")]
    [Key("deviceName")]
    public string deviceName;

    [JsonInclude, JsonPropertyName("appVersion")]
    [Key("appVersion")]
    public string appVersion;

    [JsonInclude, JsonPropertyName("screen")]
    [Key("screen")]
    public string screen;

    [JsonInclude, JsonPropertyName("timezone")]
    [Key("timezone")]
    public string timezone;

    //Web
    [JsonInclude, JsonPropertyName("headerUserAgent")]
    [IgnoreMember]
    public string headerUserAgent;

    //App
    [JsonIgnore]
    [Key("buildNumber")]
    public int buildNumber;
    [JsonIgnore]
    [Key("arch")]
    //[MessagePackIgnore]
    // Build.SUPPORTED_ABIS - Android
    public string arch = "UNKNOWN";

    /*
     *  [MessagePackMember(12, Name = "pushDeviceType")]
     *  public string pushDeviceType = ???;
     *  HUAWEI | GCM | RUSTORE
     *  
     *  [MessagePackMember(13, Name = "mt_instanceid")]
     *  public string mtInstanceid = ???;
     */
}
