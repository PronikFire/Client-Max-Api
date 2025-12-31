using MaxAPI.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket.Packets;

public struct WssMsgClientInfo(WssUserAgent userAgent, Guid deviceId)
{
    public WssUserAgent userAgent = userAgent;
    /// <summary>
    /// Уникальный идентификатор устройства. Если не знаете как его правильно задать, используйте конструктор.
    /// </summary>
    public string deviceId = deviceId.ToString();

    public readonly WssMaxMessage GetMessage()
    {
        return new WssMaxMessage() { opcode = 6, payload = this };
    }
}
