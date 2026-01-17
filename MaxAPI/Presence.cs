using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI;

public class Presence
{
    [JsonInclude, JsonPropertyName("seen")]
    public long seen;
    [JsonInclude, JsonPropertyName("status")]
    public int status;
}
