using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsgPack;
using System.Threading.Tasks;

namespace MaxAPI.Tls.Payloads;

public struct TlsMsgClientInfo(TlsUserAgent userAgent, Guid deviceId)
{
    public TlsUserAgent userAgent = userAgent;
    public string deviceId = deviceId.ToString();
    public uint clientSessionId = 0;


    public readonly TlsMaxMessage GetMessage()
    {
        return new TlsMaxMessage() { opcode = 6, payload = MsgPackSerialize.Serialize(this) };
    }
}
