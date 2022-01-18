using System.Reflection;

namespace Haru.Modules.Reflection
{
    /// <summary>
    /// Binding flags
    /// </summary>
    public static class Flags
    {
        public const BindingFlags PrivateInstance = BindingFlags.NonPublic | BindingFlags.Instance;
        public const BindingFlags PrivateStatic = BindingFlags.NonPublic | BindingFlags.Static;
        public const BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance;
        public const BindingFlags PublicStatic = BindingFlags.Public | BindingFlags.Static;
    }
}