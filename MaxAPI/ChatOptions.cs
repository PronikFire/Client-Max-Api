using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI;

public class ChatOptions()
{
    [JsonInclude, JsonPropertyName("SIGN_ADMIN")]
    public bool signAdmin = true;
    [JsonInclude, JsonPropertyName("OFFICIAL")]
    public bool official = true;
    [JsonInclude, JsonPropertyName("MESSAGE_COPY_NOT_ALLOWED")]
    public bool messageCopyNotAllowed = true;
    [JsonInclude, JsonPropertyName("ONLY_OWNER_CAN_CHANGE_ICON_TITLE")]
    public bool onlyOwnerCanChangeIconTitle = true;
    [JsonInclude, JsonPropertyName("ONLY_ADMIN_CAN_ADD_MEMBER")]
    public bool onlyAdminCanAddMember = true;
    [JsonInclude, JsonPropertyName("ONLY_ADMIN_CAN_CALL")]
    public bool onlyAdminCanCall = true;
    [JsonInclude, JsonPropertyName("MEMBERS_CAN_SEE_PRIVATE_LINK")]
    public bool membersCanSeePrivateLink = true;
    [JsonInclude, JsonPropertyName("SENT_BY_PHONE")]
    public bool sentByPhone = true;
    [JsonInclude, JsonPropertyName("CONTENT_LEVEL_CHAT")]
    public bool contentLevelChat = false;
    [JsonInclude, JsonPropertyName("A_PLUS_CHANNEL")]
    public bool aPlusChannel = true;
    [JsonInclude, JsonPropertyName("ALL_CAN_PIN_MESSAGE")]
    public bool allCanPinMessage = true;
}
