using System.Linq;
using UnityEngine.Networking;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
	public class CertificatePatch : PrefixPatch
	{
		public CertificatePatch() : base("certificate.patches.haru")
		{
			OriginalMethod = PatchConstants.EftTypes
				.Single(x => x.BaseType == typeof(CertificateHandler))
				.GetMethod("ValidateCertificate", PatchConstants.PrivateFlags);
		}

		protected static bool Patch(ref bool __result)
		{
			__result = true;
			return false;
		}
	}
}
