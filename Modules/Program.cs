using System.Collections.Generic;
using EFT;
using FilesChecker;
using Haru.Modules.Patches;
using Haru.Modules.Providers;
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
            var types = TypeProvider.Instance;
            types.Add("EFT", typeof(AbstractGame).Assembly.GetTypes());
            types.Add("FILESCHECKER", typeof(ICheckResult).Assembly.GetTypes());
        }

        /// <summary>
        /// Apply all patches
        /// </summary>
        private static void LoadPatches()
        {
            var patches = PatchProvider.Instance;

            // add patches
            patches.Add(new BattlEyePatch());
            patches.Add(new VerifyMultiplePatch());
            patches.Add(new VerifySinglePatch());
            patches.Add(new CertificatePatch());
            patches.Add(new UnityWebRequestPatch());
            patches.Add(new WebSocketPatch());

            // enable patches
            patches.EnableAll();
        }
    }
}
