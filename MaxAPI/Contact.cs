using System.Text.Json.Serialization;

namespace MaxAPI;

public class Contact
{
    [JsonInclude, JsonPropertyName("webApp")]
    public string webApp = string.Empty;

    [JsonInclude, JsonPropertyName("link")]
    public string link = string.Empty;

    [JsonInclude, JsonPropertyName("gender")]
    public int gender;

    [JsonInclude, JsonPropertyName("accountStatus")]
    public int accountStatus;

    [JsonInclude, JsonPropertyName("baseUrl")]
    public string baseUrl;

    [JsonInclude, JsonPropertyName("names")]
    public Names[] names;

    [JsonInclude, JsonPropertyName("options")]
    public string[] options;

    [JsonInclude, JsonPropertyName("photoId")]
    public long photoId;

    [JsonInclude, JsonPropertyName("updateTime")]
    public long updateTime;

    [JsonInclude, JsonPropertyName("id")]
    public long id;

    [JsonInclude, JsonPropertyName("baseRawUrl")]
    public string baseRawUrl;

    [JsonIgnore, JsonPropertyName("phone")]
    public long phone;
}