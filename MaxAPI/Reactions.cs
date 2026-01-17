using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI;

public class Reactions
{
    [JsonInclude, JsonPropertyName("isActive")]
    public bool isActive;

    [JsonInclude, JsonPropertyName("updateTime")]
    public long updateTime;
}

