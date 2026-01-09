using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class Attachment
{
    [JsonInclude, JsonPropertyName("image")]
    public Image image;

    [JsonInclude, JsonPropertyName("_type")]
    public string _type;

    [JsonInclude, JsonPropertyName("host")]
    public string host;

    [JsonInclude, JsonPropertyName("description")]
    public string description;

    [JsonInclude, JsonPropertyName("contentLevel")]
    public bool contentLevel;

    [JsonInclude, JsonPropertyName("shareId")]
    public long shareId;

    [JsonInclude, JsonPropertyName("title")]
    public string title;

    [JsonInclude, JsonPropertyName("url")]
    public string url;

    [JsonInclude, JsonPropertyName("keyboard")]
    public Keyboard keyboard;

    [JsonInclude, JsonPropertyName("callbackId")]
    public string callbackId;

    [JsonInclude, JsonPropertyName("event")]
    public string @event;

    [JsonInclude, JsonPropertyName("userIds")]
    public long[] userIds;

    [JsonInclude, JsonPropertyName("userId")]
    public long? userId;

    [JsonInclude, JsonPropertyName("previewData")]
    public string previewData;

    [JsonInclude, JsonPropertyName("baseUrl")]
    public string baseUrl;

    [JsonInclude, JsonPropertyName("photoToken")]
    public string photoToken;

    [JsonInclude, JsonPropertyName("width")]
    public int? width;

    [JsonInclude, JsonPropertyName("photoId")]
    public long? photoId;

    [JsonInclude, JsonPropertyName("height")]
    public int? height;

    [JsonInclude, JsonPropertyName("duration")]
    public int? duration;

    [JsonInclude, JsonPropertyName("thumbnail")]
    public string thumbnail;

    [JsonInclude, JsonPropertyName("videoType")]
    public int? videoType;

    [JsonInclude, JsonPropertyName("videoId")]
    public long? videoId;

    [JsonInclude, JsonPropertyName("token")]
    public string token;

}
