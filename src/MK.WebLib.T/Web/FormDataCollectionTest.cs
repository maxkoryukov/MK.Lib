using System;
using System.Text;
using NUnit.Framework;

namespace MK.Web
{
	[TestFixture]
	public class FormDataCollectionTest
	{
		[Test]
		public void EmptyTest()
		{
			var y = new FormDataCollection();
			Assert.IsEmpty(y.ToString());
		}

		[Test]
		public void EnglishOneDataTest()
		{
			var key1 = "form.name[value.1]";
			var val1 = "Igor Nikolaev 12 & Natasha X";

			var y = new FormDataCollection();
			y.Add(key1, val1);

			Assert.AreEqual("form.name%5Bvalue.1%5D=Igor+Nikolaev+12+%26+Natasha+X", y.ToString());
		}

		[Test]
		public void EnglishManyDataTest()
		{
			var y = new FormDataCollection();

			y.Add("form.name[value.1]", "Igor Nikolaev 12 & Natasha X");
			y.Add("simple-string-x127", "12/3*x\\67ye.?!@#$%^&*()");

			Assert.AreEqual("form.name%5Bvalue.1%5D=Igor+Nikolaev+12+%26+Natasha+X&simple-string-x127=12%2F3*x%5C67ye.%3F!%40%23%24%25%5E%26*()", y.ToString());
		}
	
		[Test]
		public void EnglishSmallCapsTest()
		{
			var y = new FormDataCollection();

			y.Add("form.name[value.1]", "Igor Nikolaev 12 & Natasha X");
			y.Add("alphavit", "abcdefghijklmnopqrstuvwxuz");

			Assert.AreEqual("form.name%5Bvalue.1%5D=Igor+Nikolaev+12+%26+Natasha+X&alphavit=abcdefghijklmnopqrstuvwxuz", y.ToString());

			y = new FormDataCollection();

			y.Add("form.name[value.1]", "Igor Nikolaev 12 & Natasha X");
			y.Add("alphavit", "ABCDEFGHIJKLMNOPQRSTUVWXUZ");

			Assert.AreEqual("form.name%5Bvalue.1%5D=Igor+Nikolaev+12+%26+Natasha+X&alphavit=ABCDEFGHIJKLMNOPQRSTUVWXUZ", y.ToString());
		}

		[Test]
		public void AccentsTest()
		{
			var y = new FormDataCollection();

			y.Add("form.name[value.1]", "test");
			y.Add("alphavit", "MOISÉS 6140-3801");

			Assert.AreEqual("form.name%5Bvalue.1%5D=test&alphavit=MOIS%C3%89S+6140-3801", y.ToString());
		}
	}
}
