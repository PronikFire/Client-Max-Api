using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket.JsonExtensions;

public class ContactConverter : JsonConverter<Contact>
{
    public override Contact? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.GetProperty("options").EnumerateArray().Any(o => o.ToString() == "BOT"))
            return root.Deserialize<BotContact>(options);
        else if (root.TryGetProperty("phone", out _))
            return root.Deserialize<UserContact>(options);

        return root.Deserialize<Contact>(options);
    }

    public override void Write(Utf8JsonWriter writer, Contact value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
    }
}