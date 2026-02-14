using System.Text.Json.Serialization;

namespace MaxAPI;

public enum ChatType
{
    [JsonStringEnumMemberName("CHAT")]
    Chat,
    [JsonStringEnumMemberName("DIALOG")]
    Dialog,
    [JsonStringEnumMemberName("CHANNEL")]
    Channel
}
