using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Attachment
{
    [JsonInclude, JsonPropertyName("image")]
    [Key("image")]
    public Image image;

    [JsonInclude, JsonPropertyName("_type")]
    [Key("_type")]
    public string _type;

    [JsonInclude, JsonPropertyName("host")]
    [Key("host")]
    public string host;

    [JsonInclude, JsonPropertyName("description")]
    [Key("description")]
    public string description;

    [JsonInclude, JsonPropertyName("contentLevel")]
    [Key("contentLevel")]
    public bool contentLevel;

    [JsonInclude, JsonPropertyName("shareId")]
    [Key("shareId")]
    public long shareId;

    [JsonInclude, JsonPropertyName("title")]
    [Key("title")]
    public string title;

    [JsonInclude, JsonPropertyName("url")]
    [Key("url")]
    public string url;

    [JsonInclude, JsonPropertyName("keyboard")]
    [Key("keyboard")]
    public Keyboard keyboard;

    [JsonInclude, JsonPropertyName("callbackId")]
    [Key("callbackId")]
    public string callbackId;

    [JsonInclude, JsonPropertyName("event")]
    [Key("event")]
    public string _event;

    [JsonInclude, JsonPropertyName("userIds")]
    [Key("userIds")]
    public long[] userIds;

    [JsonInclude, JsonPropertyName("userId")]
    [Key("userId")]
    public long? userId;

    [JsonInclude, JsonPropertyName("previewData")]
    [Key("previewData")]
    public byte[] previewData;

    [JsonInclude, JsonPropertyName("baseUrl")]
    [Key("baseUrl")]
    public string baseUrl;

    [JsonInclude, JsonPropertyName("photoToken")]
    [Key("photoToken")]
    public string photoToken;

    [JsonInclude, JsonPropertyName("width")]
    [Key("width")]
    public int? width;

    [JsonInclude, JsonPropertyName("photoId")]
    [Key("photoId")]
    public long? photoId;

    [JsonInclude, JsonPropertyName("height")]
    [Key("height")]
    public int? height;

    [JsonInclude, JsonPropertyName("duration")]
    [Key("duration")]
    public int? duration;

    [JsonInclude, JsonPropertyName("thumbnail")]
    [Key("thumbnail")]
    public string thumbnail;

    [JsonInclude, JsonPropertyName("videoType")]
    [Key("videoType")]
    public int? videoType;

    [JsonInclude, JsonPropertyName("videoId")]
    [Key("videoId")]
    public long? videoId;

    [JsonInclude, JsonPropertyName("token")]
    [Key("token")]
    public string token;
}