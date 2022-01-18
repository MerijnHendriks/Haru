using EFT;
using FilesChecker;
using Haru.Modules.Patches;
using Haru.Modules.Providers;

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
            var types = TypeProvider.Instance;
            var patches = PatchProvider.Instance;

            // add types
            types.Add("EFT", typeof(AbstractGame).Assembly.GetTypes());
            types.Add("FILESCHECKER", typeof(ICheckResult).Assembly.GetTypes());

            // load patches
            patches.Add<BattlEyePatch>();
            patches.Add<VerifyMultiplePatch>();
            patches.Add<VerifySinglePatch>();
            patches.Add<CertificatePatch>();
            patches.Add<TextureRequestPatch>();
            patches.Add<WebSocketPatch>();
            patches.EnableAll();
        }
    }
}
