using System;
using NUnit.Framework;

namespace MK.Ext.StringExtT
{
	[TestFixture]
	public class AppendRandom_Test
	{
		[Test]
		public void NotTheSameOnSimilarTests()
		{
			const string dict = "ab1";
			foreach (var init in new string[] { "12", "", "a", "-", "12", "%" })
			{
				for (int len = 2; len < 50; len++)
				{
					string s1 = null;
					string s2 = null;

					int i = 0;
					do
					{
						var l = len + init.Length;
						s1 = StringExt.AppendRandom(init, l, dict);
						s2 = StringExt.AppendRandom(init, l, dict);
						i++;
					}
					while (i < 5 && s1 == s2);

					Assert.AreNotEqual(s1, s2);
				}
			}
		}

		[Test]
		public void ThrowsOnEmptyDomain()
		{
			var e = Assert.Throws<ArgumentException>(() =>
				{
					"123".AppendRandom(4, "");
				}
			);
			Assert.AreEqual("char_domain", e.ParamName);
		}

		[Test]
		public void NotThrowOnNullDomain()
		{
			Assert.DoesNotThrow(() =>
				{
					"a".AppendRandom(5, null);
				}
			);
		}
	}
}
