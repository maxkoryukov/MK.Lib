using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MK.WebLib.Web.Mvc
{
	public static class ToSelectListExtension
	{
		public static List<SelectListItem> ToSelectList<T>(
		this IEnumerable<T> enumerable, 
			Func<T, string> text, 
			Func<T, string> value, 
			string defaultOption)
		{
			var items = enumerable.Select(f => new SelectListItem()
			{
				Text = text(f), 
				Value = value(f) 
			}).ToList();
			items.Insert(0, new SelectListItem()
			{
				Text = defaultOption, 
				Value = "" 
			});
			return items;
		}
	}
}