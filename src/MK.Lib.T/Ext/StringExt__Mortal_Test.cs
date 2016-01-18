using System;
using NUnit.Framework;

namespace MK.Ext
{
	[TestFixture]
	public class StringExt__Mortal_Test
	{
		private string _mortal_dot(string s)
		{
			return s.TrimMortal();
		}
		private string _mortal_ext(string s)
		{
			return StringExt.TrimMortal(s);
		}
		private string _mortal(string s)
		{
			var a = this._mortal_dot(s);
			var b = this._mortal_ext(s);

			Assert.AreEqual(a, b);
			return a;
		}

		[Test]
		public void TrimMortalNull()
		{
			string s = null;
			Assert.DoesNotThrow(() => { s.TrimMortal(); });

			Assert.Null( this._mortal(null) );
		}

		[Test]
		public void TrimMortalEmpty()
		{
			Assert.Null(this._mortal(""));
		}
		[Test]
		public void TrimMortalBlanks()
		{
			Assert.Null(this._mortal("                       "));
		}
		[Test]
		public void TrimMortalTabs()
		{
			Assert.Null(this._mortal("			"));
		}
		[Test]
		public void TrimMortal13()
		{
			Assert.Null(this._mortal(((char)(13)).ToString() + ((char)(13)).ToString()));
		}
		public void TrimMortal10()
		{
			Assert.Null(this._mortal(((char)(10)).ToString() + ((char)(10)).ToString()));
		}

		public void TrimMortalText()
		{
			Assert.AreEqual("asdf", this._mortal("asdf"));
		}
		public void TrimMortalZero()
		{
			Assert.AreEqual("0", this._mortal("0"));
		}
		public void TrimMortalWithSpacesNonEmpty()
		{
			Assert.AreEqual("0 0", this._mortal(" 0 0"));
			Assert.AreEqual("0 1", this._mortal("0 1			"));
			Assert.AreEqual(@"			brown
fox					", this._mortal(@"brown
fox"));
		}
	}
}
