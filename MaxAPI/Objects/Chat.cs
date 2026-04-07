using MessagePack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public partial class Chat
{
    [JsonInclude, JsonPropertyName("participantsCount")]
    [Key("participantsCount")]
    public int ParticipantsCount { get; private set; }

    [JsonInclude, JsonPropertyName("access")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Key("access")]
    public ChatAccess Access { get; private set; }

    [JsonInclude, JsonPropertyName("baseRawIconUrl")]
    [Key("baseRawIconUrl")]
    public string? BaseRawIconUrl { get; private set; }

    [JsonInclude, JsonPropertyName("link")]
    [Key("link")]
    public string? Link { get; private set; }

    [JsonInclude, JsonPropertyName("description")]
    [Key("description")]
    public string Description { get; private set; }

    [JsonInclude, JsonPropertyName("title")]
    [Key("title")]
    public string Title { get; private set; }

    [JsonInclude, JsonPropertyName("adminParticipants")]
    [Key("adminParticipants")]
    public Dictionary<long, AdminParticipants> AdminParticipants { get; private set; }

    [JsonInclude, JsonPropertyName("admins")]
    [Key("admins")]
    public long[] Admins { get; private set; }

    [JsonInclude, JsonPropertyName("invitedBy")]
    [Key("invitedBy")]
    public long InvitedBy { get; private set; }

    [JsonInclude, JsonPropertyName("reactions")]
    [Key("reactions")]
    public Reactions Reactions { get; private set; }

    [JsonInclude, JsonPropertyName("subject")]
    [Key("subject")]
    public SubjectParent? Subject { get; private set; }

    [JsonInclude, JsonPropertyName("baseIconUrl")]
    [Key("baseIconUrl")]
    public string? BaseIconUrl { get; private set; }

    [JsonInclude, JsonPropertyName("blockedParticipantsCount")]
    [Key("blockedParticipantsCount")]
    public int BlockedParticipantsCount { get; private set; }

    [JsonInclude, JsonPropertyName("messagesCount")]
    [Key("messagesCount")]
    public int MessagesCount { get; private set; }

    [JsonInclude, JsonPropertyName("options")]
    [Key("options")]
    public ChatOptions Options { get; private set; }

    [JsonInclude, JsonPropertyName("hasBots")]
    [Key("hasBots")]
    public bool HasBots { get; protected set; } = false;

    [IgnoreMember]
    public DateTimeOffset LastFireDelayedErrorTime => DateTimeOffset.FromUnixTimeMilliseconds(lastFireDelayedErrorTime);

    [IgnoreMember]
    public DateTimeOffset LastDelayedUpdateTime => DateTimeOffset.FromUnixTimeMilliseconds(lastDelayedUpdateTime);

    [IgnoreMember]
    public DateTimeOffset LastEventTime => DateTimeOffset.FromUnixTimeMilliseconds(lastEventTime);

    [IgnoreMember]
    public DateTimeOffset Modified => DateTimeOffset.FromUnixTimeMilliseconds(modified);

    [JsonInclude, JsonPropertyName("pinnedMessage")]
    [Key("pinnedMessage")]
    public Message? PinnedMessage { get; protected set; }

    [JsonInclude, JsonPropertyName("id")]
    [Key("id")]
    public long Id { get; protected set; }

    [JsonInclude, JsonPropertyName("owner")]
    [Key("owner")]
    public long Owner { get; protected set; }

    [JsonInclude, JsonPropertyName("newMessages")]
    [Key("newMessages")]
    public int NewMessages { get; protected set; }

    [IgnoreMember]
    public ReadOnlyDictionary<long, long> Participants => new(participants);

    [JsonInclude, JsonPropertyName("cid")]
    [Key("cid")]
    public long Cid { get; protected set; }

    [JsonInclude, JsonPropertyName("lastMessage")]
    [Key("lastMessage")]
    public Message? LastMessage { get; protected set; }

    [IgnoreMember]
    public DateTimeOffset JoinTime => DateTimeOffset.FromUnixTimeMilliseconds(joinTime);

    [IgnoreMember]
    public DateTimeOffset Created => DateTimeOffset.FromUnixTimeMilliseconds(created);

    [JsonInclude, JsonPropertyName("videoConversation")]
    [Key("videoConversation")]
    public object? VideoConversation { get; protected set; }

    [JsonInclude, JsonPropertyName("lastFireDelayedErrorTime")]
    [Key("lastFireDelayedErrorTime")]
    public long lastFireDelayedErrorTime { get; protected set; }

    [JsonInclude, JsonPropertyName("lastDelayedUpdateTime")]
    [Key("lastDelayedUpdateTime")]
    public long lastDelayedUpdateTime { get; protected set; }

    [JsonInclude, JsonPropertyName("lastEventTime")]
    [Key("lastEventTime")]
    public long lastEventTime { get; protected set; }

    [JsonInclude, JsonPropertyName("modified")]
    [Key("modified")]
    public long modified { get; protected set; }

    [JsonInclude, JsonPropertyName("joinTime")]
    [Key("joinTime")]
    public long joinTime { get; protected set; }

    [JsonInclude, JsonPropertyName("created")]
    [Key("created")]
    public long created { get; protected set; }

    [JsonInclude, JsonPropertyName("participants")]
    [Key("participants")]
    public Dictionary<long, long> participants = [];

    [JsonInclude, JsonPropertyName("prevMessageId")]
    [Key("prevMessageId")]
    public long PrevMessageId { get; private set; }

    [JsonInclude, JsonPropertyName("restrictions")]
    [Key("restrictions")]
    public int Restrictions { get; private set; }

    [JsonInclude, JsonPropertyName("type")]
    [Key("type")]
    public ChatType type;
}