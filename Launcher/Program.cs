using System;
using Haru.Shared.Utils;

namespace Haru.Launcher
{
    /// <summary>
    /// Main application
    /// </summary>
    class Program
    {
        private static GameProcess game;

        /// <summary>
        /// Constructor
        /// </summary>
        static Program()
        { 
            AppDomain.CurrentDomain.DomainUnload += OnExit;
            AppDomain.CurrentDomain.ProcessExit += OnExit;
            AppDomain.CurrentDomain.UnhandledException += OnException;
        }

        /// <summary>
        /// Entry point
        /// </summary>
        static void Main()
        {
            game = new GameProcess();
            game.Start();
        }

        /// <summary>
        /// When this application closes
        /// </summary>
        private static void OnExit(object sender, EventArgs e)
        {
            game.Terminate();
        }

        /// <summary>
        /// When an exception is raised
        /// </summary>
        private static void OnException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;
            Log.Exception(ex);
            game.Terminate();
        }
    }
}
