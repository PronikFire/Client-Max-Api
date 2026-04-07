using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class ChatOptions
{
    [JsonInclude, JsonPropertyName("SIGN_ADMIN")]
    [Key("SIGN_ADMIN")]
    public bool signAdmin = true;

    [JsonInclude, JsonPropertyName("OFFICIAL")]
    [Key("OFFICIAL")]
    public bool official = true;

    [JsonInclude, JsonPropertyName("MESSAGE_COPY_NOT_ALLOWED")]
    [Key("MESSAGE_COPY_NOT_ALLOWED")]
    public bool messageCopyNotAllowed = true;

    [JsonInclude, JsonPropertyName("ONLY_OWNER_CAN_CHANGE_ICON_TITLE")]
    [Key("ONLY_OWNER_CAN_CHANGE_ICON_TITLE")]
    public bool onlyOwnerCanChangeIconTitle = true;

    [JsonInclude, JsonPropertyName("ONLY_ADMIN_CAN_ADD_MEMBER")]
    [Key("ONLY_ADMIN_CAN_ADD_MEMBER")]
    public bool onlyAdminCanAddMember = true;

    [JsonInclude, JsonPropertyName("ONLY_ADMIN_CAN_CALL")]
    [Key("ONLY_ADMIN_CAN_CALL")]
    public bool onlyAdminCanCall = true;

    [JsonInclude, JsonPropertyName("MEMBERS_CAN_SEE_PRIVATE_LINK")]
    [Key("MEMBERS_CAN_SEE_PRIVATE_LINK")]
    public bool membersCanSeePrivateLink = true;

    [JsonInclude, JsonPropertyName("SENT_BY_PHONE")]
    [Key("SENT_BY_PHONE")]
    public bool sentByPhone = true;

    [JsonInclude, JsonPropertyName("CONTENT_LEVEL_CHAT")]
    [Key("CONTENT_LEVEL_CHAT")]
    public bool contentLevelChat = false;

    [JsonInclude, JsonPropertyName("A_PLUS_CHANNEL")]
    [Key("A_PLUS_CHANNEL")]
    public bool aPlusChannel = true;

    [JsonInclude, JsonPropertyName("ALL_CAN_PIN_MESSAGE")]
    [Key("ALL_CAN_PIN_MESSAGE")]
    public bool allCanPinMessage = true;

    [JsonInclude, JsonPropertyName("SERVICE_CHAT")]
    [Key("SERVICE_CHAT")]
    public bool serviceChat = false;
}