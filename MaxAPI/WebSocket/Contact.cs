using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MaxAPI.WebSocket;

public class Contact
{
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

}