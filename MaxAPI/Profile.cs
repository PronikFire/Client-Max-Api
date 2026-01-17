using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI;

public class Profile
{
    [JsonInclude, JsonPropertyName("profileOptions")]
    public object[] profileOptions;

    [JsonInclude, JsonPropertyName("contact")]
    public Contact contact;
}
