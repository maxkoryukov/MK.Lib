using System;

namespace MK
{
	public static class NullUtil
	{
		/// <summary>
		/// Compare nullable. IMPORTANT: Compare(null, null) = 0 , its SORTING FUNCTION
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int CompareSort<T>(Nullable<T> a, Nullable<T> b)
			where T : struct, IComparable<T>
		{
			if (!a.HasValue && !b.HasValue)
				return 0;
			if (a.HasValue && b.HasValue)
				return a.Value.CompareTo(b.Value);
			if (a.HasValue)
				return 1;

			//if (b.HasValue)
			return -1;
		}
	}
}