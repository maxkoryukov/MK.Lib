using System;
using System.Net;
using System.IO;



namespace MK.Net
{
	public class HttpWebResponseWrapper
		: IHttpWebResponse
	{
		private HttpWebResponse _r;

		public HttpWebResponseWrapper(HttpWebResponse response)
		{
			this._r = response;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this._r != null)
				{
					((IDisposable)this._r).Dispose();
					this._r = null;
				}
			}
		}

		public Stream GetResponseStream()
		{
			return this._r.GetResponseStream();
		}

		public void Close()
		{
			this._r.Close();
		}

		public Uri ResponseUri
		{
			get { return this._r.ResponseUri; }
		}
		public WebHeaderCollection Headers
		{
			get { return this._r.Headers; }
		}
		public CookieCollection Cookies
		{
			get { return this._r.Cookies; }
			set { this._r.Cookies = value; }
		}
		public HttpStatusCode StatusCode
		{
			get { return this._r.StatusCode; }
		}
		public string Method
		{
			get { return this._r.Method; }
		}
	}


}