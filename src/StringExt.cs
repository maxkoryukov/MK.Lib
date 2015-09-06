using System;
using System.Text;
using System.Globalization;

namespace MK
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

		public static string AppendRandom(this string src, int length, string char_domain = null)
		{
			int src_len = (string.IsNullOrEmpty(src)) ? 0 : src.Length;

			if (src_len >= length)
				return src;

			if (string.IsNullOrEmpty(char_domain))
				char_domain = RandomPattern;
			
			int len = char_domain.Length;
			var r = new System.Random();

			if (null == src)
				src = "";
			
			while (src_len < length)
			{
				src += char_domain[r.Next(len)];
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
	}
}