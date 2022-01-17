using System.Reflection;
using UnityEngine.Networking;
using Haru.Modules.Models;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    /// <summary>
    /// Patch to make certificates always successfully validate
    /// </summary>
    public class UnityWebRequestPatch : PostfixPatch
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UnityWebRequestPatch() : base("com.haru.unitywebrequest")
        {
        }

        /// <summary>
        /// Get the original method from lookup pattern
        /// </summary>
        /// <returns>Original method</returns>
        protected override MethodBase GetOriginalMethod()
        {
            return typeof(UnityWebRequestTexture)
                .GetMethod(nameof(UnityWebRequestTexture.GetTexture), new[] { typeof(string) });
        }

        /// <summary>
        /// Patch the original method
        /// </summary>
        protected static void Patch(ref UnityWebRequest __result)
        {
            __result.certificateHandler = CertificateResult.Instance;
            __result.disposeCertificateHandlerOnDispose = false;
        }
    }
}
