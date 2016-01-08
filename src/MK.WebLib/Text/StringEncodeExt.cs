using System;
using System.Text;
using System.Globalization;

namespace MK.Text
{
	public static class StringEncodeExt
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string DecodeUnicode(this string s)
		{
			return System.Text.RegularExpressions.Regex.Replace(
			s,
			@"[%\\]u(?<Value>[a-zA-Z0-9]{4})",
			m =>
			{
				return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
			});
		}

		public static string Recode(this string s, Encoding from, Encoding to)
		{
			if (null == s)
				return null;

			var bytes = from.GetBytes(s);
			bytes = Encoding.Convert(from, to, bytes);
			var msg = to.GetString(bytes);
			return msg;
		}

		/// <summary>
		/// UTF-8 to Base64
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string ToBase64(this string s)
		{
			if (null == s)
				return null;
			return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));
		}

		public static string FromBase64(this string s)
		{
			if (null == s)
				return null;

			var c = s.ToCharArray();
			var x = System.Convert.FromBase64CharArray(c, 0, c.Length);
			return System.Text.Encoding.UTF8.GetString(x);
		}
	}
}