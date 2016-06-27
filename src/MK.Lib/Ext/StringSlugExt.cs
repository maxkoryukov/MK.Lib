using System;
//using System.Text;
using System.Text.RegularExpressions;

namespace MK.Ext
{
	public static class StringSlugExt
	{
		private static readonly Regex _ReplaceForbidden = new Regex(@"[^-a-zA-Z\d]", RegexOptions.Compiled);
		private static readonly Regex _ReplaceDupMinus = new Regex(@"--+", RegexOptions.Compiled);

		/// <summary>
		/// Convert to slug (well-URL)
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ToSlug(this string str)
		{
			if (null == str)
				return null;

			var res = _ReplaceForbidden.Replace(str, "-");
			res = _ReplaceDupMinus.Replace(res, "-");
			return res;
		}
	}
}