using System.Linq;
using UnityEngine.Networking;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
	public class CertificatePatch : PrefixPatch
	{
		public CertificatePatch() : base("com.haru.certificate")
		{
			OriginalMethod = TypeProvider.Get("EFT")
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
