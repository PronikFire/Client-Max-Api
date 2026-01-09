using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class SettingsEntryBanner
{
    [JsonInclude, JsonPropertyName("icon")]
    public string icon;

    [JsonInclude, JsonPropertyName("title")]
    public string title;

    [JsonInclude, JsonPropertyName("appid")]
    public long appid;
}
