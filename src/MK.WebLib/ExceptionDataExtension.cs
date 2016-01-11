using System;

namespace MK
{
	/// <summary>
	/// Set mark on exception
	/// </summary>
	public static class ExceptionDataExtension
	{
		#region Mark Helper
		public const string Mark = "own-exc-flag";

		public static bool GetMark(this Exception e)
		{
			if (!HasData(e, Mark))
				return false;

			var b = GetData(e, Mark);
			if (b is bool)
				return (bool)b;

			return false;
		}

		public static Exception SetMark(this Exception e)
		{
			return SetData(e, Mark, true);
		}
		#endregion

		#region Data Helper
		public static bool HasData(this Exception e, string key)
		{
			return e.Data.Contains(key);
		}

		public static Exception SetData(this Exception e, string key, object value)
		{
			if (!e.Data.Contains(key))
				e.Data.Add(key, value);
			else
				e.Data[key] = value;

			return e;
		}

		public static object GetData(this Exception e, string key)
		{
			if (!HasData(e, key))
				throw new ArgumentOutOfRangeException("key", key, "No such key in data collection");

			return e.Data[key];
		}
		#endregion
	}
}