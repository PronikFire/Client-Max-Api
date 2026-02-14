using System.Text.Json.Serialization;

namespace MaxAPI;

public class DialogOptions
{
    [JsonInclude, JsonPropertyName("SERVICE_CHAT")]
    public bool serviceChat = false;
}
