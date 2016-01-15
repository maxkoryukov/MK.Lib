using System;

namespace MK.Ext
{
	/// <summary>
	/// DateTime Json Extensions
	/// </summary>
	public static class DateTimeJsonExt
	{
		private static readonly DateTime D1970_01_01 = new DateTime(1970, 1, 1);
		public static string JsonValue(this DateTime d)
		{
			return "( new Date(" + ((d.Ticks - D1970_01_01.Ticks) / 10000) + "))";
		}
	}
}