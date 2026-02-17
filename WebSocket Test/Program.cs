using MaxAPI;
using System;
using MaxAPI.MaxMessages;
using System.Linq;


Console.WriteLine("Введите токен авторизации: ");
var connectInfo = await MaxWebClient.Connect(Console.ReadLine()!, WebUserAgent.Default);

var client = connectInfo.Item1;

client.OnNewMessage += (o, message) => Console.WriteLine(message.message.text);

var sessionsResponse = await client.CallAsync(MsgGetSessions.OPCODE, new MsgGetSessions.Request());

var sessions = sessionsResponse.JsonDeserializePayload<MsgGetSessions.Response>().sessions;

Console.WriteLine(string.Join('\n', sessions.Select(s => $"{s.info}\t{s.current}\t{s.client}")));

await client.CallAsync(MsgSendMessage.OPCODE, new MsgSendMessage.Request(0, new() { text = "Ваня лох", cid = -DateTimeOffset.Now.ToUnixTimeMilliseconds()}));

Console.ReadLine();