using System;
using System.Diagnostics;

namespace Haru.Launcher
{
    public class GameProcess
    {
        private Process process;

        public GameProcess()
        {
            process = null;
        }

        public void Start()
        {
            // todo: move this into a config
            var token = "haru-singleplayer";
            var url = "http://localhost:8000";

            // set launch info
            var arguments = new string[]
            {
                // user account token
                $"-token={token}",
                // server config
                $"-config={{\"backendurl\":\"{url}\",\"version\":\"live\"}}"
            };

            // start the game
            var info = new ProcessStartInfo()
            {
                FileName = "EscapeFromTarkov.exe",
                Arguments = string.Join(' ', arguments),
                RedirectStandardOutput = true
            };

            process = Process.Start(info);
            process.PriorityClass = ProcessPriorityClass.High;

            // wait for subprocess to close
            process.Exited += OnExitChildProcess;
        }

        public void Terminate()
        {
            if (process == null)
            {
                // game hasn't been started
                return;
            }

            process.Kill();
            process.WaitForExit();
        }

        private void OnExitChildProcess(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
