using System;
using NUnit.Framework;

namespace MK.Collections.Generic
{
	[TestFixture]
	public class PairTest
	{
		[Test]
		public void SwapAndBackIntTest()
		{
			var x = new Pair<int>();
			x.A = 0;
			x.B = 1;

			x.Swap();

			Assert.AreEqual(x.A, 1);
			Assert.AreEqual(x.B, 0);

			x.Swap();
			Assert.AreEqual(x.A, 0);
			Assert.AreEqual(x.B, 1);
		}
		[Test]
		public void SwapAndBackStringTest()
		{
			var x = new Pair<string>();
			x.A = "asdf";
			x.B = null;

			x.Swap();

			Assert.AreEqual(x.A, null);
			Assert.AreEqual(x.B, "asdf");

			x.Swap();
			Assert.AreEqual(x.A, "asdf");
			Assert.AreEqual(x.B, null);
		}
	}
}
