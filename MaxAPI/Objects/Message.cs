using System;
using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Objects;

[MessagePackObject]
public partial class Message
{
    [JsonInclude, JsonPropertyName("sender")]
    [Key("sender")]
    public long Sender { get; private set; }

    [IgnoreMember]
    public DateTimeOffset UpdateTimeDT => DateTimeOffset.FromUnixTimeMilliseconds(UpdateTime);

    [JsonInclude, JsonPropertyName("updateTime")]
    [Key("updateTime")]
    public long UpdateTime { get; private set; }

    [JsonInclude, JsonPropertyName("id")]
    [Key("id")]
    public long Id { get; private set; }

    [IgnoreMember]
    public DateTimeOffset TimeDT => DateTimeOffset.FromUnixTimeMilliseconds(Time);

    [JsonInclude, JsonPropertyName("time")]
    [Key("time")]
    public long Time { get; private set; }

    [JsonInclude, JsonPropertyName("text")]
    [Key("text")]
    public string text = "";

    [JsonInclude, JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Key("type")]
    public MessageType Type { get; private set; } = MessageType.User;

    [JsonInclude, JsonPropertyName("cid")]
    [Key("cid")]
    public long Cid { get; internal set; }

    [JsonInclude, JsonPropertyName("attaches")]
    [Key("attaches")]
    public Attachment[] attaches = [];

    [JsonInclude, JsonPropertyName("elements")]
    [Key("elements")]
    public Element[] elements = [];

    [JsonInclude, JsonPropertyName("options")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Key("options")]
    public int? options;

    [JsonInclude, JsonPropertyName("link")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Key("link")]
    public Link? link;
}