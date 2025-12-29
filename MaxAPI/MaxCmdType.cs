using System;

namespace MaxAPI;

public enum MaxCmdType : byte
{
    //Все пакеты от клиента идут с типом Request
    Request = 0,
    //Большинство ответов от сервера идут с типом Ok
    Ok = 1,
    //Ответы с ошибками идут с типом Error
    //Где 2? без понятия
    Error = 3
}
