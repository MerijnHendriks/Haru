using System;
using System.Linq;
using System.Reflection;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class WebSocketPatch : PostfixPatch
    {
        public WebSocketPatch() : base("com.haru.websocket")
        {
        }

        protected override MethodBase GetOriginalMethod()
        {
            var types = TypeProvider.Get("EFT");
            var targetInterface = types.Single(x => x.IsInterface && x == typeof(IConnectionHandler));

            return types
                .Single(x => targetInterface.IsAssignableFrom(x) && x.IsAbstract && !x.IsInterface)
                .GetMethods(Flags.PrivateInstance).Single(x => x.ReturnType == typeof(Uri));
        }

        protected static Uri Patch(object __instance)
        {
            var uri = (Uri)__instance;
            return new Uri(uri.ToString().Replace("wss:", "ws:"));
        }
    }
}
