using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.WebSocket;

public class UserContact : Contact
{
    [JsonIgnore, JsonPropertyName("phone")]
    public long phone;
}
