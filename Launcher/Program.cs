using System;
using Haru.Launcher.Processes;
using Haru.Launcher.Providers;
using Haru.Shared.Utils;

namespace Haru.Launcher
{
    /// <summary>
    /// Main application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static Program()
        {
            Console.Title = "Haru Launcher";
            AppDomain.CurrentDomain.UnhandledException += OnException;
            AppDomain.CurrentDomain.DomainUnload += OnExit;
            AppDomain.CurrentDomain.ProcessExit += OnExit;
        }

        /// <summary>
        /// Entry point
        /// </summary>
        static void Main()
        {
            var processes = ProcessProvider.Instance;

            // start processes
            processes.Add<ServerProcess>("SERVER");
            processes.Add<GameProcess>("GAME");
            processes.StartAll();
        }

        /// <summary>
        /// When this application closes
        /// </summary>
        private static void OnExit(object sender, EventArgs e)
        {
            ProcessProvider.Instance.TerminateAll();
        }

        /// <summary>
        /// When an exception is raised
        /// </summary>
        private static void OnException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;
            Log.Exception(ex);
        }
    }
}
