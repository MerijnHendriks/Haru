using System;
using Haru.Shared.Utils;

namespace Haru.Launcher
{
    class Program
    {
        private static GameProcess game;

        static void Main()
        {
            // set events
            AppDomain.CurrentDomain.DomainUnload += OnExit;
            AppDomain.CurrentDomain.ProcessExit += OnExit;
            AppDomain.CurrentDomain.UnhandledException += OnException;

            // start the game
            game = new GameProcess();
            game.Start();
        }

        private static void OnExit(object sender, EventArgs e)
        {
            game.Terminate();
        }

        private static void OnException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;
            Log.Exception(ex);
            game.Terminate();
        }
    }
}
