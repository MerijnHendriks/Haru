using System.Collections.Generic;
using Haru.Modules.Reflection;
using Haru.Shared.Generics;

namespace Haru.Modules.Providers
{
    /// <summary>
    /// Patch provider
    /// </summary>
    public class PatchProvider : Singleton<PatchProvider>, IProvider<APatch>
    {
        public Dictionary<string, APatch> Entries { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PatchProvider()
        {
            Entries = new Dictionary<string, APatch>();
        }

        /// <summary>
        /// Add patch
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="patch">Patch</param>
        public void Add(string name, APatch patch)
        {
            Entries.Add(name, patch);
        }
 
        /// <summary>
        /// Add patch
        /// </summary>
        /// <typeparam name="T">Patch</typeparam>
        public void Add<T>() where T : APatch, new()
        {
            var patch = new T();
            Entries.Add(patch.Name, patch);
        }

        /// <summary>
        /// Get patch
        /// </summary>
        /// <param name="patch">Patch</param>
        public APatch Get(string name)
        {
            return Entries[name];
        }

        /// <summary>
        /// Enable patch
        /// </summary>
        /// <param name="name">Name</param>
        public void Enable(string name)
        {
            Entries[name].Enable();
        }

        /// <summary>
        /// Enable all patches
        /// </summary>
        public void EnableAll()
        {
            foreach (var name in Entries.Keys)
            {
                Enable(name);
            }
        }
    }
}
