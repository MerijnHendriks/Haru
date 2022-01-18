using System.Collections.Generic;
using Haru.Launcher.Processes;
using Haru.Shared.Generics;

namespace Haru.Launcher.Providers
{
    /// <summary>
    /// Process provider
    /// </summary>
    public class ProcessProvider : Singleton<ProcessProvider>, IProvider<AProcess>
    {
        public Dictionary<string, AProcess> Entries { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessProvider()
        {
            Entries = new Dictionary<string, AProcess>();
        }

        /// <summary>
        /// Add process
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="process">Process</param>
        public void Add(string name, AProcess process)
        {
            Entries.Add(name, process);
        }

        /// <summary>
        /// Add process
        /// </summary>
        /// <param name="name">Name</param>
        /// <typeparam name="T">Process</typeparam>
        public void Add<T>(string name) where T : AProcess, new()
        {
            var process = new T();
            Entries.Add(name, process);
        }

        /// <summary>
        /// Get process
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Types</returns>
        public AProcess Get(string name)
        {
            return Entries[name];
        }

        /// <summary>
        /// Start process
        /// </summary>
        /// <param name="name">Name</param>
        public void Start(string name)
        {
            Entries[name].Start();
        }

        /// <summary>
        /// Start all processes
        /// </summary>
        public void StartAll()
        {
            foreach (var name in Entries.Keys)
            {
                Start(name);
            }
        }

        /// <summary>
        /// Terminate process
        /// </summary>
        /// <param name="name">Name</param>
        public void Terminate(string name)
        {
            Entries[name].Terminate();
        }

        /// <summary>
        /// Terminate all processes
        /// </summary>
        public void TerminateAll()
        {
            foreach (var name in Entries.Keys)
            {
                Terminate(name);
            }
        }
    }
}
