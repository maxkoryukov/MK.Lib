using System;
using MK.Ext;

namespace MK.T
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var x = new MK.Net.HttpWebRequestWrapperCrossStringTest();
			x.SetUp();
			x.TestCrossRandomString("Accept");
		}
	}
}