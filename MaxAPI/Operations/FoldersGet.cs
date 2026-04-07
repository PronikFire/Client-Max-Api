using MaxAPI.Objects;
using System.Text.Json.Serialization;
using MessagePack;

namespace MaxAPI.Operations;

public class FoldersGet
{
    public const ushort OPCODE = 272;

    public struct Request(int folderSync)
    {
        [JsonInclude, JsonPropertyName("folderSync")]
        [Key("folderSync")]
        public int folderSync = folderSync;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("foldersOrder")]
        [Key("foldersOrder")]
        public string[] foldersOrder;
        [JsonInclude, JsonPropertyName("folderSync")]
        [Key("folderSync")]
        public long folderSync;
        [JsonInclude, JsonPropertyName("folders")]
        [Key("folders")]
        public Folder[] folders;
    }
}
