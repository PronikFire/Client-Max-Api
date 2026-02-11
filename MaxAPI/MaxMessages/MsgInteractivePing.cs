using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxAPI.MaxMessages;

/// <summary>
/// If no messages are sent, you need to send this message every 30 seconds so that the server does not close the connection.
/// There is no need for an response, it is always null.
/// </summary>
public class MsgInteractivePing
{
    public const ushort OPCODE = 1;

    public struct Request(bool interactive)
    {
        [JsonInclude, JsonPropertyName("interactive")]
        public readonly bool interactive = interactive;
    }
}
