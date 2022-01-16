using System.Reflection;
using HarmonyLib;

namespace Haru.Modules.Reflection
{
    public abstract class PostfixPatch : APatch
    {
        protected PostfixPatch(string name) : base(name)
        {
        }

        protected override void Add(MethodBase original, HarmonyMethod patch)
        {
            Harmony.Patch(original, postfix: patch);
        }
    }
}
