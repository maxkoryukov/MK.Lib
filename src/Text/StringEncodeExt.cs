using System;
using System.Text;
using System.Globalization;

namespace MK.Text
{
	public static class StringEncodeExt
	{
		/// <summary>
		/// Return substring, which contains up to maxlen chars. If you need - it can append trailing ellipsis.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="maxlen"></param>
		/// <param name="trailing_for_long"></param>
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
	}
}