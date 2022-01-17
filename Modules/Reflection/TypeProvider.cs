using System;
using System.Collections.Generic;

namespace Haru.Modules.Reflection
{
    /// <summary>
    /// Type provider
    /// </summary>
    public static class TypeProvider
    {
        private static readonly Dictionary<string, Type[]> _types;

        /// <summary>
        /// Constructor
        /// </summary>
        static TypeProvider()
        {
            _types = new Dictionary<string, Type[]>();
        }

        /// <summary>
        /// Add types
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <param name="types">Assembly types</param>
        public static void Add(string name, Type[] types)
        {
            _types.Add(name, types);
        }

        /// <summary>
        /// Get types
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <returns></returns>
        public static Type[] Get(string name)
        {
            return _types[name];
        }
    }
}
