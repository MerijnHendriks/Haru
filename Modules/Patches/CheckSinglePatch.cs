using System.Linq;
using System.Threading.Tasks;
using FilesChecker;
using Haru.Modules.Models;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class CheckSinglePatch : PrefixPatch
    {
        public CheckSinglePatch() : base("consistencysingle.patches.haru")
        {
            OriginalMethod = PatchConstants.FilesCheckerTypes
                .Single(x => x.Name == "ConsistencyController")
                .GetMethods().Single(x => x.Name == "EnsureConsistencySingle" && x.ReturnType == typeof(Task<ICheckResult>));
        }

        protected static bool Patch(ref object __result)
        {
            __result = Task.FromResult<ICheckResult>(new FakeFileCheckerResult());
            return false;
        }
    }
}
