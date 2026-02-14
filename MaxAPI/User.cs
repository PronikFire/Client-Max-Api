using System.Text.Json.Serialization;

namespace MaxAPI;

public class User
{
    [JsonInclude, JsonPropertyName("CHATS_PUSH_NOTIFICATION")]
    public string CHATS_PUSH_NOTIFICATION;

    [JsonInclude, JsonPropertyName("PUSH_DETAILS")]
    public bool PUSH_DETAILS;

    [JsonInclude, JsonPropertyName("PUSH_SOUND")]
    public string PUSH_SOUND;

    [JsonInclude, JsonPropertyName("INACTIVE_TTL")]
    public string INACTIVE_TTL;

    [JsonInclude, JsonPropertyName("SHOW_READ_MARK")]
    public bool SHOW_READ_MARK;

    [JsonInclude, JsonPropertyName("AUDIO_TRANSCRIPTION_ENABLED")]
    public bool AUDIO_TRANSCRIPTION_ENABLED;

    [JsonInclude, JsonPropertyName("SEARCH_BY_PHONE")]
    public string SEARCH_BY_PHONE;

    [JsonInclude, JsonPropertyName("INCOMING_CALL")]
    public string INCOMING_CALL;

    [JsonInclude, JsonPropertyName("DOUBLE_TAP_REACTION_DISABLED")]
    public bool DOUBLE_TAP_REACTION_DISABLED;

    [JsonInclude, JsonPropertyName("SAFE_MODE_NO_PIN")]
    public bool SAFE_MODE_NO_PIN;

    [JsonInclude, JsonPropertyName("CHATS_PUSH_SOUND")]
    public string CHATS_PUSH_SOUND;

    [JsonInclude, JsonPropertyName("DOUBLE_TAP_REACTION_VALUE")]
    public object? DOUBLE_TAP_REACTION_VALUE;

    [JsonInclude, JsonPropertyName("FAMILY_PROTECTION")]
    public string FAMILY_PROTECTION;

    [JsonInclude, JsonPropertyName("HIDDEN")]
    public bool HIDDEN;

    [JsonInclude, JsonPropertyName("CHATS_INVITE")]
    public string CHATS_INVITE;

    [JsonInclude, JsonPropertyName("PUSH_NEW_CONTACTS")]
    public bool PUSH_NEW_CONTACTS;

    [JsonInclude, JsonPropertyName("UNSAFE_FILES")]
    public bool UNSAFE_FILES;

    [JsonInclude, JsonPropertyName("DONT_DISTURB_UNTIL")]
    public int DONT_DISTURB_UNTIL;

    [JsonInclude, JsonPropertyName("ALT_KEYBOARD")]
    public bool ALT_KEYBOARD;

    [JsonInclude, JsonPropertyName("CONTENT_LEVEL_ACCESS")]
    public bool CONTENT_LEVEL_ACCESS;

    [JsonInclude, JsonPropertyName("STICKERS_SUGGEST")]
    public string STICKERS_SUGGEST;

    [JsonInclude, JsonPropertyName("SAFE_MODE")]
    public bool SAFE_MODE;

    [JsonInclude, JsonPropertyName("M_CALL_PUSH_NOTIFICATION")]
    public string M_CALL_PUSH_NOTIFICATION;
}
