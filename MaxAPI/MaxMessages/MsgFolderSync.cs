using System.Text.Json.Serialization;

namespace MaxAPI.MaxMessages;

public class MsgFolderSync
{
    public const ushort OPCODE = 272;

    public struct Request(int folderSync)
    {
        [JsonInclude, JsonPropertyName("folderSync")]
        public int folderSync = folderSync;
    }

    public struct Response()
    {
        [JsonInclude, JsonPropertyName("foldersOrder")]
        public string[] foldersOrder;
        [JsonInclude, JsonPropertyName("folderSync")]
        public long folderSync;
        [JsonInclude, JsonPropertyName("folders")]
        public Folder[] folders;
    }
}
