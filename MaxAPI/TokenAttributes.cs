using MsgPack;

namespace MaxAPI;

public class TokenAttributes
{
    [MsgPackInclude, MsgPackName("LOGIN")]
    public string login;
}
