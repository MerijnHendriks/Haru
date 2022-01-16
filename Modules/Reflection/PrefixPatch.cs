using System.Reflection;
using HarmonyLib;

namespace Haru.Modules.Reflection
{
    public abstract class PrefixPatch : APatch
    {
        protected PrefixPatch(string name) : base(name)
        {
        }

        protected override void Add(MethodBase original, HarmonyMethod patch)
        {
            Harmony.Patch(original, prefix: patch);
        }
    }
}
