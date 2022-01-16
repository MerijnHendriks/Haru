using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace Haru.Modules.Reflection
{
    public abstract class ModulePatch
    {
        private readonly Harmony _harmony;
        private readonly List<HarmonyMethod> _prefixList;
        private readonly List<HarmonyMethod> _postfixList;
        protected MethodBase TargetMethod;

        protected ModulePatch()
        {
            _harmony = new Harmony(GetType().Name);
            _prefixList = GetPatches<PatchPrefixAttribute>();
            _postfixList = GetPatches<PatchPostfixAttribute>();

            if (_prefixList.Count == 0 && _postfixList.Count == 0)
            {
                throw new Exception($"{_harmony.Id}: At least one method with a patch attribute must exist");
            }
        }

        private List<HarmonyMethod> GetPatches<T>() where T : PatchAttribute
        {
            var result = new List<HarmonyMethod>();
            var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            var methods = GetType().GetMethods(flags);

	        foreach (var mi in methods)
	        {
                if (Attribute.IsDefined(mi, typeof(T)))
                {
                    result.Add(new HarmonyMethod(mi));
                }
	        }

            return result;
        }

        public void Enable()
        {
            try
            {
                if (TargetMethod == null)
                {
                    throw new InvalidOperationException("TargetMethod is null");
                }

                foreach (var harmonyMethod in _prefixList)
                {
                    _harmony.Patch(TargetMethod, prefix: harmonyMethod);
                }

                foreach (var harmonyMethod in _postfixList)
                {
                    _harmony.Patch(TargetMethod, postfix: harmonyMethod);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{_harmony.Id}:", ex);
            }
        }
    }
}
