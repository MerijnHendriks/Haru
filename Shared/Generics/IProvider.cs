using System.Collections.Generic;

namespace Haru.Shared.Generics
{
    public interface IProvider
    {
    }

    /// <summary>
    /// Data collection
    /// </summary>
    public interface IProvider<T> : IProvider
    {
        Dictionary<string, T> Entries { get; }

        /// <summary>
        /// Add entry
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <param name="data">Data</param>
        void Add(string name, T data);

        /// <summary>
        /// Get entry
        /// </summary>
        /// <param name="name">Identifier</param>
        /// <returns>Data</returns>
        T Get(string name);
    }
}
