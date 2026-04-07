using MessagePack;
using MessagePack.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaxAPI.Objects;

[MessagePackFormatter(typeof(EnumAsStringFormatter<ChatType>))]
public enum ChatType
{
    [EnumMember(Value = "DIALOG")]
    Dialog,
    [EnumMember(Value = "CHAT")]
    Chat,
    [EnumMember(Value = "CHANNEL")]
    Channel
}
