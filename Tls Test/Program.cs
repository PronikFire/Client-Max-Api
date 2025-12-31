using MaxAPI;
using MaxAPI.Tls;
using System;
using System.Diagnostics;

return;
/*
TlsMaxClient client = new();
var userAgent = TlsUserAgent.Default;

string randomDeviceName = "DESKTOP-";
//Весьма грубое решение я знаю 
const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

for (int i = 0; i < 7; i++)
{
    randomDeviceName += chars[Random.Shared.Next(chars.Length)];
}

userAgent.deviceName = randomDeviceName;
await client.SetClientInfoAsync(userAgent);

string phoneNumber = Console.ReadLine();
var authResponse = await client.StartAuth(phoneNumber);

while (!await client.CheckCode(authResponse, Console.ReadLine()!)) ;
*/