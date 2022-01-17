using System;
using System.Linq;
using System.Reflection;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    /// <summary>
    /// Patch to use non-ssl websocket connection
    /// </summary>
    public class WebSocketPatch : PostfixPatch
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public WebSocketPatch() : base("com.haru.websocket")
        {
        }

        /// <summary>
        /// Get the original method from lookup pattern
        /// </summary>
        /// <returns>Original method</returns>
        protected override MethodBase GetOriginalMethod()
        {
            var types = TypeProvider.Get("EFT");
            var targetInterface = types.Single(x => x.IsInterface && x == typeof(IConnectionHandler));

            return types
                .Single(x => targetInterface.IsAssignableFrom(x) && x.IsAbstract && !x.IsInterface)
                .GetMethods(Flags.PrivateInstance).Single(x => x.ReturnType == typeof(Uri));
        }

        /// <summary>
        /// Patch the original method
        /// </summary>
        protected static Uri Patch(object __instance)
        {
            var uri = (Uri)__instance;
            return new Uri(uri.ToString().Replace("wss:", "ws:"));
        }
    }
}
