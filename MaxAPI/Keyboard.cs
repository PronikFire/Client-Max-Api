using System.Text.Json.Serialization;

namespace MaxAPI;

public class Keyboard
{
    [JsonInclude, JsonPropertyName("buttons")]
    public Button[][] buttons = [];

    public class Button
    {
        [JsonInclude, JsonPropertyName("text")]
        public string text;
        [JsonInclude, JsonPropertyName("type")]
        public string type;
        [JsonInclude, JsonPropertyName("payload")]
        public string payload;
        [JsonInclude, JsonPropertyName("intent")]
        public string intent;
        [JsonInclude, JsonPropertyName("url")]
        public string url;
    }
}
