using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public enum ChatAccess
{
    [JsonStringEnumMemberName("PRIVATE")]
    Private,
    [JsonStringEnumMemberName("PUBLIC")]
    Public
}
