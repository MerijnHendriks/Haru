using Haru.Modules.Reflection;
using Haru.Shared.Generics;

namespace Haru.Modules.Providers
{
    /// <summary>
    /// Type provider
    /// </summary>
    public class PatchProvider : Singleton<PatchProvider>
    {
        private readonly Provider<APatch> _provider;

        /// <summary>
        /// Constructor
        /// </summary>
        public PatchProvider()
        {
            _provider = new Provider<APatch>();
        }

        /// <summary>
        /// Add patch
        /// </summary>
        /// <param name="patch">Patch</param>
        public void Add(APatch patch)
        {
            _provider.Add(patch.Name, patch);
        }

        /// <summary>
        /// Enable patch
        /// </summary>
        /// <param name="name">Name</param>
        public void Enable(string name)
        {
            _provider.Entries[name].Enable();
        }

        /// <summary>
        /// Enable all patches
        /// </summary>
        public void EnableAll()
        {
            foreach (var patch in _provider.Entries.Values)
            {
                patch.Enable();
            }
        }
    }
}
