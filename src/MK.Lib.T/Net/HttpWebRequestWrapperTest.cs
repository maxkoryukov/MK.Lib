using System;
//using System.Net;
//using System.IO;

using NUnit.Framework;
using System.Collections.Generic;

namespace MK.Net
{
	[TestFixture]
	public class HttpWebRequestWrapperCrossStringTest
	{
		HttpWebRequestWrapper r;
		Dictionary<string, string> val;

		Dictionary<string, Acc> fu;

		class Acc: MK.Collections.Generic.Pair<Action<string>, Func<string>>
		{
			public Action<string> Set { get { return this.A; } }
			public Func<string> Get { get { return this.B; } }
		}

		[SetUp]
		public void SetUp()
		{
			var f = new HttpWebRequestFactory();
			this.r = f.Create("http://example.com") as HttpWebRequestWrapper;

			val = new Dictionary<string, string>();
			fu = new Dictionary<string,Acc>() {
				{ "Accept",			new Acc() { A = (x) => { this.r.Accept = x; },		B = () => { return r.Accept;} } },
				{ "ContentType",	new Acc() { A = (x) => { this.r.ContentType = x; },	B = () => { return r.ContentType;} } },
				{ "Method",			new Acc() { A = (x) => { this.r.Method = x; },		B = () => { return r.Method;} } },
				{ "Referer",		new Acc() { A = (x) => { this.r.Referer = x; },		B = () => { return r.Referer;} } },
				{ "UserAgent",		new Acc() { A = (x) => { this.r.UserAgent = x; },	B = () => { return r.UserAgent;} } }
			};
		}

		[Test, Combinatorial]
		public void TestCrossRandomString(
			[Values(
				"Accept",
				"ContentType",
				"Method",
				"Referer",
				"UserAgent")] 
			string propname
			)
		{
			string x;

			// set up fields:
			foreach (var prop in fu.Keys)
			{
				x = MK.Ext.StringExt.AppendRandom(prop, 15);
				val[prop] = x;
				fu[prop].Set(x);
			}

			// change one field
			x = MK.Ext.StringExt.AppendRandom("", 15);
			val[propname] = x;
			fu[propname].Set(x);

			// check all fields:
			foreach (var prop in fu.Keys)
			{
				var expected = val[prop];
				var actual = fu[prop].Get();

				Assert.AreEqual(expected, actual, "I change " + propname + " but the " + prop + " also changed");
			}
		}

	}
}