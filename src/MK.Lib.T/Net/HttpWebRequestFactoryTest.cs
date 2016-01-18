using System;
using System.Net;
using System.IO;

using NUnit.Framework;

namespace MK.Net
{
	[TestFixture]
	public class HttpWebRequestFactoryTest
	{
		[Test]
		public void CreateWithUri()
		{
			var f = new HttpWebRequestFactory();
			var url = "http://example.com/my/home?url=1";
			var u = new Uri(url);
			var r = f.Create(u);

			Assert.IsNotNull(f);
			Assert.IsAssignableFrom(typeof(HttpWebRequestWrapper), r);

			Assert.AreEqual(u, r.RequestUri);
			Assert.AreEqual(url, r.RequestUri.ToString());
		}
	}
}