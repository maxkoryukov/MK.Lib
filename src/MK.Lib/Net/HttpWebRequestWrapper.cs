using System;
using System.Net;
using System.IO;



namespace MK.Net
{
	public class HttpWebRequestWrapper
		: IHttpWebRequest
	{
		private readonly HttpWebRequest _r;

		public HttpWebRequestWrapper(HttpWebRequest request)
		{
			this._r = request;
		}

		public IHttpWebResponse GetResponse()
		{
			return new HttpWebResponseWrapper((HttpWebResponse)this._r.GetResponse());
		}

		public Stream GetRequestStream()
		{
			return this._r.GetRequestStream();
		}

		public string UserAgent
		{
			get { return this._r.UserAgent; }
			set { this._r.UserAgent = value; }
		}
		public IWebProxy Proxy
		{
			get { return this._r.Proxy; }
			set { this._r.Proxy = value; }
		}
		public int Timeout
		{
			get { return this._r.Timeout; }
			set { this._r.Timeout = value; }
		}
		public bool AllowAutoRedirect
		{
			get { return this._r.AllowAutoRedirect; }
			set { this._r.AllowAutoRedirect = value; }
		}
		public string Method
		{
			get { return this._r.Method; }
			set { this._r.Method = value; }
		}
		public string Accept
		{
			get { return this._r.Accept; }
			set { this._r.Accept = value; }
		}
		public string Referer
		{
			get { return this._r.Referer; }
			set { this._r.Referer = value; }
		}
		public string ContentType
		{
			get { return this._r.ContentType; }
			set { this._r.ContentType = value; }
		}

		public WebHeaderCollection Headers
		{
			get { return this._r.Headers; }
			set { this._r.Headers = value; }
		}
		public ICredentials Credentials
		{
			get { return this._r.Credentials; }
			set { this._r.Credentials = value; }
		}
		public long ContentLength
		{
			get { return this._r.ContentLength; }
			set { this._r.ContentLength = value; }
		}

		public Uri RequestUri
		{
			get { return this._r.RequestUri; }
		}
	}


}