using System;
using System.Reflection;
using EFT;
using FilesChecker;

namespace Haru.Modules.Reflection
{
    public static class PatchConstants
    {
        public const BindingFlags PrivateFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
        public const BindingFlags PublicFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        public static readonly Type[] EftTypes;
        public static readonly Type[] FilesCheckerTypes;

        static PatchConstants()
        {
            EftTypes = typeof(AbstractGame).Assembly.GetTypes();
            FilesCheckerTypes = typeof(ICheckResult).Assembly.GetTypes();
        }
    }
}
