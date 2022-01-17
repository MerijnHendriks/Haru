namespace Haru.Shared.Generics
{
    /// <summary>
    /// Singleton
    /// </summary>
    public class Singleton<T> where T : new()
    {
        private static readonly object _lock;
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = new T();
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        static Singleton()
        {
            _lock = null;
            _instance = default;
        }
    }
}
