namespace MaxAPI;

public class MaxOptions
{
    /// <summary>
    /// Buffer size for receiving messages.
    /// </summary>
    public int ReceiveBufferSize { get; init; } = 1024;
    /// <summary>
    /// The period in milliseconds at which the KeepAlive packet will be sent. The default is 30000.
    /// </summary>
    public long KeepAlivePeriod { get; init; } = 30000;
    /// <summary>
    /// If no response is received within this time (in milliseconds), the client will throw exception.
    /// </summary>
    public long ReceiveTimeout { get; init; } = 5000;
}
