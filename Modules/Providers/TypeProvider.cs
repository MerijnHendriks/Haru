using System;
using System.Collections.Generic;
using Haru.Shared.Generics;

namespace Haru.Modules.Providers
{
    /// <summary>
    /// Type provider
    /// </summary>
    public class TypeProvider : Singleton<TypeProvider>, IProvider<Type[]>
    {
        public Dictionary<string, Type[]> Entries { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TypeProvider()
        {
            Entries = new Dictionary<string, Type[]>();
        }

        /// <summary>
        /// Add types
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="types">Types</param>
        public void Add(string name, Type[] types)
        {
            Entries.Add(name, types);
        }

        /// <summary>
        /// Get types
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Types</returns>
        public Type[] Get(string name)
        {
            return Entries[name];
        }
    }
}
