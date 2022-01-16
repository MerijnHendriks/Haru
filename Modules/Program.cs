using System.Collections.Generic;
using Haru.Modules.Patches;
using Haru.Modules.Reflection;

namespace Haru.Modules
{
    public class Program
    {
        public static void Main()
        {
            var patches = new List<APatch>()
            {
                new BattlEyePatch(),
                new CheckMultiplePatch(),
                new CheckSinglePatch(),
                new CertificatePatch(),
                new UnityWebRequestPatch(),
                new WebSocketPatch()
            };

            foreach (var patch in patches)
            {
                patch.Enable();
            }
        }
    }
}
