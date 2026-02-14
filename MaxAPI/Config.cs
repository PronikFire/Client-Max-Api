using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxAPI;

public class Config
{
    [JsonInclude, JsonPropertyName("chats")]
    public Dictionary<long, object> chats;

    [JsonInclude, JsonPropertyName("server")]
    public Server server;

    [JsonInclude, JsonPropertyName("user")]
    public User user;

    [JsonInclude, JsonPropertyName("hash")]
    public string hash;

    [JsonInclude, JsonPropertyName("experiments")]
    public Experiments experiments;
}
