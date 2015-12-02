using System;
using System.Collections.Generic;

namespace MK
{
	public static class NullableCompareExt
	{
		public static int Compare<T>(this Nullable<T> a, Nullable<T> b)
			where T : struct, IComparable<T>
		{
			if (!a.HasValue && !b.HasValue)
				return 0;
			if (a.HasValue && b.HasValue)
				return a.Value.CompareTo(b.Value);
			if (a.HasValue)
				return -1;

			//if (b.HasValue)
			return 1;
		}
	}
}