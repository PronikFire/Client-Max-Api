using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.JsonExtension;

public class ChatConverter : JsonConverter<ChatBase>
{
    public override ChatBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var document = JsonDocument.ParseValue(ref reader);
        var typeJE = document.RootElement.GetProperty("type");

        return typeJE.GetString() switch
        {
            "DIALOG" => document.Deserialize<Dialog>(options),
            "CHAT" or "CHANNEL" => document.Deserialize<Chat>(options),
            _ => throw new JsonException("Unknown chat type")
        };
    }

    public override void Write(Utf8JsonWriter writer, ChatBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
