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
	}
}