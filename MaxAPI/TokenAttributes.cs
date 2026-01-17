using MsgPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAPI;

public class TokenAttributes
{
    [MsgPackInclude, MsgPackName("LOGIN")]
    public string login;
}
