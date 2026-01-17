using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI;

public class CallRate
{
    [JsonInclude, JsonPropertyName("limit")]
    public int limit;

    [JsonInclude, JsonPropertyName("duration")]
    public int duration;

    [JsonInclude, JsonPropertyName("sdk-limit")]
    public int sdklimit;

    [JsonInclude, JsonPropertyName("delay")]
    public int delay;
}
