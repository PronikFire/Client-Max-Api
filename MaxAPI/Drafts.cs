using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI;

public class Drafts
{
    [JsonInclude, JsonPropertyName("chats")]
    public object chats;

    [JsonInclude, JsonPropertyName("users")]
    public object users;
}
