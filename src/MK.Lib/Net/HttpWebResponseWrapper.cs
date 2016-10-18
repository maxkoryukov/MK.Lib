using System;
using System.Net;
using System.IO;



namespace MK.Net
{
	public class HttpWebResponseWrapper
		: IHttpWebResponse
	{
		private HttpWebResponse _r;
		private bool _AllowStreamReread;
		private MemoryStream _StreamCopy;

		public HttpWebResponseWrapper(HttpWebResponse response, bool allow_stream_reread = true)
		{
			this._r = response;

			this._AllowStreamReread = allow_stream_reread;
			this._StreamCopy = null;
		}

		public void Dispose()
		{
			this.Dispose(true);
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
				if (this._StreamCopy != null)
				{
					this._StreamCopy.Dispose();
					this._StreamCopy = null;
				}
			}
		}

		// TODO : #2 Rethrow exception on second call to method, if the first call had raised exception.

		/// <summary>
		/// Gets the stream that is used to read the body of the response from the server.
		/// 
		/// IMPORTANT: NOT THREAD-SAFE!!!
		/// </summary>
		/// 
		/// <returns>A <see cref="System.IO.Stream"/> containing the body of the response.</returns>
		/// 
		/// <exception cref="System.Net.ProtocolViolationException">
		/// There is no response stream.
		/// </exception>
		/// 
		/// <exception cref="System.ObjectDisposedException">
		/// The current instance has been disposed.
		/// </exception>
		public Stream GetResponseStream()
		{
			// if the stream is not rereadable:
			if (!this._AllowStreamReread)
				return this._r.GetResponseStream();
			// stream should be rereadable:
			if (null == this._StreamCopy)
			{
				this._StreamCopy = new MemoryStream();
				using (var rs = this._r.GetResponseStream())
				{
					rs.CopyTo(this._StreamCopy);
				}
			}

			var stream = new MemoryStream();

			this._StreamCopy.Position = 0;
			this._StreamCopy.CopyTo(stream);
			stream.Position = 0;
			return stream;
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
		public long ContentLength
		{
			get { return this._r.ContentLength; }
			set { this._r.ContentLength = value; }
		}
	}


}