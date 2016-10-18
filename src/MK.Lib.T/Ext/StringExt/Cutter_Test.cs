using System;
using NUnit.Framework;

namespace MK.Ext.StringExtT
{
	[TestFixture]
	public class Cutter_Test
	{
		[Test]
		[TestCase(null, -4)]
		[TestCase(null, 0)]
		[TestCase(null, 2)]
		[TestCase("", 5)]
		[TestCase("x", 5)]
		[TestCase("asdf", 4)]
		[TestCase("абвгя", 5)]
		public void TestShortStringsWithoutChanges(string origin, int maxlen)
		{
			var act = StringExt.Cutter(origin, maxlen);
			Assert.That(act, Is.EqualTo(origin));

			act = StringExt.Cutter(origin, maxlen, null);
			Assert.That(act, Is.EqualTo(origin));
		}

		[TestCase("LongString", 8, "...x", "Long...x")]
		public void TestCutWithCustomEnd(string origin, int maxlen, string elipsis, string exp)
		{
			var act = StringExt.Cutter(origin, maxlen, elipsis);
			Assert.That(act, Is.EqualTo(exp));
		}

		[TestCase("xyzF", 3, "***|***|***", "***")]
		public void TestCutterShortStringWithLongTail(string origin, int maxlen, string elipsis, string exp)
		{
			var act = StringExt.Cutter(origin, maxlen, elipsis);
			Assert.That(act, Is.EqualTo(exp));
		}

		[TestCase("xyzF", -3, "...")]
		public void TestCutterToNegativeLength(string origin, int maxlen, string elipsis)
		{
			var e = Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				origin.Cutter(maxlen, elipsis);
			}
			);
			Assert.That(e.ParamName, Is.EqualTo("maxlen")); 
		}

		[TestCase("xyzF", "...")]
		[TestCase("Хээллоу, пипл1", "...")]
		public void TestCutterToZeroLength(string origin, string elipsis)
		{
			var act = origin.Cutter(0, elipsis);
			Assert.That(act, Is.EqualTo(""));
		}
	}
}
