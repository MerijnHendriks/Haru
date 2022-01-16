using System;
using System.Reflection;
using EFT;
using FilesChecker;

namespace Haru.Modules.Reflection
{
    public static class ModuleConstants
    {
        public const BindingFlags PrivateFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
        public const BindingFlags PublicFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        public static readonly Type[] EftTypes;
        public static readonly Type[] FilesCheckerTypes;

        static ModuleConstants()
        {
            EftTypes = typeof(AbstractGame).Assembly.GetTypes();
            FilesCheckerTypes = typeof(ICheckResult).Assembly.GetTypes();
        }
    }
}
