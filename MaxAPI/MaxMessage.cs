using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaxAPI;

/// <summary>
/// Represents a message structure used for communication in the Max protocol, containing version, command type,
/// sequence number, operation code, and an optional payload.
/// </summary>
public struct MaxMessage()
{
    /// <summary>
    /// Version of the Max protocol message format.
    /// </summary>
    /// <remarks>
    /// In most cases, this value is set to 11 and don't need to be change.
    /// </remarks>
    [JsonInclude, JsonPropertyName("ver")]
    public byte version = 11;

    /// <summary>
    /// Specifies the command type for the request or response message.
    /// </summary>
    /// <remarks>This field determines the nature of the message, such as whether it is a request or a
    /// response. The default value is CmdType.Request.</remarks>
    [JsonInclude, JsonPropertyName("cmd")]
    public CmdType cmd = CmdType.Request;

    /// <summary>
    /// Gets or sets the sequence number associated with this object.
    /// </summary>
    /// <remarks>
    /// Response will have the same sequence number as the corresponding request.
    /// </remarks>
    [JsonInclude, JsonPropertyName("seq")]
    public ushort seq = 0;

    /// <summary>
    /// Gets or sets the operation code associated with the message.
    /// </summary>
    /// <remarks>The operation code identifies the type of operation or command represented by the message.
    /// The specific meaning of each code depends on the protocol or application context.</remarks>
    [JsonInclude, JsonPropertyName("opcode")]
    public ushort opcode = 0;

    /// <summary>
    /// Gets or sets the payload data associated with this object.
    /// </summary>
    /// <remarks>The payload can be any serializable value, including null.</remarks>
    [JsonInclude, JsonPropertyName("payload")]
    public object? payload = null;

    public T JsonDeserializePayload<T>()
    {
        ArgumentNullException.ThrowIfNull(payload, nameof(payload));

        if (payload is not JsonElement payloadJE)
            throw new ArgumentNullException(nameof(payload), "Payload is not " + nameof(JsonElement));

        return payloadJE.Deserialize<T>()!;
    }
}
