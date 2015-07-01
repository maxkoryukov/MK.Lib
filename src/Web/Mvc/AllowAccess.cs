using System;
using System.Web.Mvc;

namespace MK.WebLib.Web.Mvc
{
	/// <summary>
	/// Этот атрибут ограничивает доступ. Но должен вместо запроса авторизации отображать страницу с сообщением об ограничении доступа
	/// </summary>
	/// <remarks>
	/// Реализовать требуемое поведение
	/// </remarks>
	public class AllowAccessAttribute : AuthorizeAttribute
	{
	}
}