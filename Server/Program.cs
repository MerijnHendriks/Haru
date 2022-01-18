using System;
using Haru.Shared.Utils;

namespace Haru.Server
{
    /// <summary>
    /// Main application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static Program()
        {
            AppDomain.CurrentDomain.UnhandledException += OnException;
        }

        /// <summary>
        /// Entry point
        /// </summary>
        public static void Main()
        {
            Console.Title = "Haru Server";
            Console.WriteLine("Hello, World!");
            Console.ReadKey();
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
