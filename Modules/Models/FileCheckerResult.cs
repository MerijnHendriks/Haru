using System;
using FilesChecker;

namespace Haru.Modules.Models
{
    /// <summary>
    /// File checker result that always returns sucess
    /// </summary>
    public struct FileCheckerResult : ICheckResult
    {
        public TimeSpan ElapsedTime { get; }
        public Exception Exception { get; }

        public FileCheckerResult(TimeSpan elapsedTime = default)
        {
            ElapsedTime = elapsedTime;
            Exception = null;
        }
    }
}