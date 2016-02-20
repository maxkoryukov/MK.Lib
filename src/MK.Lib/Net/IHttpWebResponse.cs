using System;
using System.Net;
using System.IO;



namespace MK.Net
{
	public interface IHttpWebResponse : IDisposable
	{
		Stream GetResponseStream();
		void Close();

		Uri ResponseUri { get; }
		WebHeaderCollection Headers { get; }
		CookieCollection Cookies { get; set; }
		HttpStatusCode StatusCode { get; }
		string Method { get; }
		long ContentLength { get; set; }
	}

}