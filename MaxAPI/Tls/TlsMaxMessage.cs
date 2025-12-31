using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAPI.Tls;

public class TlsMaxMessage
{
    public byte ver = 11;
    public CmdType cmd = CmdType.Request;
    public ushort seq = 0;
    public ushort opcode = 0;
    public byte extMode = 0;
    public byte[] payload = [];
}
