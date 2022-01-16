using System;

namespace Haru.Modules.Reflection
{
    public abstract class PatchAttribute : Attribute
    {
    }

	[AttributeUsage(AttributeTargets.Method)]
	public class PatchPrefixAttribute : PatchAttribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
	public class PatchPostfixAttribute : PatchAttribute
    {
    }
}
