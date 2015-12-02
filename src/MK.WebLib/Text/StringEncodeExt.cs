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

		public static string Endecode(this string s, Encoding from, Encoding to)
		{
			if (null == s)
				return null;

			var bytes = from.GetBytes(s);
			bytes = Encoding.Convert(from, to, bytes);
			var msg = to.GetString(bytes);
			return msg;
		}
	}
}