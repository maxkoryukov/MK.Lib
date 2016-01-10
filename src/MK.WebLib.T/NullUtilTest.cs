using System;
using NUnit.Framework;

namespace MK
{
	[TestFixture]
	public class NullUtilTest
	{
		[Test]
		public void EqualInt()
		{
			int? x = 1;
			int? y = 1;
			Assert.AreEqual(0, NullUtil.CompareSort(x, y));

			x = null;
			y = null;
			Assert.AreEqual(0, NullUtil.CompareSort(x, y));
		}

		[Test]
		public void LessInt()
		{
			int? x = 0;
			int? y = 1;
			Assert.AreEqual(-1, NullUtil.CompareSort(x, y));

			x = null;
			Assert.AreEqual(-1, NullUtil.CompareSort(x, y));
		}

		[Test]
		public void GreaterInt()
		{
			int? x = 100;
			int? y = 1;
			Assert.AreEqual(1, NullUtil.CompareSort(x, y));

			y = null;
			Assert.AreEqual(1, NullUtil.CompareSort(x, y));
		}
	}
}