using System;
using NUnit.Framework;

namespace MK.Ext.StringExtT
{
	[TestFixture]
	public class RemoveDiacritics_Test
	{
		[Test]
		[TestCase(null)]
		[TestCase("")]
		[TestCase("x")]
		[TestCase("asdf")]
		[TestCase("абвгя")]
		[TestCase("абВгФ 123 -123№;%:")]
		public void TestInvariants(string origin)
		{
			var act = StringExt.RemoveDiacritics(origin);
			Assert.That(act, Is.EqualTo(origin));
		}

		[Test]
		[TestCase("Province of Coclé", "Province of Cocle")]
		public void TestStringsWithDiacritics(string origin, string exp)
		{
			var act = StringExt.RemoveDiacritics(origin);
			Assert.That(act, Is.EqualTo(exp));
		}
	}
}
