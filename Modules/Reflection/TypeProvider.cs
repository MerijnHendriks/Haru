using System;
using System.Collections.Generic;

namespace Haru.Modules.Reflection
{
    public static class TypeProvider
    {
        private static readonly Dictionary<string, Type[]> _types;

        static TypeProvider()
        {
            _types = new Dictionary<string, Type[]>();
        }

        public static void Add(string name, Type[] types)
        {
            _types.Add(name, types);
        }

        public static Type[] Get(string name)
        {
            return _types[name];
        }
    }
}
