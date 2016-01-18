using System;
using System.Net;
using System.IO;



namespace MK.Net
{
	public interface IHttpWebRequest
	{
		IHttpWebResponse GetResponse();
		Stream GetRequestStream();

		string UserAgent { get; set; }
		IWebProxy Proxy { get; set; }
		int Timeout { get; set; }
		string Method { get; set; }
		string Accept { get; set; }
		string Referer { get; set; }
		string ContentType { get; set; }
		WebHeaderCollection Headers { get; set; }
		bool AllowAutoRedirect { get; set; }
		ICredentials Credentials { get; set; }
		long ContentLength { get; set; }
		Uri RequestUri { get; }
		CookieContainer CookieContainer { get; set; }
	}

}