using MessagePack;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackObject]
public class Server
{
    [JsonInclude, JsonPropertyName("money-transfer-botid")]
    [Key("money-transfer-botid")]
    public long moneyTransferBotId;

    [JsonInclude, JsonPropertyName("set-unread-timeout")]
    [Key("set-unread-timeout")]
    public int setUnreadTimeout;

    [JsonInclude, JsonPropertyName("account-removal-enabled")]
    [Key("account-removal-enabled")]
    public bool accountRemovalEnabled;

    [JsonInclude, JsonPropertyName("appearance-multi-theme-screen-enabled")]
    [Key("appearance-multi-theme-screen-enabled")]
    public bool appearanceMultiThemeScreenEnabled;

    [JsonInclude, JsonPropertyName("gce")]
    [Key("gce")]
    public bool gce;

    [JsonInclude, JsonPropertyName("group-call-chat-support")]
    [Key("group-call-chat-support")]
    public bool groupCallChatSupport;

    [JsonInclude, JsonPropertyName("call-rate")]
    [Key("call-rate")]
    public CallRate callRate;

    [JsonInclude, JsonPropertyName("image-size")]
    [Key("image-size")]
    public int imageSize;

    [JsonInclude, JsonPropertyName("gcce")]
    [Key("gcce")]
    public bool gcce;

    [JsonInclude, JsonPropertyName("max-video-duration-download")]
    [Key("max-video-duration-download")]
    public int maxVideoDurationDownload;

    [JsonInclude, JsonPropertyName("max-msg-length")]
    [Key("max-msg-length")]
    public int maxMsgLength;

    [JsonInclude, JsonPropertyName("markdown-menu")]
    [Key("markdown-menu")]
    public int markdownMenu;

    [JsonInclude, JsonPropertyName("async-tracer")]
    [Key("async-tracer")]
    public double asyncTracer;

    [JsonInclude, JsonPropertyName("image-width")]
    [Key("image-width")]
    public int imageWidth;

    [JsonInclude, JsonPropertyName("invite-by-link-screen")]
    [Key("invite-by-link-screen")]
    public bool inviteByLinkScreen;

    [JsonInclude, JsonPropertyName("calls-endpoint")]
    [Key("calls-endpoint")]
    public string callsEndpoint;

    [JsonInclude, JsonPropertyName("send-location-enabled")]
    [Key("send-location-enabled")]
    public bool sendLocationEnabled;

    [JsonInclude, JsonPropertyName("gc-from-p2p")]
    [Key("gc-from-p2p")]
    public bool gcFromP2P;

    [JsonInclude, JsonPropertyName("max-theme-length")]
    [Key("max-theme-length")]
    public int maxThemeLength;

    [JsonInclude, JsonPropertyName("callDontUseVpnForRtp")]
    [Key("callDontUseVpnForRtp")]
    public bool callDontUseVpnForRtp;

    [JsonInclude, JsonPropertyName("lgce")]
    [Key("lgce")]
    public bool lgce;

    [JsonInclude, JsonPropertyName("msg-get-reactions-page-size")]
    [Key("msg-get-reactions-page-size")]
    public int msgGetReactionsPageSize;

    [JsonInclude, JsonPropertyName("js-download-delegate")]
    [Key("js-download-delegate")]
    public bool jsDownloadDelegate;

    [JsonInclude, JsonPropertyName("wud")]
    [Key("wud")]
    public bool wud;

    [JsonInclude, JsonPropertyName("video-msg-enabled")]
    [Key("video-msg-enabled")]
    public bool videoMsgEnabled;

    [JsonInclude, JsonPropertyName("grse")]
    [Key("grse")]
    public bool grse;

    [JsonInclude, JsonPropertyName("post-link-enabled")]
    [Key("post-link-enabled")]
    public bool postLinkEnabled;

    [JsonInclude, JsonPropertyName("edit-timeout")]
    [Key("edit-timeout")]
    public int editTimeout;

    [JsonInclude, JsonPropertyName("reactions-max")]
    [Key("reactions-max")]
    public int reactionsMax;

    [JsonInclude, JsonPropertyName("views-count-enabled")]
    [Key("views-count-enabled")]
    public bool viewsCountEnabled;

    [JsonInclude, JsonPropertyName("typing-enabled-FILE")]
    [Key("typing-enabled-FILE")]
    public bool typingEnabledFile;

    [JsonInclude, JsonPropertyName("lebedev-theme-enabled")]
    [Key("lebedev-theme-enabled")]
    public bool lebedevThemeEnabled;

    [JsonInclude, JsonPropertyName("max-participants")]
    [Key("max-participants")]
    public int maxParticipants;

    [JsonInclude, JsonPropertyName("audio-transcription-locales")]
    [Key("audio-transcription-locales")]
    public object[] audioTranscriptionLocales;

    [JsonInclude, JsonPropertyName("welcome-sticker-ids")]
    [Key("welcome-sticker-ids")]
    public long[] welcomeStickerIds;

    [JsonInclude, JsonPropertyName("file-preview")]
    [Key("file-preview")]
    public bool filePreview;

    [JsonInclude, JsonPropertyName("new-admin-permissions")]
    [Key("new-admin-permissions")]
    public bool newAdminPermissions;

    [JsonInclude, JsonPropertyName("invite-long")]
    [Key("invite-long")]
    public string inviteLong;

    [JsonInclude, JsonPropertyName("max-favorite-sticker-sets")]
    [Key("max-favorite-sticker-sets")]
    public int maxFavoriteStickerSets;

    [JsonInclude, JsonPropertyName("moscow-theme-enabled")]
    [Key("moscow-theme-enabled")]
    public bool moscowThemeEnabled;

    [JsonInclude, JsonPropertyName("chats-folder-enabled")]
    [Key("chats-folder-enabled")]
    public bool chatsFolderEnabled;

    [JsonInclude, JsonPropertyName("chat-invite-link-permissions-enabled")]
    [Key("chat-invite-link-permissions-enabled")]
    public bool chatInviteLinkPermissionsEnabled;

    [JsonInclude, JsonPropertyName("cfs")]
    [Key("cfs")]
    public bool cfs;

    [JsonInclude, JsonPropertyName("callEnableIceRenomination")]
    [Key("callEnableIceRenomination")]
    public bool callEnableIceRenomination;

    [JsonInclude, JsonPropertyName("mentions-enabled")]
    [Key("mentions-enabled")]
    public bool mentionsEnabled;

    [JsonInclude, JsonPropertyName("double-tap-reaction")]
    [Key("double-tap-reaction")]
    public string doubleTapReaction;

    [JsonInclude, JsonPropertyName("image-quality")]
    [Key("image-quality")]
    public double imageQuality;

    [JsonInclude, JsonPropertyName("rename-settings-to-profile")]
    [Key("rename-settings-to-profile")]
    public bool renameSettingsToProfile;

    [JsonInclude, JsonPropertyName("max-audio-length")]
    [Key("max-audio-length")]
    public int maxAudioLength;

    [JsonInclude, JsonPropertyName("settings-entry-banners")]
    [Key("settings-entry-banners")]
    public SettingsEntryBanner[] settingsEntryBanners;

    [JsonInclude, JsonPropertyName("invite-short")]
    [Key("invite-short")]
    public string inviteShort;

    [JsonInclude, JsonPropertyName("official-org")]
    [Key("official-org")]
    public bool officialOrg;

    [JsonInclude, JsonPropertyName("channels-enabled")]
    [Key("channels-enabled")]
    public bool channelsEnabled;

    [JsonInclude, JsonPropertyName("unsafe-files-alert")]
    [Key("unsafe-files-alert")]
    public bool unsafeFilesAlert;

    [JsonInclude, JsonPropertyName("min-image-side-size")]
    [Key("min-image-side-size")]
    public int minImageSideSize;

    [JsonInclude, JsonPropertyName("account-nickname-enabled")]
    [Key("account-nickname-enabled")]
    public bool accountNicknameEnabled;

    [JsonInclude, JsonPropertyName("new-year-theme-2026")]
    [Key("new-year-theme-2026")]
    public bool newYearTheme2026;

    [JsonInclude, JsonPropertyName("nick-min-length")]
    [Key("nick-min-length")]
    public int nickMinLength;

    [JsonInclude, JsonPropertyName("informer-enabled")]
    [Key("informer-enabled")]
    public bool informerEnabled;

    [JsonInclude, JsonPropertyName("stub")]
    [Key("stub")]
    public string stub;

    [JsonInclude, JsonPropertyName("file-upload-enabled")]
    [Key("file-upload-enabled")]
    public bool fileUploadEnabled;

    [JsonInclude, JsonPropertyName("invite-link")]
    [Key("invite-link")]
    public string inviteLink;

    [JsonInclude, JsonPropertyName("drafts-sync-enabled")]
    [Key("drafts-sync-enabled")]
    public bool draftsSyncEnabled;

    [JsonInclude, JsonPropertyName("transfer-botid")]
    [Key("transfer-botid")]
    public long transferBotId;

    [JsonInclude, JsonPropertyName("mentions_entity_names_limit")]
    [Key("mentions_entity_names_limit")]
    public int mentionsEntityNamesLimit;

    [JsonInclude, JsonPropertyName("channels-complaint-enabled")]
    [Key("channels-complaint-enabled")]
    public bool channelsComplaintEnabled;

    [JsonInclude, JsonPropertyName("reactions-enabled")]
    [Key("reactions-enabled")]
    public bool reactionsEnabled;

    [JsonInclude, JsonPropertyName("webm-stickers-enabled")]
    [Key("webm-stickers-enabled")]
    public bool webmStickersEnabled;

    [JsonInclude, JsonPropertyName("delete-msg-fys-large-chat-disabled")]
    [Key("delete-msg-fys-large-chat-disabled")]
    public bool deleteMsgFysLargeChatDisabled;

    [JsonInclude, JsonPropertyName("file-upload-unsupported-types")]
    [Key("file-upload-unsupported-types")]
    public string[] fileUploadUnsupportedTypes;

    [JsonInclude, JsonPropertyName("nick-max-length")]
    [Key("nick-max-length")]
    public int nickMaxLength;

    [JsonInclude, JsonPropertyName("content-level-access")]
    [Key("content-level-access")]
    public bool contentLevelAccess;

    [JsonInclude, JsonPropertyName("max-favorite-chats")]
    [Key("max-favorite-chats")]
    public int maxFavoriteChats;

    [JsonInclude, JsonPropertyName("author-visibility-forward-enabled")]
    [Key("author-visibility-forward-enabled")]
    public bool authorVisibilityForwardEnabled;

    [JsonInclude, JsonPropertyName("has-phone")]
    [Key("has-phone")]
    public bool hasPhone;

    [JsonInclude, JsonPropertyName("saved-messages-enabled")]
    [Key("saved-messages-enabled")]
    public bool savedMessagesEnabled;

    [JsonInclude, JsonPropertyName("react-permission")]
    [Key("react-permission")]
    public int reactPermission;

    [JsonInclude, JsonPropertyName("max-readmarks")]
    [Key("max-readmarks")]
    public int maxReadmarks;

    [JsonInclude, JsonPropertyName("sticker-suggestion")]
    [Key("sticker-suggestion")]
    public string[] stickerSuggestion;

    [JsonInclude, JsonPropertyName("creation-2fa-config")]
    [Key("creation-2fa-config")]
    public Creation2FAConfig creation2FAConfig;

    [JsonInclude, JsonPropertyName("chats-preload-period")]
    [Key("chats-preload-period")]
    public int chatsPreloadPeriod;

    [JsonInclude, JsonPropertyName("group-call-part-limit")]
    [Key("group-call-part-limit")]
    public int groupCallPartLimit;

    [JsonInclude, JsonPropertyName("max-favorite-stickers")]
    [Key("max-favorite-stickers")]
    public int maxFavoriteStickers;

    [JsonInclude, JsonPropertyName("file-upload-max-size")]
    [Key("file-upload-max-size")]
    public long fileUploadMaxSize;

    [JsonInclude, JsonPropertyName("max-description-length")]
    [Key("max-description-length")]
    public int maxDescriptionLength;

    [JsonInclude, JsonPropertyName("chats-page-size")]
    [Key("chats-page-size")]
    public int chatsPageSize;

    [JsonInclude, JsonPropertyName("markdown-enabled")]
    [Key("markdown-enabled")]
    public bool markdownEnabled;

    [JsonInclude, JsonPropertyName("reactions-menu")]
    [Key("reactions-menu")]
    public string[] reactionsMenu;

    [JsonInclude, JsonPropertyName("family-protection-botid")]
    [Key("family-protection-botid")]
    public long familyProtectionBotId;

    [JsonInclude, JsonPropertyName("calls-sdk-mapping")]
    [Key("calls-sdk-mapping")]
    public CallsSdkMapping callsSdkMapping;

    [JsonInclude, JsonPropertyName("stat-session-background-threshold")]
    [Key("stat-session-background-threshold")]
    public int statSessionBackgroundThreshold;

    [JsonInclude, JsonPropertyName("image-height")]
    [Key("image-height")]
    public int imageHeight;

    [JsonInclude, JsonPropertyName("search-webapps-showcase")]
    [Key("search-webapps-showcase")]
    public SearchWebappsShowcase searchWebappsShowcase;

    [JsonInclude, JsonPropertyName("saved-messages-aliases")]
    [Key("saved-messages-aliases")]
    public string[] savedMessagesAliases;

    [JsonInclude, JsonPropertyName("safe-mode-enabled")]
    [Key("safe-mode-enabled")]
    public bool safeModeEnabled;
}