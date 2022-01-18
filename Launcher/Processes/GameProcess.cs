namespace Haru.Launcher.Processes
{
    /// <summary>
    /// Server process manager
    /// </summary>
    public class GameProcess : AProcess
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GameProcess() : base("EscapeFromTarkov.exe")
        {
            // todo: move this into a config
            var token = "haru-singleplayer";
            var url = "http://localhost:8000";

            // set launch info
            IsHighPriority = true;
            Arguments = new string[]
            {
                // user account token
                $"-token={token}",
                // server config
                $"-config={{\"backendurl\":\"{url}\",\"version\":\"live\"}}"
            };
        }
    }
}
