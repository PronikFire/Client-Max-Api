using MaxAPI.WebSocket;
using MaxAPI.WebSocket.Payloads;
using System;
using System.Diagnostics;
using System.Text.Json;



MaxWssClient client = new();
await client.ConnectAsync();

{
    var request = new MsgSetClientInfo.Request(MsgSetClientInfo.UserAgent.Default, Guid.NewGuid());
    await client.SendAsync(MsgSetClientInfo.OPCODE, request);
    var response = await client.ReceiveAsync();
    MaxException.ThrowIfError(response);
}

{
    Console.WriteLine("Введите токен авторизации: ");
    var request = new MsgAuthToken.Request(Console.ReadLine()!);
    await client.SendAsync(MsgAuthToken.OPCODE, request);
    MaxMessage response;
    do
    {
        response = await client.ReceiveAsync();
        MaxException.ThrowIfError(response);
    } while (MsgAuthToken.OPCODE != response.opcode);
    var MsgAuthTokenResponse = ((JsonElement)response.payload!).Deserialize<MsgAuthToken.Response>();

    Debugger.Break();
}