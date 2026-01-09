using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class BotContact : Contact
{
    [JsonInclude, JsonPropertyName("webApp")]
    public string webApp = string.Empty;
    [JsonInclude, JsonPropertyName("link")]
    public string link = string.Empty;
    [JsonInclude, JsonPropertyName("gender")]
    public int gender;
}
