using System;
using System.Text;
using NUnit.Framework;

namespace MK.Text
{
	[TestFixture]
	public class StringEncodeExtTest
	{
		[Test]
		public void RecodeNullValue()
		{
			string x = null;
			var y = StringEncodeExt.Recode(x, Encoding.UTF8, Encoding.ASCII);

			Assert.IsNull(y);
		}

		[Test]
		public void RecodeUtf8ToWin1251()
		{
			string x = "ё, привет дружочек, asdf! 123 0";
			var y = StringEncodeExt.Recode(x, Encoding.UTF8, Encoding.GetEncoding(1251));

			Assert.IsInstanceOf(typeof(string), y);
			Assert.AreEqual("ё, привет дружочек, asdf! 123 0", y);
		}

		[Test]
		public void ToBase64()
		{
			string n = null;
			Assert.IsNull(StringEncodeExt.ToBase64(n));

			Assert.AreEqual("a".ToBase64(), "YQ==");
			Assert.AreEqual("123".ToBase64(), "MTIz");
		}

		[Test]
		public void FromBase64()
		{
			string n = null;
			Assert.IsNull(StringEncodeExt.FromBase64(n));

			Assert.AreEqual("YQ==".FromBase64(), "a");
			Assert.AreEqual("MTIz".FromBase64(), "123");
		}

		[Test]
		public void Base64_IdempotentNull()
		{
			Assert.AreEqual(StringEncodeExt.FromBase64(StringEncodeExt.ToBase64(null)), null);
			Assert.AreEqual(StringEncodeExt.ToBase64(StringEncodeExt.FromBase64(null)), null);
		}

		[Test]
		public void Base64_IdempotentToFromNotNull()
		{
			foreach (var s in new string[] { "", "a!&911", "maksim", "MFAFA_GAG_aga-fa-fa-fa-Babana" })
			{
				Assert.AreEqual(s.ToBase64().FromBase64(), s);
			}
		}
		[Test]
		public void Base64_IdempotentFromToNotNull()
		{
			foreach (var s in new string[] { "==", "YXNkZg==", "a2VuZA==", "4amdaA==" })
			{
				Assert.AreEqual(s.ToBase64().FromBase64(), s);
			}
		}
	}
}
