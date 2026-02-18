using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxAPI;

public class Chat : ChatBase
{
    [JsonInclude, JsonPropertyName("participantsCount")]
    public int participantsCount;

    [JsonInclude, JsonPropertyName("access"), JsonConverter(typeof(JsonStringEnumConverter))]
    public ChatAccess access;

    [JsonInclude, JsonPropertyName("baseRawIconUrl")]
    public string? baseRawIconUrl;

    [JsonInclude, JsonPropertyName("link")]
    public string? link;

    [JsonInclude, JsonPropertyName("description")]
    public string description = string.Empty;

    [JsonInclude, JsonPropertyName("title")]
    public string title = string.Empty;

    [JsonInclude, JsonPropertyName("adminParticipants")]
    public Dictionary<string, AdminParticipants> adminParticipants = [];

    [JsonInclude, JsonPropertyName("admins")]
    public long[] admins = [];

    [JsonInclude, JsonPropertyName("invitedBy")]
    public long invitedBy;

    [JsonInclude, JsonPropertyName("reactions")]
    public Reactions reactions = new();

    [JsonInclude, JsonPropertyName("subject")]
    public SubjectParent? subject;

    [JsonInclude, JsonPropertyName("baseIconUrl")]
    public string? baseIconUrl;

    [JsonInclude, JsonPropertyName("blockedParticipantsCount")]
    public int blockedParticipantsCount;

    [JsonInclude, JsonPropertyName("videoConversation")]
    public object? videoConversation;

    [JsonInclude, JsonPropertyName("messagesCount")]
    public int messagesCount;

    [JsonInclude, JsonPropertyName("options")]
    public ChatOptions options = new();

    [JsonInclude, JsonPropertyName("type")]
    private readonly string type = "CHAT";
}
