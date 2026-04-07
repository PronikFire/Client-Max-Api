using MessagePack;
using MessagePack.Formatters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackFormatter(typeof(EnumAsStringFormatter<ChatAccess>))]
public enum ChatAccess
{
    [JsonStringEnumMemberName("PRIVATE")]
    [EnumMember(Value = "PRIVATE")]
    Private,
    [JsonStringEnumMemberName("PUBLIC")]
    [EnumMember(Value = "PUBLIC")]
    Public
}
