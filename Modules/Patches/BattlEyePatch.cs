using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Modules.Providers;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    /// <summary>
    /// Patch to disable battleye
    /// </summary>
    public class BattlEyePatch : PrefixPatch
    {
        private static FieldInfo _succeed;

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlEyePatch() : base("com.haru.battleye")
        {
        }

        /// <summary>
        /// Get the original method from lookup pattern
        /// </summary>
        /// <returns>Original method</returns>
        protected override MethodBase GetOriginalMethod()
        {
            var methodName = "RunValidation";
            var flags = Flags.PublicInstance;
            var types = TypeProvider.Instance.Get("EFT"); 
            var type = types.Single(x => x.GetMethod(methodName, flags) != null);

            _succeed = type.GetFields().Single(x => x.GetType() == typeof(bool));
            return type.GetMethod(methodName, flags);
        }

        /// <summary>
        /// Patch the original method
        /// </summary>
        /// <returns>Execute original method?</returns>
        protected static bool Patch(ref Task __result, object __instance)
        {
            _succeed.SetValue(__instance, true);
            __result = Task.CompletedTask;
            return false;
        }
    }
}
