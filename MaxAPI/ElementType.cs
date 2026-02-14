using System.Text.Json.Serialization;

namespace MaxAPI;

public enum ElementType
{
    [JsonStringEnumMemberName("STRONG")]
    Strong,

    [JsonStringEnumMemberName("LINK")]
    Link,

    [JsonStringEnumMemberName("EMPHASIZED")]
    Emphasized,

    [JsonStringEnumMemberName("UNDERLINE")]
    Underline,

    [JsonStringEnumMemberName("STRIKETHROUGH")]
    Strikethrough,

    [JsonStringEnumMemberName("QUOTE")]
    Quote,
}
