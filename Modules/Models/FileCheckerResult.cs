using System;
using FilesChecker;
using Haru.Shared.Generics;

namespace Haru.Modules.Models
{
    /// <summary>
    /// File checker result that always returns sucess
    /// </summary>
    public class FileCheckerResult : Singleton<FileCheckerResult>, ICheckResult
    {
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