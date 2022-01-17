using System;
using System.Reflection;
using HarmonyLib;

namespace Haru.Modules.Reflection
{
    /// <summary>
    /// Harmony wrapper
    /// </summary>
    public abstract class APatch
    {
        public readonly string Name;
        protected readonly Harmony Harmony;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Patch name</param>
        protected APatch(string name)
        {
            Name = name;
            Harmony = new Harmony(name);
        }

        /// <summary>
        /// Add patch to original method
        /// </summary>
        /// <param name="original">Original method</param>
        /// <param name="patch">Patch method</param>
        protected abstract void Apply(MethodBase original, HarmonyMethod patch);

        /// <summary>
        /// Get the original method from lookup pattern
        /// </summary>
        /// <returns>Original method</returns>
        protected abstract MethodBase GetOriginalMethod();
        
        /// <summary>
        /// Enable patch
        /// </summary>
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
                Apply(originalMethod, new HarmonyMethod(patchMethod));
            }
            catch (Exception ex)
            {
                throw new Exception($"{type}:", ex);
            }
        }
    }
}
