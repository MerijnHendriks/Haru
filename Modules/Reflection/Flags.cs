using System.Reflection;

namespace Haru.Modules.Reflection
{
    public static class Flags
    {
        public const BindingFlags PrivateInstance = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        public const BindingFlags PrivateStatic = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly;
        public const BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        public const BindingFlags PublicStatic = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;
    }
}