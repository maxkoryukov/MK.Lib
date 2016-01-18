using System;
using System.Net;
using System.IO;



namespace MK.Net
{
	public class HttpWebRequestFactory : IHttpWebRequestFactory
	{
		public IHttpWebRequest Create(string uri)
		{
			return new HttpWebRequestWrapper((HttpWebRequest)HttpWebRequest.Create(uri));
		}
		public IHttpWebRequest Create(Uri uri)
		{
			return new HttpWebRequestWrapper((HttpWebRequest)HttpWebRequest.Create(uri));
		}
	}
}