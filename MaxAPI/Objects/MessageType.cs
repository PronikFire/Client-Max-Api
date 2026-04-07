using MessagePack;
using MessagePack.Formatters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackFormatter(typeof(EnumAsStringFormatter<MessageType>))]
public enum MessageType
{
    [JsonStringEnumMemberName("USER")]
    [EnumMember(Value = "USER")]
    User,
    [JsonStringEnumMemberName("CHANNEL")]
    [EnumMember(Value = "CHANNEL")]
    Channel
}
