using System.Linq;
using System.Reflection;
using UnityEngine.Networking;
using Haru.Modules.Providers;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
	/// <summary>
    /// Patch to make certificates always successfully validate
    /// </summary>
	public class CertificatePatch : PrefixPatch
	{
		/// <summary>
        /// Constructor
        /// </summary>
		public CertificatePatch() : base("com.haru.certificate")
		{
		}

		/// <summary>
        /// Get the original method from lookup pattern
        /// </summary>
        /// <returns>Original method</returns>
		protected override MethodBase GetOriginalMethod()
        {
            return TypeProvider.Instance.Get("EFT")
				.Single(x => x.BaseType == typeof(CertificateHandler))
				.GetMethod("ValidateCertificate", Flags.PrivateInstance);
        }

		/// <summary>
        /// Patch the original method
        /// </summary>
        /// <returns>Execute original method?</returns>
		protected static bool Patch(ref bool __result)
		{
			__result = true;
			return false;
		}
	}
}
