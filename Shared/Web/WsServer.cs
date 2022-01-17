namespace Haru.Shared.Web
{
    /// <summary>
    /// Server using WS protocol
    /// </summary>
    public class WsServer
    {
        public readonly string Host;
        public readonly int Port;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">Host</param>
        /// <param name="port">Port</param>
        public WsServer(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
