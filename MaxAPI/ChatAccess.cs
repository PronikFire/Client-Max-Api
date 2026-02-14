using System.Text.Json.Serialization;

namespace MaxAPI;

public enum ChatAccess
{
    [JsonStringEnumMemberName("PRIVATE")]
    Private,
    [JsonStringEnumMemberName("PUBLIC")]
    Public
}
