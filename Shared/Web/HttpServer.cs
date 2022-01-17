namespace Haru.Shared.Web
{
    /// <summary>
    /// Server using HTTP protocol
    /// </summary>
    public class HttpServer
    {
        public readonly string Host;
        public readonly int Port;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">Host</param>
        /// <param name="port">Port</param>
        public HttpServer(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
