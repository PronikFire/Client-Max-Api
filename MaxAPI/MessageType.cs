using System.Text.Json.Serialization;

namespace MaxAPI;

public enum MessageType
{
    [JsonStringEnumMemberName("USER")]
    User,
    [JsonStringEnumMemberName("CHANNEL")]
    Channel
}
