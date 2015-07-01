using System;
using System.Configuration;
using System.Web.Mvc;

namespace MK.WebLib.Web.Mvc
{
	/// <summary>
	/// Генерация URL для статического контента для View, для Razor разметки
	/// </summary>
	public static class StaticContentHelper
	{
		public static string Url(string server_path)
		{
			string str = ConfigurationManager.AppSettings["static.content"];
			//return string.Format("/Content/ext{0}", server_path);
			return string.Format(str, server_path);
		}
	}
}