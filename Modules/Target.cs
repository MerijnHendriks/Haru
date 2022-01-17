using NLog.Targets;

namespace Haru.Modules
{
    /// <summary>
    /// Hook
    /// </summary>
    [Target("Haru.Modules")]
    public sealed class Target : TargetWithLayout
    {
        /// <summary>
        /// Entry point
        /// </summary>
        public Target()
        {
            Program.Main();
        }
    }
}
