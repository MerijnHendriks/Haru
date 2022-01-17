using System;
using FilesChecker;

namespace Haru.Modules.Models
{
    /// <summary>
    /// File checker result that always returns sucess
    /// </summary>
    public class FileCheckerResult : ICheckResult
    {
        // Singleton pattern to ensure only one instance always exists
        private static FileCheckerResult _instance;
        public static FileCheckerResult Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileCheckerResult();
                }

                return _instance;
            }
        }

        public TimeSpan ElapsedTime { get; private set; }
        public Exception Exception { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FileCheckerResult()
        {
            ElapsedTime = new TimeSpan();
            Exception = null;
        }
    }
}