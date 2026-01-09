using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class Profile
{
    [JsonInclude, JsonPropertyName("profileOptions")]
    public object[] profileOptions;

    [JsonInclude, JsonPropertyName("contact")]
    public UserContact contact;
}
