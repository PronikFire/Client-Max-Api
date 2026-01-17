using MsgPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAPI;

public class AppUserAgent : UserAgent
{
    [MsgPackInclude, MsgPackName("buildNumber")]
    public int buildNumber;

    public static AppUserAgent Default => new()
    {
        deviceType = "DESKTOP",
        locale = "ru",
        deviceLocale = "ru",
        osVersion = "Windows 10 Version 22H2",
        deviceName = "DESKTOP-1234567",
        buildNumber = 40698,
        appVersion = "25.21.1",
        screen = "1.0x",
        timezone = "Europe/Moscow"
    };
}
