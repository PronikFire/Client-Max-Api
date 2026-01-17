using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MaxAPI;

public class Element
{
    [JsonInclude, JsonPropertyName("length")]
    public int length;

    [JsonInclude, JsonPropertyName("from")]
    public int from;

    [JsonInclude, JsonPropertyName("attributes")]
    public ElementAttributes attributes;

    [JsonInclude, JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ElementType type;
}
