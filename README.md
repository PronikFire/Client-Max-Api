# Client Max API

> [!IMPORTANT]
> Находится в разработке.

[Ссылка на гайд](https://github.com/PronikFire/Max-API-Guide)

### Возможности 
- Отправка сообщений в чаты
- Получение новых сообщений из чатов

### Как пользоваться

```
var connectInfo = await MaxWebClient.Connect(token, WebUserAgent.Default);

var client = connectInfo.Item1;

client.OnNewMessage += (o, message) => Console.WriteLine(message.message.text);

var sessionsResponse = await client.CallAsync(MsgGetSessions.OPCODE, new MsgGetSessions.Request());

var sessions = sessionsResponse.JsonDeserializePayload<MsgGetSessions.Response>().sessions;

Console.WriteLine(string.Join('\n', sessions.Select(s => $"{s.info} {s.current} {s.client}")));

```

Основной класс - MaxWebClient.
App-версию невозможно реализовать по причине, описанной [здесь](https://github.com/PronikFire/Max-API-Guide?tab=readme-ov-file#%D0%BF%D1%80%D0%BE%D0%B1%D0%BB%D0%B5%D0%BC%D0%B0-7-%D0%B3%D0%BE-%D0%B1%D0%B0%D0%B9%D1%82%D0%B0).

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
