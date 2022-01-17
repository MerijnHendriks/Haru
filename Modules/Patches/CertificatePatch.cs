using System.Linq;
using System.Reflection;
using UnityEngine.Networking;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
	public class CertificatePatch : PrefixPatch
	{
		public CertificatePatch() : base("com.haru.certificate")
		{
		}

		protected override MethodBase GetOriginalMethod()
        {
            return TypeProvider.Get("EFT")
				.Single(x => x.BaseType == typeof(CertificateHandler))
				.GetMethod("ValidateCertificate", Flags.PrivateInstance);
        }

		protected static bool Patch(ref bool __result)
		{
			__result = true;
			return false;
		}
	}
}
