using System;
using System.Net;
using System.IO;



namespace MK.Net
{
	public interface IHttpWebRequestFactory
	{
		IHttpWebRequest Create(string uri);
		IHttpWebRequest Create(Uri uri);
	}

}