# Client Max API

> [!IMPORTANT]
> Находится в разработке.

[Ссылка на гайд](https://github.com/PronikFire/Max-API-Guide)

### Возможности 
- Отправка сообщений в чаты
- Получение новых сообщений из чатов

### Как пользоваться

```C#
var connectInfo = await MaxWebClient.Connect(token, WebUserAgent.Default);

var client = connectInfo.Item1;

client.OnNewMessage += (o, message) => Console.WriteLine(message.message.text);

var sessionsResponse = await client.CallAsync(MsgGetSessions.OPCODE, new MsgGetSessions.Request());

var sessions = sessionsResponse.JsonDeserializePayload<MsgGetSessions.Response>().sessions;

Console.WriteLine(string.Join('\n', sessions.Select(s => $"{s.info} {s.current} {s.client}")));

```

Основной класс - MaxWebClient.
App-версия в разработке.

Классы запросов и ответов можно найти в пространстве имён MaxMessages.

По причине того, что доступна только Web-версия, невозможно войти в аккаунт по номеру телефона. Для работы с API нужен токен входа.

### Как получить токен

1. Заходим на сайт https://web.max.ru
2. Входим в аккаунт, если не вошли
3. ПКМ -> Проверить (текст зависит от браузера)
4. Нажимаем Network
5. Перезагружаем страницу
6. Ищем "websocket"
7. Ищем исходящее сообщение с opcode 19. Скорее всего, оно будет с seq 2 или 3 в списке.

То, что находится в поле token, и есть токен для входа.
