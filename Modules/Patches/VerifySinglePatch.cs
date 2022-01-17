using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FilesChecker;
using Haru.Modules.Models;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    /// <summary>
    /// Patch to make consistency check always return successful
    /// </summary>
    public class VerifySinglePatch : PrefixPatch
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VerifySinglePatch() : base("com.haru.verifysingle")
        {
        }

        /// <summary>
        /// Get the original method from lookup pattern
        /// </summary>
        /// <returns>Original method</returns>
        protected override MethodBase GetOriginalMethod()
        {
            return TypeProvider.Get("FILESCHECKER")
                .Single(x => x.Name == "ConsistencyController")
                .GetMethods().Single(x => x.Name == "EnsureConsistencySingle" && x.ReturnType == typeof(Task<ICheckResult>));
        }

        /// <summary>
        /// Patch the original method
        /// </summary>
        /// <returns>Execute original method?</returns>
        protected static bool Patch(ref object __result)
        {
            __result = Task.FromResult<ICheckResult>(FileCheckerResult.Instance);
            return false;
        }
    }
}
