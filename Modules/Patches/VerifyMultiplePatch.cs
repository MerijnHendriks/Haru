using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FilesChecker;
using Haru.Modules.Models;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class VerifyMultiplePatch : PrefixPatch
    {
        public VerifyMultiplePatch() : base("com.haru.verifymultiple")
        {
        }

        protected override MethodBase GetOriginalMethod()
        {
            return TypeProvider.Get("FILESCHECKER")
                .Single(x => x.Name == "ConsistencyController")
                .GetMethods().Single(x => x.Name == "EnsureConsistency" && x.ReturnType == typeof(Task<ICheckResult>));
        }

        protected static bool Patch(ref object __result)
        {
            __result = Task.FromResult<ICheckResult>(new FakeFileCheckerResult());
            return false;
        }
    }
}
