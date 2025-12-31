using MaxAPI;
using MaxAPI.Tls;
using MaxAPI.WebSocket;
using MaxAPI.WebSocket.Packets;
using MaxAPI.WebSocket.Payloads;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;

WssMaxClient client = new();
var request = new WssMsgClientInfo(WssUserAgent.Default, Guid.NewGuid())
    .GetMessage();
await client.SendAsync(request);
var response = await client.ReceiveAsync();
WssMaxException.ThrowIfError(response);

Console.Write("Введите токен авторизации: ");
request = new WssMsgConnectByToken(Console.ReadLine())
    .GetMessage();
await client.SendAsync(request);
response = await client.ReceiveAsync();
WssMaxException.ThrowIfError(response);

response = await client.ReceiveAsync();
WssMaxException.ThrowIfError(response);

Debugger.Break();