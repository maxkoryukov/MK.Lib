using System;

namespace MK.Lib
{
	/// <summary>
	/// For hiding internal classes from coverage calculation
	/// </summary>
	[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Property)]
	internal class ExcludeFromCoverageAttribute : Attribute {}
}
