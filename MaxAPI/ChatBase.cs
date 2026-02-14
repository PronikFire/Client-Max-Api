using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxAPI;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Chat), "CHAT")]
[JsonDerivedType(typeof(Dialog), "DIALOG")]
public abstract class ChatBase
{
    [JsonIgnore]
    public long Id => id;
    [JsonIgnore]
    public Message? PinnedMessage => pinnedMessage;
    [JsonIgnore]
    public bool HasBots => hasBots;
    [JsonIgnore]
    public DateTime LastFireDelayedErrorTime => DateTimeOffset.FromUnixTimeMilliseconds(lastFireDelayedErrorTime).DateTime;
    [JsonIgnore]
    public DateTime LastDelayedUpdateTime => DateTimeOffset.FromUnixTimeMilliseconds(lastDelayedUpdateTime).DateTime;
    [JsonIgnore]
    public DateTime LastModifiedTime => DateTimeOffset.FromUnixTimeMilliseconds(modified).DateTime;
    [JsonIgnore]
    public DateTime LastEventTime => DateTimeOffset.FromUnixTimeMilliseconds(lastEventTime).DateTime;

    [JsonInclude, JsonPropertyName("hasBots")]
    private bool hasBots = false;
    [JsonInclude, JsonPropertyName("lastFireDelayedErrorTime")]
    private long lastFireDelayedErrorTime;
    [JsonInclude, JsonPropertyName("lastDelayedUpdateTime")]
    private long lastDelayedUpdateTime;
    [JsonInclude, JsonPropertyName("lastEventTime")]
    private long lastEventTime;
    [JsonInclude, JsonPropertyName("modified")]
    private long modified;
    [JsonInclude, JsonPropertyName("pinnedMessage")]
    private Message? pinnedMessage;
    [JsonInclude, JsonPropertyName("id")]
    private long id;
    [JsonInclude, JsonPropertyName("owner")]
    public long owner;
    [JsonInclude, JsonPropertyName("newMessages")]
    public int newMessages;
    [JsonInclude, JsonPropertyName("participants")]
    public Dictionary<string, long> participants = [];
    [JsonInclude, JsonPropertyName("cid")]
    public long cid;
    [JsonInclude, JsonPropertyName("lastMessage")]
    public Message lastMessage;
    [JsonInclude, JsonPropertyName("joinTime")]
    public long joinTime;
    [JsonInclude, JsonPropertyName("created")]
    public long created;
}
