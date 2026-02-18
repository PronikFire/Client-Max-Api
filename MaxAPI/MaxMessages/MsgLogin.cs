using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public static class MsgLogin
{
    public const ushort OPCODE = 19;

    public struct Request(string token)
    {
        [JsonInclude, JsonPropertyName("interactive")]
        public bool interactive = true;

        [JsonInclude, JsonPropertyName("token")]
        public string token = token;

        [JsonInclude, JsonPropertyName("chatsCount")]
        public uint chatsCount = 40;

        [JsonInclude, JsonPropertyName("lastLogin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long lastLogin;

        [JsonInclude, JsonPropertyName("chatsSync")]
        public long chatsSync = 0;

        [JsonInclude, JsonPropertyName("contactsSync")]
        public uint contactsSync = 0;

        [JsonInclude, JsonPropertyName("presenceSync")]
        public int presenceSync = -1;

        [JsonInclude, JsonPropertyName("draftsSync")]
        public uint draftsSync = 0;

        [JsonInclude, JsonPropertyName("configHash")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? configHash;
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("videoChatHistory")]
        public bool videoChatHistory;

        [JsonInclude, JsonPropertyName("profile")]
        public Profile profile;

        [JsonInclude, JsonPropertyName("chats")]
        public ChatBase[] chats;

        [JsonInclude, JsonPropertyName("chatMarker")]
        public int chatMarker;

        [JsonInclude, JsonPropertyName("messages")]
        public object messages;

        [JsonInclude, JsonPropertyName("drafts")]
        public Drafts drafts;

        [JsonInclude, JsonPropertyName("time")]
        public long time;

        [JsonInclude, JsonPropertyName("presence")]
        public Dictionary<string, Presence> presenceById;

        [JsonInclude, JsonPropertyName("config")]
        public Config config;

        [JsonInclude, JsonPropertyName("contacts")]
        public object[] contacts;
    }
}