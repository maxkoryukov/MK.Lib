using System;
using System.Text;
using System.Globalization;

namespace MK.Ext
{
	public static class StringExt
	{
		public static string TrimMortal(this string s)
		{
			if (null == s)
				return null;
			s = s.Trim ();
			if (string.IsNullOrWhiteSpace (s))
				s = null;
			return s;
		}

		public const string RandomPattern = "1234567890abcdefghijklmnopqrstuvwxyz";
		private static Random Randomizer = new Random();

		/// <summary>
		/// Appends random chars to <paramref name="src"/> - string, until its length is less than <paramref name="length"/>
		/// </summary>
		/// <param name="src">Initial, source string. Will be preserved as a prefix.</param>
		/// <param name="min_length">Minimal length of output</param>
		/// <param name="char_domain">Set of chars for random appending</param>
		/// <returns></returns>
		public static string AppendRandom(this string src, int min_length, string char_domain = null)
		{
			int src_len = (string.IsNullOrEmpty(src)) ? 0 : src.Length;

			if (src_len >= min_length)
				return src;

			if ("" == char_domain && min_length > src_len)
				throw new ArgumentException("Can not append chars from empty set. Pass at least one char to char_domain", "char_domain");

			if (null == char_domain)
				char_domain = RandomPattern;
			
			int len = char_domain.Length;

			if (null == src)
				src = "";

			while (src_len < min_length)
			{
				src += char_domain[Randomizer.Next(len)];
				src_len++;
			}

			return src;
		}

		/// <summary>
		/// Removes the diacritics.
		/// </summary>
		/// <seealso cref="http://www.siao2.com/2007/05/14/2629747.aspx"/>
		/// <seealso cref="http://stackoverflow.com/questions/249087"/>
		/// <returns>The diacritics.</returns>
		/// <param name="text">Text.</param>
		public static string RemoveDiacritics(this string text) 
		{
			if (string.IsNullOrEmpty(text))
				return text;

			var ns = text.Normalize(NormalizationForm.FormD);
			var sb = new StringBuilder();

			foreach (var c in ns)
			{
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				{
					sb.Append(c);
				}
			}

			return sb.ToString().Normalize(NormalizationForm.FormC);
		}

		/// <summary>
		/// Return substring, which contains up to maxlen chars. If you need - it can append trailing ellipsis.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="maxlen"></param>
		/// <param name="trailing_for_long"></param>
		/// <returns></returns>
		public static string Cutter(this string s, int maxlen, string trailing_for_long = null)
		{
			if (null == s)
				return s;

			if (maxlen < 0)
				throw new ArgumentOutOfRangeException("maxlen", "must be greater than 0");

			if (0 == maxlen)
				return "";

			int len = s.Length;

			if (len <= maxlen)
				return s;

			int d = 0;
			if (null == trailing_for_long)
				trailing_for_long = "";
			else
				d = trailing_for_long.Length;

			if (d >= maxlen)
			{
				// the tail > maxlen
				return trailing_for_long.Substring(d-maxlen, maxlen);
			}

			return s.Substring(0, maxlen - d) + trailing_for_long;
		}
	}
}