using System.Collections.Generic;
using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Config
{
    [JsonInclude, JsonPropertyName("chats")]
    [Key("chats")]
    public Dictionary<long, object> chats;

    [JsonInclude, JsonPropertyName("server")]
    [Key("server")]
    public Server server;

    [JsonInclude, JsonPropertyName("user")]
    [Key("user")]
    public User user;

    [JsonInclude, JsonPropertyName("hash")]
    [Key("hash")]
    public string hash;

    [JsonInclude, JsonPropertyName("experiments")]
    [Key("experiments")]
    public Experiments experiments;
}
