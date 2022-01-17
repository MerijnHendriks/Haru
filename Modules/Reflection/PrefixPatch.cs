using System.Reflection;
using HarmonyLib;

namespace Haru.Modules.Reflection
{
    /// <summary>
    /// Prefix patch
    /// </summary>
    public abstract class PrefixPatch : APatch
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Patch name</param>
        protected PrefixPatch(string name) : base(name)
        {
        }

        /// <summary>
        /// Add patch to original method
        /// </summary>
        /// <param name="original">Original method</param>
        /// <param name="patch">Patch method</param>
        protected override void Apply(MethodBase original, HarmonyMethod patch)
        {
            Harmony.Patch(original, prefix: patch);
        }
    }
}
