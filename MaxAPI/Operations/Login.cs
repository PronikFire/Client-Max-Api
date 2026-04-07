using MaxAPI.Objects;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Operations;

public static class Login
{
    public const ushort OPCODE = 19;

    [MessagePackObject]
    public struct Request(string token)
    {
        [JsonInclude, JsonPropertyName("interactive")]
        [Key("interactive")]
        public bool interactive = true;

        [JsonInclude, JsonPropertyName("token")]
        [Key("token")]
        public string token = token;

        [JsonInclude, JsonPropertyName("chatsCount")]
        [Key("chatsCount")]
        public int chatsCount = 40;

        [JsonInclude, JsonPropertyName("LastLogin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Key("LastLogin")]
        public long lastLogin;

        [JsonInclude, JsonPropertyName("chatsSync")]
        [Key("chatsSync")]
        public long chatsSync = 0;

        [JsonInclude, JsonPropertyName("contactsSync")]
        [Key("contactsSync")]
        public uint contactsSync = 0;

        [JsonInclude, JsonPropertyName("presenceSync")]
        [Key("presenceSync")]
        public long presenceSync = -1;

        [JsonInclude, JsonPropertyName("draftsSync")]
        [Key("draftsSync")]
        public long draftsSync = 0;

        [JsonInclude, JsonPropertyName("configHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [Key("configHash")]
        public string? configHash;

        [JsonInclude, JsonPropertyName("userAgent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [Key("userAgent")]
        public UserAgent? userAgent;

        [JsonInclude, JsonPropertyName("bannerSync")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Key("bannerSync")]
        public long bannerSync;
    }

    [MessagePackObject]
    public struct Response
    {
        [JsonInclude, JsonPropertyName("videoChatHistory")]
        [Key("videoChatHistory")]
        public bool videoChatHistory;

        [JsonInclude, JsonPropertyName("profile")]
        [Key("profile")]
        public Objects.Profile profile;

        [JsonInclude, JsonPropertyName("chats")]
        [Key("chats")]
        public Chat[] chats;

        [JsonInclude, JsonPropertyName("chatMarker")]
        [Key("chatMarker")]
        public int chatMarker;

        [JsonInclude, JsonPropertyName("messages")]
        [Key("messages")]
        public object messages;

        [JsonInclude, JsonPropertyName("drafts")]
        [Key("drafts")]
        public Drafts drafts;

        [JsonInclude, JsonPropertyName("time")]
        [Key("time")]
        public long time;

        [JsonInclude, JsonPropertyName("presence")]
        [Key("presence")]
        public Dictionary<string, Presence> presenceById;

        [JsonInclude, JsonPropertyName("config")]
        [Key("config")]
        public Config config;

        [JsonInclude, JsonPropertyName("contacts")]
        [Key("contacts")]
        public Contact[] contacts;

        [JsonInclude, JsonPropertyName("token")]
        [Key("token")]
        public string? token;

        [JsonInclude, JsonPropertyName("resetAt")]
        [Key("resetAt")]
        public long resetAt;
    }
}