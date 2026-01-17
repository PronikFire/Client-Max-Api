using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.MaxMessages;

public static class MsgLogin
{
    public const ushort OPCODE = 19;

    public struct Request(string token)
    {
        [JsonInclude, JsonPropertyName("interactive")]
        public bool interactive = true;

        [JsonInclude, JsonPropertyName("token")]
        public readonly string token = token;

        [JsonInclude, JsonPropertyName("chatsCount")]
        public uint chatsCount = 40;

        [JsonInclude, JsonPropertyName("chatsSync")]
        public uint chatsSync = 0;

        [JsonInclude, JsonPropertyName("contactsSync")]
        public uint contactsSync = 0;

        [JsonInclude, JsonPropertyName("presenceSync")]
        public int presenceSync = -1;

        [JsonInclude, JsonPropertyName("draftsSync")]
        public uint draftsSync = 0;
    }

    public struct Response
    {
        [JsonInclude, JsonPropertyName("videoChatHistory")]
        public bool videoChatHistory;

        [JsonInclude, JsonPropertyName("profile")]
        public Profile profile;

        [JsonInclude, JsonPropertyName("chats")]
        public Chat[] chats;

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