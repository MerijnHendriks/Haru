using System;
using Haru.Shared.Generics;

namespace Haru.Modules.Providers
{
    /// <summary>
    /// Type provider
    /// </summary>
    public class TypeProvider : Singleton<TypeProvider>
    {
        private readonly Provider<Type[]> _provider;

        /// <summary>
        /// Constructor
        /// </summary>
        public TypeProvider()
        {
            _provider = new Provider<Type[]>();
        }

        /// <summary>
        /// Add types
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <param name="types">Types</param>
        public void Add(string name, Type[] types)
        {
            _provider.Add(name, types);
        }

        /// <summary>
        /// Get types
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <returns>Types</returns>
        public Type[] Get(string name)
        {
            return _provider.Get(name);
        }
    }
}
