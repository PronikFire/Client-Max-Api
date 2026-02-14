using System.Text.Json.Serialization;

namespace MaxAPI;

public class Message
{
    [JsonInclude, JsonPropertyName("sender")]
    public long sender;

    [JsonInclude, JsonPropertyName("updateTime")]
    public long updateTime;

    [JsonInclude, JsonPropertyName("id")]
    public string id;

    [JsonInclude, JsonPropertyName("time")]
    public long time;

    [JsonInclude, JsonPropertyName("text")]
    public string text;

    [JsonInclude, JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MessageType type;

    [JsonInclude, JsonPropertyName("cid")]
    public long cid;

    [JsonInclude, JsonPropertyName("attaches")]
    public Attachment[] attaches;

    [JsonInclude, JsonPropertyName("elements")]
    public Element[] elements;

    [JsonInclude, JsonPropertyName("options")]
    public int? options;

    [JsonInclude, JsonPropertyName("link")]
    public Link link;
}
