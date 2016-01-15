using System;
using System.Text;
using NUnit.Framework;

namespace MK.Ext
{
	[TestFixture]
	/// <summary>
	/// Расширения для даты-времени
	/// </summary>
	public class DateTimeJsonExtTest
	{
		private static readonly DateTime D1970_01_01 = new DateTime(1970, 1, 1);
		[Test]
		public void JsonValue()
		{
			var jszero = new DateTime(1970, 1, 1);
			Assert.AreEqual("( new Date(0))", DateTimeJsonExt.JsonValue(jszero));

			var dt = DateTime.Now;
			var js_tick = (dt.Ticks - jszero.Ticks) / 10000;
			Assert.AreEqual("( new Date("+js_tick.ToString()+"))", DateTimeJsonExt.JsonValue(dt));
		}
	}
}