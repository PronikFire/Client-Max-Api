using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
