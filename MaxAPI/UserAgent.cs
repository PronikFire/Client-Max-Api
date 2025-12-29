namespace MaxAPI;

public struct UserAgent
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

    public static UserAgent Default => new()
    {
        deviceType = "DESKTOP",
        appVersion = "25.12.2",
        osVersion = "Windows 10 Version 2004",
        locale = "en",
        deviceLocale = "en",
        deviceName = "00000000-0000-0",
        screen = "1.0x",
        timezone = "Europe/Moscow",
        buildNumber = 40698
    };
}
