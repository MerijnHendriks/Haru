using System;
using System.Reflection;
using HarmonyLib;

namespace Haru.Modules.Reflection
{
    public abstract class APatch
    {
        protected readonly Harmony Harmony;

        protected APatch(string name)
        {
            Harmony = new Harmony(name);
        }

        protected abstract MethodBase GetOriginalMethod();
        protected abstract void Add(MethodBase original, HarmonyMethod patch);

        public void Enable()
        {
            var type = GetType();

            try
            {
                var originalMethod = GetOriginalMethod();
                var patchMethod = type.GetMethod("Patch", Flags.PrivateStatic);

                // validate
                if (originalMethod == null)
                {
                    throw new InvalidOperationException($"GetOrignalMethod returned null");
                }

                if (patchMethod == null)
                {
                    throw new InvalidOperationException($"Method Patch must exist");
                }
                
                // patch original method
                Add(originalMethod, new HarmonyMethod(patchMethod));
            }
            catch (Exception ex)
            {
                throw new Exception($"{type}:", ex);
            }
        }
    }
}
