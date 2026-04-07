# Client Max API

[Ссылка на гайд](https://github.com/PronikFire/Max-API-Guide)

### Возможности 
- Авторизация как через **Web**, так и через **App**
- Отправка сообщений в чаты
- Получение новых сообщений из чатов

### Как пользоваться

```C#
using MaxAPI;
using System;

Console.WriteLine("Введите токен авторизации: ");
var client = await MaxAppClient.SessionLoginAsync(Console.ReadLine()!);

client.OnNewMessage += (o, message) => Console.WriteLine(message.message.text);

Console.WriteLine($"Вы авторизовались как {client.Profile.contact.names[0].firstName} {client.Profile.contact.names[0].lastName}");

await client.MessageSendAsync(0, new() { text = Console.ReadLine()! });

Console.ReadLine();
```

> [!NOTE]
> Получить токен для **App** на данный момент можно только через **mitmproxy** или его аналоги.

### Как получить токен для Web

> [!IMPORTANT]
> Он подойдет **ТОЛЬКО** для **MaxWebClient**.

1. Зайдите на сайт [https://web.max.ru](https://web.max.ru).
2. Войдите в аккаунт, если не вошли.
3. **ПКМ** $\rightarrow$ **Просмотреть код** (название пункта зависит от браузера).
4. Перейдите на вкладку **Network** (Сеть).
5. Перезагрузите страницу.
6. Найдите строку с названием **«websocket»**.
7. Найдите исходящее сообщение с `opcode: 19`. Скорее всего, оно будет с `seq: 2` или `3` в списке.

То, что находится в поле `token`, и есть ваш токен для входа.