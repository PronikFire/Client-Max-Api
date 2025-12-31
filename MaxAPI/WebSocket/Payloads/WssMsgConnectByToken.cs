using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket.Packets;

public struct WssMsgConnectByToken(string token)
{
    public bool interactive = true;
    public string token = token;
    public uint chatsCount = 40;
    public uint chatsSync = 0;
    public uint contactsSync = 0;
    public int presenceSync = -1;
    public uint draftsSync = 0;

    public readonly WssMaxMessage GetMessage()
    {
        return new WssMaxMessage() { opcode = 19, payload = this };
    }
}