using System.Reflection;
using UnityEngine.Networking;
using Haru.Modules.Models;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class UnityWebRequestPatch : PostfixPatch
    {
        public UnityWebRequestPatch() : base("com.haru.unitywebrequest")
        {
        }

        protected override MethodBase GetOriginalMethod()
        {
            return typeof(UnityWebRequestTexture)
                .GetMethod(nameof(UnityWebRequestTexture.GetTexture), new[] { typeof(string) });
        }

        protected static void Patch(ref UnityWebRequest __result)
        {
            __result.certificateHandler = new FakeCertificateHandler();
        }
    }
}
