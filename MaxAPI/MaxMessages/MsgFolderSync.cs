using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.MaxMessages;

public class MsgFolderSync
{
    public const ushort OPCODE = 272;

    public struct Request(int folderSync)
    {
        [JsonInclude, JsonPropertyName("folderSync")]
        public readonly int folderSync = folderSync;
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
