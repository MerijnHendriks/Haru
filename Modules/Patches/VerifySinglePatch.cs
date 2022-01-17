using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FilesChecker;
using Haru.Modules.Models;
using Haru.Modules.Reflection;

namespace Haru.Modules.Patches
{
    public class VerifySinglePatch : PrefixPatch
    {
        public VerifySinglePatch() : base("com.haru.verifysingle")
        {
        }

        protected override MethodBase GetOriginalMethod()
        {
            return TypeProvider.Get("FILESCHECKER")
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