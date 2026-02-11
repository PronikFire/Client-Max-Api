using MaxAPI;
using System;


Console.WriteLine("Введите токен авторизации: ");
var connectInfo = await MaxWebClient.Connect(Console.ReadLine()!, WebUserAgent.Default);

var client = connectInfo.Item1;

Console.ReadLine();
