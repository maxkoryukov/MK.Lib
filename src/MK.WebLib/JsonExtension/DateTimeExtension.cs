using System;

namespace MK.WebLib.JsonExtension
{
	/// <summary>
	/// Расширения для даты-времени
	/// </summary>
	public static class DateTimeExtension
	{
		private static readonly DateTime D1970_01_01 = new DateTime(1970, 1, 1);
		public static string JsonValue(this DateTime d)
		{
			return "( new Date(" + System.Convert.ToInt64 ((d - D1970_01_01).TotalMilliseconds) + "))";
		}
	}
}