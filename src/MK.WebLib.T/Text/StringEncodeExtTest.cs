using System;
using System.Text;
using NUnit.Framework;

namespace MK.Text
{
	[TestFixture]
	public class StringEncodeExtTest
	{
		[Test]
		public void EndecodeNullValue()
		{
			string x = null;
			var y = StringEncodeExt.Endecode(x, Encoding.UTF8, Encoding.ASCII);

			Assert.IsNull(y);
		}

		[Test]
		public void EndecodeUtf8ToWin1251()
		{
			string x = "ё, привет дружочек, asdf! 123 0";
			var y = StringEncodeExt.Endecode(x, Encoding.UTF8, Encoding.GetEncoding(1251));

			Assert.IsInstanceOf(typeof(string), y);
			Assert.AreEqual("ё, привет дружочек, asdf! 123 0", y);
		}
	}
}
