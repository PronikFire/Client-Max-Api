using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI;

public class DialogOptions
{
    [JsonInclude, JsonPropertyName("SERVICE_CHAT")]
    public bool serviceChat = false;
}
