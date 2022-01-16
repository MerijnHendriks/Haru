using NLog.Targets;

namespace Haru.Modules
{
    [Target("Haru.Modules")]
    public sealed class Target : TargetWithLayout
    {
        public Target()
        {
            Program.Main();
        }
    }
}
