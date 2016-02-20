using System;
using System.Collections.Specialized;
using System.Text;
using System.Net;
//using System.Collections;
//using System.Collections.Generic;

namespace MK.Web
{
	public class FormDataCollection :
		NameValueCollection
		//, IDictionary<string, string>
	{
		public override string ToString()
		{
			StringBuilder s = new StringBuilder();
			for (int i = 0; i < this.Count; i++)
			{
				if (i != 0)
					s.Append("&");
				s.Append(WebUtility.UrlEncode(this.Keys[i]));
				s.Append("=");
				s.Append(WebUtility.UrlEncode(this[i]));
			}
			return s.ToString();
		}
	}
}
