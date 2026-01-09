using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class Experiments
{
    [JsonInclude, JsonPropertyName("app.ab.test.exp")]
    public bool appAbTestExp = false;
}
