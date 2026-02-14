using System.Text.Json.Serialization;

namespace MaxAPI;

public class Dialog : ChatBase
{
    [JsonInclude, JsonPropertyName("prevMessageId")]
    public long prevMessageId;
    [JsonInclude, JsonPropertyName("restrictions")]
    public int restrictions;
    [JsonInclude, JsonPropertyName("options")]
    public DialogOptions options = new();
}
