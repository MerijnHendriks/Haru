using System;
using System.Linq;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class WebSocketPatch : PostfixPatch
    {
        public WebSocketPatch() : base("com.haru.websocket")
        {
            var types = TypeProvider.Get("EFT");
            var targetInterface = types.Single(x => x.IsInterface && x == typeof(IConnectionHandler));

            OriginalMethod = types
                .Single(x => targetInterface.IsAssignableFrom(x) && x.IsAbstract && !x.IsInterface)
                .GetMethods(Flags.PrivateInstance).Single(x => x.ReturnType == typeof(Uri));
        }

        protected static Uri Patch(Uri __instance)
        {
            return new Uri(__instance.ToString().Replace("wss:", "ws:"));
        }
    }
}
