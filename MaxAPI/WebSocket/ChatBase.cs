using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(Chat), "CHAT")]
[JsonDerivedType(typeof(Dialog), "DIALOG")]
public abstract class ChatBase
{
    public DateTime LastFireDelayedErrorTime => DateTime.FromBinary(lastFireDelayedErrorTime);
    public DateTime LastDelayedUpdateTime => DateTime.FromBinary(lastDelayedUpdateTime);
    public DateTime LastModifiedTime => DateTime.FromBinary(modified);

    [JsonInclude, JsonPropertyName("hasBots")]
    public bool hasBots = false;
    [JsonInclude, JsonPropertyName("lastFireDelayedErrorTime")]
    private long lastFireDelayedErrorTime;
    [JsonInclude, JsonPropertyName("lastDelayedUpdateTime")]
    private long lastDelayedUpdateTime;
    [JsonInclude, JsonPropertyName("lastEventTime")]
    public long lastEventTime;
    [JsonInclude, JsonPropertyName("modified")]
    private long modified;
    [JsonInclude, JsonPropertyName("pinnedMessage")]
    public object? pinnedMessage;
    [JsonInclude, JsonPropertyName("id")]
    public long id;
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
