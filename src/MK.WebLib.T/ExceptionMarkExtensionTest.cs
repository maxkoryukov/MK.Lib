using System;
using NUnit.Framework;

namespace MK
{
	[TestFixture]
	public class ExceptionMarkExtensionTest
	{
		private int ThrowSystem1()
		{
			int x = 12;

			long y = 11;

			return x / (x * x - 23 - (int)y * (int)y);
		}

		private void ThrowOwn(string message)
		{
			throw new ArgumentException(message, "message").SetMark();
		}


		[Test]
		public void IsMarked()
		{
			var e = Assert.Throws<ArgumentException>(() => { this.ThrowOwn("asdf"); });
			Assert.IsTrue(e.GetMark());
		}
		[Test]
		public void IsNotMarked()
		{
			var e = Assert.Throws<DivideByZeroException>(() => { this.ThrowSystem1(); });
			Assert.IsFalse(e.GetMark());
		}
	}
}