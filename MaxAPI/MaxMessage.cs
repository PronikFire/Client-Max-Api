using System;

namespace MaxAPI;

public struct MaxMessage()
{
    public byte version = 0x0B;
    public MaxCmdType cmd = MaxCmdType.Request;
    public ushort seq = 0;
    public ushort opcode = 0;
    public byte extMode = 0;
    public byte[] payload = [];
}
