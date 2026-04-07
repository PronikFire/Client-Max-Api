using MessagePack;
using MessagePack.Formatters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackFormatter(typeof(EnumAsStringFormatter<NameType>))]
public enum NameType
{
    [JsonStringEnumMemberName("CUSTOM")]
    [EnumMember(Value = "CUSTOM")]
    Custom,
    [JsonStringEnumMemberName("ONEME")]
    [EnumMember(Value = "ONEME")]
    OneMe
}
