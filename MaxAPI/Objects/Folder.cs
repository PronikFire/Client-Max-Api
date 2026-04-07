using MessagePack;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Folder
{
    [JsonInclude, JsonPropertyName("sourceId")]
    [Key("sourceId")]
    public long sourceId;

    [JsonInclude, JsonPropertyName("options")]
    [Key("options")]
    public int[] options;

    [JsonInclude, JsonPropertyName("updateTime")]
    [Key("updateTime")]
    public long updateTime;

    [JsonInclude, JsonPropertyName("id")]
    [Key("id")]
    public string id;

    [JsonInclude, JsonPropertyName("filters")]
    [Key("filters")]
    public int[] filters;

    [JsonInclude, JsonPropertyName("title")]
    [Key("title")]
    public string title;

    [JsonInclude, JsonPropertyName("include")]
    [Key("include")]
    public long[] include;

    [JsonInclude, JsonPropertyName("filterSubjects")]
    [Key("filterSubjects")]
    public Dictionary<string, long[]> filterSubjects;

    [JsonInclude, JsonPropertyName("elements")]
    [Key("elements")]
    public List<Element> elements;

    [JsonInclude, JsonPropertyName("widgets")]
    [Key("widgets")]
    public List<Widget> widgets;
}