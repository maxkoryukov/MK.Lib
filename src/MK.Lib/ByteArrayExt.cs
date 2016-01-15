using System;

namespace MK
{
	public static class ByteArrayExt
	{
		public static string ToString(this byte [] bytes, string format)
		{
			if (null == bytes)
				return null;

			System.Text.StringBuilder res = new System.Text.StringBuilder();
			foreach (var b in bytes)
				res.Append(b.ToString(format));
			return res.ToString();
		}
	}
}