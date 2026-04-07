using MessagePack;
using MessagePack.Formatters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackFormatter(typeof(EnumAsStringFormatter<DeviceType>))]
public enum DeviceType
{
    [JsonStringEnumMemberName("DESKTOP")]
    [EnumMember(Value = "DESKTOP")]
    Desktop,
    [JsonStringEnumMemberName("ANDROID")]
    [EnumMember(Value = "ANDROID")]
    Android,
    [JsonStringEnumMemberName("WEB")]
    [EnumMember(Value = "WEB")]
    Web
}
