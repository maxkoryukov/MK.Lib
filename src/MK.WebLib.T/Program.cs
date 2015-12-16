using System;

namespace MK.T
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var y = System.Web.HttpUtility.ParseQueryString(string.Empty);
			y.Add("form.name[value.1]", "test");
			y.Add("alphavit", "MOISÉS 6140-3801");
			Console.WriteLine(y.ToString());

			var n = System.Net.WebUtility.UrlEncode("MOISÉS 6140-3801");
			var m = y.ToString();
		}
	}
}