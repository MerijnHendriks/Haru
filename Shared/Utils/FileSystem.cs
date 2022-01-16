using System.IO;

namespace Haru.Shared.Utils
{
    public class FileSystem
    {
        public static string ReadFile(string filepath)
        {
            return File.ReadAllText(filepath);
        }

        public static void WriteFile(string filepath, string text)
        {
            File.WriteAllText(filepath, text);
        }
    }
}
