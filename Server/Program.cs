using System;
using Haru.Shared.Utils;

namespace Haru.Server
{
    public class Program
    {
        public static void Main()
        {
            // set events
            AppDomain.CurrentDomain.UnhandledException += OnException;

            // everything else
            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }

        private static void OnException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;
            Log.Exception(ex);
        }
    }
}
