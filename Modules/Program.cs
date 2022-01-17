using System.Collections.Generic;
using EFT;
using FilesChecker;
using Haru.Modules.Patches;
using Haru.Modules.Reflection;

namespace Haru.Modules
{
    /// <summary>
    /// Main application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        public static void Main()
        {
            LoadTypes();
            LoadPatches();            
        }

        /// <summary>
        /// Get all types of used assemblies
        /// </summary>
        private static void LoadTypes()
        {
            TypeProvider.Add("EFT", typeof(AbstractGame).Assembly.GetTypes());
            TypeProvider.Add("FILESCHECKER", typeof(ICheckResult).Assembly.GetTypes());
        }

        /// <summary>
        /// Apply all patches
        /// </summary>
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
