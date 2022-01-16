using System;

namespace Haru.Shared.Utils
{
    public class Log
    {
        public static void Exception(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Trace:");
            Console.WriteLine(ex.StackTrace);
        }
    }
}
