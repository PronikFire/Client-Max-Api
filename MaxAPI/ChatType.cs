using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
