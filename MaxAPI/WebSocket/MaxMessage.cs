using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public struct MaxMessage() 
{
    [JsonInclude, JsonPropertyName("ver")]
    public byte version = 11;
    [JsonInclude, JsonPropertyName("cmd")]
    public CmdType cmd = CmdType.Request;
    [JsonInclude, JsonPropertyName("seq")]
    public ushort seq = 0;
    [JsonInclude, JsonPropertyName("opcode")]
    public ushort opcode = 0;
    [JsonInclude, JsonPropertyName("payload")]
    public object? payload = null;
}
