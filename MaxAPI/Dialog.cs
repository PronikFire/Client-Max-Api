using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
