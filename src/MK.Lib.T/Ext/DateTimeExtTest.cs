using System;
using NUnit.Framework;

namespace MK.Ext
{
	[TestFixture]
	public class DateTimeExtTest
	{
		DateTime d = new DateTime(2015, 03, 12, 11, 15, 1);
		DateTime t = new DateTime(2015, 03, 13, 12, 0, 0);
		DateTime y = new DateTime(2015, 02, 12, 18, 1, 19);

		[Test]
		public void IsInRangeTrue()
		{
			Assert.IsTrue(d.IsInRange(null, null));
			Assert.IsTrue(d.IsInRange(null, t));
			Assert.IsTrue(d.IsInRange(y, null));
			Assert.IsTrue(d.IsInRange(y, t));
		}

		[Test]
		public void IsInRangeFalseNullYesterday()
		{
			Assert.IsFalse(d.IsInRange(null, y));
		}
		[Test]
		public void IsInRangeFalseTomorrowNull()
		{
			Assert.IsFalse(d.IsInRange(t, null));
		}
		[Test]
		public void IsInRangeFalseYesterdayTomorrow()
		{
			Assert.IsFalse(d.IsInRange(t, y));
		}
	}
}