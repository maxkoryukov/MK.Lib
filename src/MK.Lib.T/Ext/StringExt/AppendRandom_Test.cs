﻿using System;
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
		[TestCase(null, 8)]
		[TestCase("", 40)]
		public void WorksOnNullAndEmptyStrings(string s, int len)
		{
			var e = StringExt.AppendRandom(s, len);
			Assert.That(e, Is.Not.Null);
			Assert.That(e, Has.Length.EqualTo(len));
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

		[Test]
		[TestCase(null, 0)]
		[TestCase("", 0)]
		[TestCase("x", 0)]
		[TestCase("x", 1)]
		[TestCase("", -1)]
		[TestCase("", -10)]
		[TestCase("valha", -1)]
		[TestCase("vague", 3)]
		public void ReturnSourceOnLengthExceed(string origin, int len)
		{
			var act = StringExt.AppendRandom(origin, len);
			Assert.That(act, Is.EqualTo(origin));
		}
	}
}
