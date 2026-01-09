using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class Link
{
    [JsonInclude, JsonPropertyName("type")]
    public string type;

    [JsonInclude, JsonPropertyName("message")]
    public Message message;

    [JsonInclude, JsonPropertyName("chatId")]
    public long chatId;
}
