using System;

namespace Haru.Shared.Utils
{
    public class Log
    {
        /// <summary>
        /// Write exception to log
        /// </summary>
        /// <param name="ex">Exception</param>
        public static void Exception(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Trace:");
            Console.WriteLine(ex.StackTrace);
        }
    }
}
