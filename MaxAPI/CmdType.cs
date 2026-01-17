using System;

namespace MaxAPI;

public enum CmdType : byte
{
    //Все пакеты от клиента идут с типом Request
    Request = 0,
    //Большинство ответов от сервера идут с типом Ok
    Response = 1,
    // Я видел 2 в Web версии но не понимаю зачем он нужен
    Error = 3
}
