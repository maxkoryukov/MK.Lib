using System;
using NUnit.Framework;

namespace MK.Ext
{
	using MK.Ext;

	[TestFixture]
	public class StringSlugExtTest
	{
		[Test]
		[TestCase("", "")]
		[TestCase("hello", "hello")]
		[TestCase("hel-lo", "hel-lo")]
		[TestCase("x1234567890", "x1234567890")]
		[TestCase("my name is John! hi", "my-name-is-John-hi")]
		[TestCase("2006/01/12 10:00 breaking news", "2006-01-12-10-00-breaking-news")]
		public void ToSlugTest(string input, string exp)
		{
			var act = input.ToSlug();
			Assert.That(act, Is.EqualTo(exp));
		}

		[Test]
		[TestCase(null)]
		public void NullToSlug(string input)
		{
			var act = input.ToSlug();
			Assert.That(act, Is.Null);
		}
	}
}