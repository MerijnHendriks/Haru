using System.IO;

namespace Haru.Shared.Utils
{
    public class FileSystem
    {
        /// <summary>
        /// Read all text from file
        /// </summary>
        /// <param name="filepath">Filepath</param>
        /// <returns>Text</returns>
        public static string ReadFile(string filepath)
        {
            return File.ReadAllText(filepath);
        }

        /// <summary>
        /// Write text to file
        /// </summary>
        /// <param name="filepath">Filepath</param>
        /// <param name="text">Text</param>
        public static void WriteFile(string filepath, string text)
        {
            File.WriteAllText(filepath, text);
        }
    }
}
