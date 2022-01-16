using System.Linq;
using UnityEngine.Networking;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
	public class CertificatePatch : ModulePatch
	{
		public CertificatePatch() : base()
		{
			TargetMethod = ModuleConstants.EftTypes
				.Single(x => x.BaseType == typeof(CertificateHandler))
				.GetMethod("ValidateCertificate", ModuleConstants.PrivateFlags);
		}

		[PatchPrefix]
		protected static bool PatchPrefix(ref bool __result)
		{
			__result = true;
			return false;
		}
	}
}
