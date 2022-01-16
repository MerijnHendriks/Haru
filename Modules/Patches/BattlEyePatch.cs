using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class BattlEyePatch : ModulePatch
    {
        private static FieldInfo _succeed;

        public BattlEyePatch() : base()
        {
            var methodName = "RunValidation";
            var flags = ModuleConstants.PublicFlags;
            var type = ModuleConstants.EftTypes.Single(x => x.GetMethod(methodName, flags) != null);

            _succeed = type.GetFields().Single(x => x.GetType() == typeof(bool));
            TargetMethod = type.GetMethod(methodName, flags);
        }

        [PatchPrefix]
        protected static bool PatchPrefix(ref Task __result, ref object __instance)
        {
            _succeed.SetValue(__instance, true);
            __result = Task.CompletedTask;
            return false;
        }
    }
}
