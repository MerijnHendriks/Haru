using System.Collections.Generic;

namespace Haru.Shared.Generics
{
    /// <summary>
    /// Data collection
    /// </summary>
    public class Provider<T>
    {
        public readonly Dictionary<string, T> Entries;

        /// <summary>
        /// Constructor
        /// </summary>
        public Provider()
        {
            Entries = new Dictionary<string, T>();
        }

        /// <summary>
        /// Add entry
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <param name="data">Data</param>
        public void Add(string name, T data)
        {
            Entries.Add(name, data);
        }

        /// <summary>
        /// Get entry
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <returns>Data</returns>
        public T Get(string name)
        {
            return Entries[name];
        }

        /// <summary>
        /// Set entry
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <param name="data">Data</param>
        public void Set(string name, T data)
        {
            Entries[name] = data;
        }

        /// <summary>
        /// Remove entry
        /// </summary>
        /// <param name="name">Identifier</param>
        public void Remove(string name)
        {
            Entries.Remove(name);
        }
    }
}
