using System;
using System.Diagnostics;

namespace Haru.Launcher.Processes
{
    public abstract class AProcess
    {
        private readonly string _filename;
        private Process _process;
        protected string[] Arguments;
        protected bool IsHighPriority;

        /// <summary>
        /// Constructor
        /// </summary>
        public AProcess(string filename)
        {
            _filename = filename;
            _process = null;
            Arguments = Array.Empty<string>();
            IsHighPriority = false;
        }

        /// <summary>
        /// Start the process
        /// </summary>
        public void Start()
        {
            // start the process
            var info = new ProcessStartInfo()
            {
                FileName = _filename,
                Arguments = string.Join(' ', Arguments),
                RedirectStandardOutput = true
            };

            _process = Process.Start(info);

            if (IsHighPriority)
            {
                _process.PriorityClass = ProcessPriorityClass.High;
            }

            // wait for subprocess to close
            _process.Exited += OnExitChildProcess;
        }

        /// <summary>
        /// Terminate the process
        /// </summary>
        public void Terminate()
        {
            if (_process == null)
            {
                // process hasn't been started
                return;
            }

            _process.Kill();
            _process.WaitForExit();
        }

        /// <summary>
        /// When the server closes
        /// </summary>
        private void OnExitChildProcess(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
