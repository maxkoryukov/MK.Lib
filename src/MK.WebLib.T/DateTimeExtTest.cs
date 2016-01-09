using System;
using NUnit.Framework;

namespace Lib
{
	[TestFixture]
	public class DateTimeExtTest
	{
		[Test]
		public void IsInRangeTrue()
		{
			var d = new DateTime(2015, 03, 12, 11, 15, 1);
			var t = new DateTime(2015, 03, 13, 12, 0, 0);
			var y = new DateTime(2015, 02, 12, 18, 1, 19);

			Assert.IsTrue(d.IsInRange(null, null));
			Assert.IsTrue(d.IsInRange(null, t));
			Assert.IsTrue(d.IsInRange(y, null));
			Assert.IsTrue(d.IsInRange(y, t));
		}

		[Test]
		public void IsInRangeFalse()
		{
			var d = new DateTime(2015, 03, 12, 11, 15, 1);
			var t = new DateTime(2015, 03, 13, 12, 0, 0);
			var y = new DateTime(2015, 02, 12, 18, 1, 19);

			Assert.IsTrue(d.IsInRange(null, null));
			Assert.IsTrue(d.IsInRange(null, y));
			Assert.IsTrue(d.IsInRange(t, null));
			Assert.IsTrue(d.IsInRange(t, y));
		}
	}
}