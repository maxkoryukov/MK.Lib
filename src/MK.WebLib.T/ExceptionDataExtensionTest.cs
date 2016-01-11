using System;
using NUnit.Framework;

namespace MK
{
	[TestFixture]
	public class ExceptionDataExtensionTest
	{
		#region Throws

		private int ThrowSystem1()
		{
			int x = 12;

			long y = 11;

			return x / (x * x - 23 - (int)y * (int)y);
		}

		private void ThrowOwn(string message)
		{
			throw new InvalidTimeZoneException(message).SetMark();
		}
		#endregion



		[Test]
		public void IsMarked()
		{
			var e = Assert.Throws<InvalidTimeZoneException>(() => { this.ThrowOwn("asdf"); });
			Assert.IsTrue(e.GetMark());

			e.SetMark().SetMark().SetMark();
			Assert.IsTrue(e.GetMark());
		}

		[Test]
		public void SetMarkReturnsSelf()
		{
			var e = Assert.Throws<InvalidTimeZoneException>(() => { this.ThrowOwn("asdf"); });
			Assert.AreSame(e,  e.SetMark().SetMark().SetMark());
		}
		[Test]
		public void SetDataReturnsSelf()
		{
			var e = Assert.Throws<DivideByZeroException>(() => { this.ThrowSystem1(); });
			Assert.AreSame(e, e.SetData("a", 1).SetData("name", @"C:\users\name"));
		}

		[Test]
		public void IsMarkedManyTimes()
		{
			var e = Assert.Throws<InvalidTimeZoneException>(() => { this.ThrowOwn("asdf"); });
			e.SetMark().SetMark().SetMark();
			Assert.IsTrue(e.GetMark());
		}

		[Test]
		public void IsNotMarkedSystem()
		{
			var e = Assert.Throws<DivideByZeroException>(() => { this.ThrowSystem1(); });
			Assert.IsFalse(e.GetMark());
		}

		[Test]
		public void IsNotMarkedCustomMarked()
		{
			var e = Assert.Throws<DivideByZeroException>(() => { this.ThrowSystem1(); });
			ExceptionDataExtension.SetData(e, ExceptionDataExtension.Mark, 12);
			Assert.IsFalse(e.GetMark());
		}

		[Test]
		public void HasDataOnNullKey()
		{
			Exception e = Assert.Throws<InvalidTimeZoneException>(() => { this.ThrowOwn("asdf"); });
			Assert.Throws<ArgumentNullException>(() => { e.HasData(null); } );
		}
		[Test]
		public void HasDataTrue()
		{
			Exception e = Assert.Throws<InvalidTimeZoneException>(() => { this.ThrowOwn("asdf"); });
			Assert.IsTrue(e.HasData(ExceptionDataExtension.Mark));

			e = Assert.Throws<DivideByZeroException>(() => { this.ThrowSystem1(); });
			e.SetData("asdf", 12);
			Assert.IsTrue(e.HasData("asdf"));
		}

		[Test]
		public void SetDataNullThrows()
		{
			Exception e = null;
			Assert.Throws<NullReferenceException>(() => { ExceptionDataExtension.SetData(e, "123", 100); });
		}
		[Test]
		public void SetMarkNullThrows()
		{
			Exception e = null;
			Assert.Throws<NullReferenceException>(() => { e.SetMark(); });
		}

		[Test]
		public void DataSetGet()
		{
			Exception e = Assert.Throws<DivideByZeroException>(() => { this.ThrowSystem1(); });
			e.SetData("asdf", 12);
			Assert.IsTrue(e.HasData("asdf"));
			Assert.AreEqual(12, e.GetData("asdf"));

			const string k1 = "babanananaananananaanan";
			var v1 = new DateTime( (long)(new System.Random()).Next() );
			Assert.IsFalse(e.HasData(k1));
			e.SetData(k1, v1);
			Assert.IsTrue(e.HasData(k1));
			Assert.AreEqual(v1, e.GetData(k1));
		}
	}
}