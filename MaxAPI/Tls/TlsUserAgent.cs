namespace MaxAPI.Tls;

public class TlsUserAgent
{
    public string deviceType;
    public string appVersion;
    public string osVersion;
    public string locale;
    public string deviceLocale;
    public string deviceName;
    public string screen;
    public string timezone;
    public int buildNumber;

    public static TlsUserAgent Default => new()
    {
        deviceType = "DESKTOP",
        appVersion = "25.21.1",
        osVersion = "Windows 10 Version 2004",
        locale = "ru",
        deviceLocale = "ru",
        deviceName = "DESKTOP-0000000",
        screen = "1.0x",
        timezone = "Europe/Moscow",
        buildNumber = 40698
    };
}
