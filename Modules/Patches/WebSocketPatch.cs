using System;
using System.Linq;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class WebSocketPatch : ModulePatch
    {
        public WebSocketPatch() : base()
        {
            var types = ModuleConstants.EftTypes;
            var targetInterface = types.Single(x => x.IsInterface && x == typeof(IConnectionHandler));

            TargetMethod = types
                .Single(x => targetInterface.IsAssignableFrom(x) && x.IsAbstract && !x.IsInterface)
                .GetMethods(ModuleConstants.PrivateFlags).Single(x => x.ReturnType == typeof(Uri));
        }

        [PatchPostfix]
        protected static Uri PatchPostfix(Uri __instance)
        {
            return new Uri(__instance.ToString().Replace("wss:", "ws:"));
        }
    }
}
