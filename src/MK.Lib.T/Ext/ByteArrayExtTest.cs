using System;
using NUnit.Framework;
using System.Collections;

namespace MK.Ext
{
	using MK.Ext;

	[TestFixture]
	public class ByteArrayExtTest
	{
		public static IEnumerable ByteToStringCases()
		{
			yield return new object[] { new byte[] { 1 }, "x2", "01" };
			yield return new object[] { new byte[] { 15 }, "x2", "0f" };
			yield return new object[] { new byte[] { 10, 15 }, "X2", "0A0F" };
		}

		[Test]
		[TestCaseSource("ByteToStringCases")]
		public void ByteToString(byte[] bytes, string format, string exp)
		{
			var act = bytes.ToString(format);
			Assert.That(act, Is.EqualTo(exp));
		}

		[Test]
		[TestCase(null)]
		public void NullToString(byte [] bytes)
		{
			var act = bytes.ToString("x2");
			Assert.That(act, Is.Null);
		}
	}
}