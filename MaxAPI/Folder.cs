using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxAPI;

public class Folder
{
    [JsonInclude, JsonPropertyName("sourceId")]
    public long sourceId;

    [JsonInclude, JsonPropertyName("options")]
    public int[] options;

    [JsonInclude, JsonPropertyName("updateTime")]
    public long updateTime;

    [JsonInclude, JsonPropertyName("id")]
    public string id;

    [JsonInclude, JsonPropertyName("filters")]
    public int[] filters;

    [JsonInclude, JsonPropertyName("title")]
    public string title;

    [JsonInclude, JsonPropertyName("include")]
    public long[] include;

    [JsonInclude, JsonPropertyName("filterSubjects")]
    public Dictionary<string, long[]> filterSubjects;

    [JsonInclude, JsonPropertyName("elements")]
    public List<Element> elements;

    [JsonInclude, JsonPropertyName("widgets")]
    public List<Widget> widgets;
}
