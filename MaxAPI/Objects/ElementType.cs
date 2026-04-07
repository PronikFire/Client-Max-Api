using MessagePack;
using MessagePack.Formatters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaxAPI.Objects;

[MessagePackFormatter(typeof(EnumAsStringFormatter<ElementType>))]
public enum ElementType
{
    [JsonStringEnumMemberName("STRONG")]
    [EnumMember(Value = "STRONG")]
    Strong,

    [JsonStringEnumMemberName("LINK")]
    [EnumMember(Value = "LINK")]
    Link,

    [JsonStringEnumMemberName("EMPHASIZED")]
    [EnumMember(Value = "EMPHASIZED")] 
    Emphasized,

    [JsonStringEnumMemberName("UNDERLINE")]
    [EnumMember(Value = "UNDERLINE")] 
    Underline,

    [JsonStringEnumMemberName("STRIKETHROUGH")]
    [EnumMember(Value = "STRIKETHROUGH")] 
    Strikethrough,

    [JsonStringEnumMemberName("QUOTE")]
    [EnumMember(Value = "QUOTE")] 
    Quote,

    [JsonStringEnumMemberName("HEADING")]
    [EnumMember(Value = "HEADING")] 
    Heading
}
