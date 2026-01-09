using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public struct Names()
{
    [JsonPropertyName("name")]
    public string name = string.Empty;

    [JsonPropertyName("firstName")]
    public string firstName = string.Empty;

    [JsonPropertyName("lastName")]
    public string lastName = string.Empty;

    [JsonPropertyName("type")]
    public string type = string.Empty;
}