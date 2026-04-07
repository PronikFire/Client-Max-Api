using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Contact
{
    [JsonInclude, JsonPropertyName("webApp")]
    [Key("webApp")]
    public string webApp = string.Empty;

    [JsonInclude, JsonPropertyName("link")]
    [Key("link")]
    public string link = string.Empty;

    [JsonInclude, JsonPropertyName("gender")]
    [Key("gender")]
    public int gender;

    [JsonInclude, JsonPropertyName("accountStatus")]
    [Key("accountStatus")]
    public int accountStatus;

    [JsonInclude, JsonPropertyName("baseUrl")]
    [Key("baseUrl")]
    public string baseUrl;

    [JsonInclude, JsonPropertyName("names")]
    [Key("names")] 
    public Name[] names;

    [JsonInclude, JsonPropertyName("options")]
    [Key("options")] 
    public string[] options;

    [JsonInclude, JsonPropertyName("photoId")]
    [Key("photoId")] 
    public long photoId;

    [JsonInclude, JsonPropertyName("updateTime")]
    [Key("updateTime")] 
    public long updateTime;

    [JsonInclude, JsonPropertyName("id")]
    [Key("id")] 
    public long id;

    [JsonInclude, JsonPropertyName("baseRawUrl")]
    [Key("baseRawUrl")] 
    public string baseRawUrl;

    [JsonIgnore, JsonPropertyName("phone")]
    [Key("phone")] 
    public long phone;
}