using System;
using System.Reflection;
using HarmonyLib;

namespace Haru.Modules.Reflection
{
    public abstract class APatch
    {
        protected readonly Harmony Harmony;
        protected MethodBase OriginalMethod;

        protected APatch(string name)
        {
            Harmony = new Harmony(name);
        }

        protected abstract void Add(MethodBase original, HarmonyMethod patch);

        public void Enable()
        {
            var type = GetType();

            try
            {
                // check original method
                if (OriginalMethod == null)
                {
                    throw new InvalidOperationException("OriginalMethod is null");
                }

                // get patch method
                var mi = type.GetMethod("Patch", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

                if (mi == null)
                {
                    throw new InvalidOperationException($"A protected static Patch method must exist inside {type.ToString()}");
                }

                var PatchMethod = new HarmonyMethod(mi);
                
                // patch original method
                Add(OriginalMethod, PatchMethod);
            }
            catch (Exception ex)
            {
                throw new Exception($"{type.ToString()}:", ex);
            }
        }
    }
}
