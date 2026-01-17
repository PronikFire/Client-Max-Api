using System;
using System.Diagnostics;
using System.Text.Json;
using System.Collections.Generic;
using MaxAPI;
using MaxAPI.MaxMessages;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json.Serialization.Metadata;



MaxWebClient client = new();
Dictionary<ushort, object?> unusedMessages = [];
ushort seq = 0;

await client.ConnectAsync();

await SendReceiveAsync(new MsgSetClientInfo.Request(WebUserAgent.Default, Guid.NewGuid()));

Console.WriteLine("Введите токен авторизации: ");
var loginResponse = (MsgLogin.Response)await SendReceiveAsync(new MsgLogin.Request(Console.ReadLine()!));

Debugger.Break();

async Task<object?> SendReceiveAsync(object requestPayload)
{
    var outerType = requestPayload.GetType().DeclaringType ?? throw new ArgumentException("Request struct will be have a Declaring object.", nameof(requestPayload));

    var opcode = outerType.GetField("OPCODE") ?? throw new ArgumentException("Outer class don't contains opcode field.", nameof(requestPayload));
    var responsePayload = outerType.GetNestedType("Response") ?? throw new ArgumentException("Outer class don't contains response struct.", nameof(requestPayload));

    if (opcode.FieldType != typeof(ushort))
        throw new ArgumentException("Opcode field will be ushort.", nameof(requestPayload));

    MaxMessage request = new()
    {
        opcode = (ushort)opcode.GetValue(null)!,
        seq = ++seq,
        payload = requestPayload
    };
    await client.SendAsync(request);
    MaxMessage response;
    do
    {
        response = await client.ReceiveAsync();
        if (response.opcode == request.opcode && response.seq == request.seq)
            break;
        unusedMessages.Add(response.opcode, response.payload);
    } while (true);
    MaxException.ThrowIfError(response);
    return ((JsonElement)response.payload!).Deserialize(JsonTypeInfo.CreateJsonTypeInfo(responsePayload, JsonSerializerOptions.Default));
}