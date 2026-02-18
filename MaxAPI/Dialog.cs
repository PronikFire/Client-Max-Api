using System.Text.Json.Serialization;

namespace MaxAPI;

public class Dialog : ChatBase
{
    [JsonInclude, JsonPropertyName("prevMessageId")]
    public string? prevMessageId;
    [JsonInclude, JsonPropertyName("restrictions")]
    public int restrictions;
    [JsonInclude, JsonPropertyName("options")]
    public DialogOptions options = new();

    [JsonInclude, JsonPropertyName("type")]
    private readonly string type = "DIALOG";
}
