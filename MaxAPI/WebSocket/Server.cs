using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class Server
{
    [JsonInclude, JsonPropertyName("money-transfer-botid")]
    public long moneytransferbotid;

    [JsonInclude, JsonPropertyName("set-unread-timeout")]
    public int setunreadtimeout;

    [JsonInclude, JsonPropertyName("account-removal-enabled")]
    public bool accountremovalenabled;

    [JsonInclude, JsonPropertyName("appearance-multi-theme-screen-enabled")]
    public bool appearancemultithemescreenenabled;

    [JsonInclude, JsonPropertyName("gce")]
    public bool gce;

    [JsonInclude, JsonPropertyName("group-call-chat-support")]
    public bool groupcallchatsupport;

    [JsonInclude, JsonPropertyName("call-rate")]
    public CallRate callrate;

    [JsonInclude, JsonPropertyName("image-size")]
    public int imagesize;

    [JsonInclude, JsonPropertyName("gcce")]
    public bool gcce;

    [JsonInclude, JsonPropertyName("max-video-duration-download")]
    public int maxvideodurationdownload;

    [JsonInclude, JsonPropertyName("max-msg-length")]
    public int maxmsglength;

    [JsonInclude, JsonPropertyName("markdown-menu")]
    public int markdownmenu;

    [JsonInclude, JsonPropertyName("async-tracer")]
    public double asynctracer;

    [JsonInclude, JsonPropertyName("image-width")]
    public int imagewidth;

    [JsonInclude, JsonPropertyName("invite-by-link-screen")]
    public bool invitebylinkscreen;

    [JsonInclude, JsonPropertyName("calls-endpoint")]
    public string callsendpoint;

    [JsonInclude, JsonPropertyName("send-location-enabled")]
    public bool sendlocationenabled;

    [JsonInclude, JsonPropertyName("gc-from-p2p")]
    public bool gcfromp2p;

    [JsonInclude, JsonPropertyName("max-theme-length")]
    public int maxthemelength;

    [JsonInclude, JsonPropertyName("callDontUseVpnForRtp")]
    public bool callDontUseVpnForRtp;

    [JsonInclude, JsonPropertyName("lgce")]
    public bool lgce;

    [JsonInclude, JsonPropertyName("msg-get-reactions-page-size")]
    public int msggetreactionspagesize;

    [JsonInclude, JsonPropertyName("js-download-delegate")]
    public bool jsdownloaddelegate;

    [JsonInclude, JsonPropertyName("wud")]
    public bool wud;

    [JsonInclude, JsonPropertyName("video-msg-enabled")]
    public bool videomsgenabled;

    [JsonInclude, JsonPropertyName("grse")]
    public bool grse;

    [JsonInclude, JsonPropertyName("post-link-enabled")]
    public bool postlinkenabled;

    [JsonInclude, JsonPropertyName("edit-timeout")]
    public int edittimeout;

    [JsonInclude, JsonPropertyName("reactions-max")]
    public int reactionsmax;

    [JsonInclude, JsonPropertyName("views-count-enabled")]
    public bool viewscountenabled;

    [JsonInclude, JsonPropertyName("typing-enabled-FILE")]
    public bool typingenabledFILE;

    [JsonInclude, JsonPropertyName("lebedev-theme-enabled")]
    public bool lebedevthemeenabled;

    [JsonInclude, JsonPropertyName("max-participants")]
    public int maxparticipants;

    [JsonInclude, JsonPropertyName("audio-transcription-locales")]
    public object[] audiotranscriptionlocales;

    [JsonInclude, JsonPropertyName("welcome-sticker-ids")]
    public long[] welcomestickerids;

    [JsonInclude, JsonPropertyName("file-preview")]
    public bool filepreview;

    [JsonInclude, JsonPropertyName("new-admin-permissions")]
    public bool newadminpermissions;

    [JsonInclude, JsonPropertyName("invite-long")]
    public string invitelong;

    [JsonInclude, JsonPropertyName("max-favorite-sticker-sets")]
    public int maxfavoritestickersets;

    [JsonInclude, JsonPropertyName("moscow-theme-enabled")]
    public bool moscowthemeenabled;

    [JsonInclude, JsonPropertyName("chats-folder-enabled")]
    public bool chatsfolderenabled;

    [JsonInclude, JsonPropertyName("chat-invite-link-permissions-enabled")]
    public bool chatinvitelinkpermissionsenabled;

    [JsonInclude, JsonPropertyName("cfs")]
    public bool cfs;

    [JsonInclude, JsonPropertyName("callEnableIceRenomination")]
    public bool callEnableIceRenomination;

    [JsonInclude, JsonPropertyName("mentions-enabled")]
    public bool mentionsenabled;

    [JsonInclude, JsonPropertyName("double-tap-reaction")]
    public string doubletapreaction;

    [JsonInclude, JsonPropertyName("image-quality")]
    public double imagequality;

    [JsonInclude, JsonPropertyName("rename-settings-to-profile")]
    public bool renamesettingstoprofile;

    [JsonInclude, JsonPropertyName("max-audio-length")]
    public int maxaudiolength;

    [JsonInclude, JsonPropertyName("settings-entry-banners")]
    public SettingsEntryBanner[] settingsentrybanners;

    [JsonInclude, JsonPropertyName("invite-short")]
    public string inviteshort;

    [JsonInclude, JsonPropertyName("official-org")]
    public bool officialorg;

    [JsonInclude, JsonPropertyName("channels-enabled")]
    public bool channelsenabled;

    [JsonInclude, JsonPropertyName("unsafe-files-alert")]
    public bool unsafefilesalert;

    [JsonInclude, JsonPropertyName("min-image-side-size")]
    public int minimagesidesize;

    [JsonInclude, JsonPropertyName("account-nickname-enabled")]
    public bool accountnicknameenabled;

    [JsonInclude, JsonPropertyName("new-year-theme-2026")]
    public bool newyeartheme2026;

    [JsonInclude, JsonPropertyName("nick-min-length")]
    public int nickminlength;

    [JsonInclude, JsonPropertyName("informer-enabled")]
    public bool informerenabled;

    [JsonInclude, JsonPropertyName("stub")]
    public string stub;

    [JsonInclude, JsonPropertyName("file-upload-enabled")]
    public bool fileuploadenabled;

    [JsonInclude, JsonPropertyName("invite-link")]
    public string invitelink;

    [JsonInclude, JsonPropertyName("drafts-sync-enabled")]
    public bool draftssyncenabled;

    [JsonInclude, JsonPropertyName("transfer-botid")]
    public long transferbotid;

    [JsonInclude, JsonPropertyName("mentions_entity_names_limit")]
    public int mentions_entity_names_limit;

    [JsonInclude, JsonPropertyName("channels-complaint-enabled")]
    public bool channelscomplaintenabled;

    [JsonInclude, JsonPropertyName("reactions-enabled")]
    public bool reactionsenabled;

    [JsonInclude, JsonPropertyName("webm-stickers-enabled")]
    public bool webmstickersenabled;

    [JsonInclude, JsonPropertyName("delete-msg-fys-large-chat-disabled")]
    public bool deletemsgfyslargechatdisabled;

    [JsonInclude, JsonPropertyName("file-upload-unsupported-types")]
    public string[] fileuploadunsupportedtypes;

    [JsonInclude, JsonPropertyName("nick-max-length")]
    public int nickmaxlength;

    [JsonInclude, JsonPropertyName("content-level-access")]
    public bool contentlevelaccess;

    [JsonInclude, JsonPropertyName("max-favorite-chats")]
    public int maxfavoritechats;

    [JsonInclude, JsonPropertyName("author-visibility-forward-enabled")]
    public bool authorvisibilityforwardenabled;

    [JsonInclude, JsonPropertyName("has-phone")]
    public bool hasphone;

    [JsonInclude, JsonPropertyName("saved-messages-enabled")]
    public bool savedmessagesenabled;

    [JsonInclude, JsonPropertyName("react-permission")]
    public int reactpermission;

    [JsonInclude, JsonPropertyName("max-readmarks")]
    public int maxreadmarks;

    [JsonInclude, JsonPropertyName("sticker-suggestion")]
    public string[] stickersuggestion;

    [JsonInclude, JsonPropertyName("creation-2fa-config")]
    public Creation2FAConfig creation2FAConfig;

    [JsonInclude, JsonPropertyName("chats-preload-period")]
    public int chatspreloadperiod;

    [JsonInclude, JsonPropertyName("group-call-part-limit")]
    public int groupcallpartlimit;

    [JsonInclude, JsonPropertyName("max-favorite-stickers")]
    public int maxfavoritestickers;

    [JsonInclude, JsonPropertyName("file-upload-max-size")]
    public long fileuploadmaxsize;

    [JsonInclude, JsonPropertyName("max-description-length")]
    public int maxdescriptionlength;

    [JsonInclude, JsonPropertyName("chats-page-size")]
    public int chatspagesize;

    [JsonInclude, JsonPropertyName("markdown-enabled")]
    public bool markdownenabled;

    [JsonInclude, JsonPropertyName("reactions-menu")]
    public string[] reactionsmenu;
    
    [JsonInclude, JsonPropertyName("family-protection-botid")]
    public long familyprotectionbotid;

    [JsonInclude, JsonPropertyName("calls-sdk-mapping")]
    public CallsSdkMapping callssdkmapping;

    [JsonInclude, JsonPropertyName("stat-session-background-threshold")]
    public int statsessionbackgroundthreshold;

    [JsonInclude, JsonPropertyName("image-height")]
    public int imageheight;

    [JsonInclude, JsonPropertyName("search-webapps-showcase")]
    public SearchWebappsShowcase searchwebappsshowcase;

    [JsonInclude, JsonPropertyName("saved-messages-aliases")]
    public string[] savedmessagesaliases;

    [JsonInclude, JsonPropertyName("safe-mode-enabled")]
    public bool safemodeenabled;
}
