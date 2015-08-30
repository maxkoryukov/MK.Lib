using System;

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
	}
}