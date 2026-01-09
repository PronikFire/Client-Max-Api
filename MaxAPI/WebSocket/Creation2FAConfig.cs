using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class Creation2FAConfig
{
    [JsonInclude, JsonPropertyName("pass_min_len")]
    public int pass_min_len;

    [JsonInclude, JsonPropertyName("pass_max_len")]
    public int pass_max_len;

    [JsonInclude, JsonPropertyName("hint_max_len")]
    public int hint_max_len;

    [JsonInclude, JsonPropertyName("enabled")]
    public bool enabled;
}
