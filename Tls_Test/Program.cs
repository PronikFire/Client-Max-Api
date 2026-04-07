using MaxAPI;
using System;

Console.WriteLine("Введите токен авторизации: ");
var client = await MaxAppClient.SessionLoginAsync(Console.ReadLine()!);

client.OnNewMessage += (o, message) => Console.WriteLine(message.message.text);

Console.WriteLine($"Вы авторизовались как {client.Profile.contact.names[0].firstName} {client.Profile.contact.names[0].lastName}");

await client.MessageSendAsync(0, new() { text = Console.ReadLine()! });

Console.ReadLine();