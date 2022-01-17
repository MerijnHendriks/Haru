using System.Collections.Generic;
using EFT;
using FilesChecker;
using Haru.Modules.Patches;
using Haru.Modules.Reflection;

namespace Haru.Modules
{
    public class Program
    {
        public static void Main()
        {
            LoadTypes();
            LoadPatches();            
        }

        private static void LoadTypes()
        {
            TypeProvider.Add("EFT", typeof(AbstractGame).Assembly.GetTypes());
            TypeProvider.Add("FILESCHECKER", typeof(ICheckResult).Assembly.GetTypes());
        }

        private static void LoadPatches()
        {
            var patches = new List<APatch>()
            {
                new BattlEyePatch(),
                new VerifyMultiplePatch(),
                new VerifySinglePatch(),
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
