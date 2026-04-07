using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Keyboard
{
    [JsonInclude, JsonPropertyName("buttons")]
    [Key("buttons")]
    public Button[][] buttons = [];

    [MessagePackObject]
    public class Button
    {
        [JsonInclude, JsonPropertyName("text")]
        [Key("text")]
        public string text;
        [JsonInclude, JsonPropertyName("type")]
        [Key("type")]
        public string type;
        [JsonInclude, JsonPropertyName("payload")]
        [Key("payload")]
        public string payload;
        [JsonInclude, JsonPropertyName("intent")]
        [Key("intent")]
        public string intent;
        [JsonInclude, JsonPropertyName("url")]
        [Key("url")]
        public string url;
    }
}
