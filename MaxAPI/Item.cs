using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI;

public class Item
{
    [JsonInclude, JsonPropertyName("icon")]
    public string icon;

    [JsonInclude, JsonPropertyName("title")]
    public string title;

    [JsonInclude, JsonPropertyName("id")]
    public long id;
}
