using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class BattlEyePatch : PrefixPatch
    {
        private static FieldInfo _succeed;

        public BattlEyePatch() : base("com.haru.battleye")
        {
        }

        protected override MethodBase GetOriginalMethod()
        {
            var methodName = "RunValidation";
            var flags = Flags.PublicInstance;
            var types = TypeProvider.Get("EFT"); 
            var type = types.Single(x => x.GetMethod(methodName, flags) != null);

            _succeed = type.GetFields().Single(x => x.GetType() == typeof(bool));
            return type.GetMethod(methodName, flags);
        }

        protected static bool Patch(ref Task __result, object __instance)
        {
            _succeed.SetValue(__instance, true);
            __result = Task.CompletedTask;
            return false;
        }
    }
}
