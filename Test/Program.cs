using MaxAPI;
using System;

MaxClient client = new();
client.SetClientInfo(UserAgent.Default).Wait();
string phoneNumber = Console.ReadLine();
var authResponse = client.StartAuth(phoneNumber);
authResponse.Wait();
bool result = false;
do
{
    var checkCodeResponse = client.CheckCode(authResponse.Result, Console.ReadLine()!);
    checkCodeResponse.Wait();
    result = checkCodeResponse.Result;
}
while (!result);