using UnityEngine.Networking;
using Haru.Modules.Models;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class UnityWebRequestPatch : ModulePatch
    {
        public UnityWebRequestPatch() : base()
        {
            TargetMethod = typeof(UnityWebRequestTexture)
                .GetMethod(nameof(UnityWebRequestTexture.GetTexture), new[] { typeof(string) });
        }

        [PatchPostfix]
        protected static void PatchPostfix(UnityWebRequest __result)
        {
            __result.certificateHandler = new FakeCertificateHandler();
        }
    }
}
