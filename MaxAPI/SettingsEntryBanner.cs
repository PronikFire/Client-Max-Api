using System.Text.Json.Serialization;

namespace MaxAPI;

public class SettingsEntryBanner
{
    [JsonInclude, JsonPropertyName("icon")]
    public string icon;

    [JsonInclude, JsonPropertyName("title")]
    public string title;

    [JsonInclude, JsonPropertyName("appid")]
    public long appid;
}
