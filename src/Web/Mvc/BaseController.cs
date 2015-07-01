using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MK.WebLib.Web.Mvc
{
	public abstract class BaseController : Controller
	{
		protected override void Initialize(RequestContext context)
		{
			base.Initialize(context);

			/// Переопределить культуру!!
			

			//string [] langs = context.HttpContext.Request.UserLanguages;
			//if (null != langs
			//	&& langs.Length > 0)
			//{
			//	string cult = langs[0];

			//	var culture = System.Threading.Thread.CurrentThread.CurrentCulture;

			//	try
			//	{
					
			//	}
			//	catch
			//	{
			//		// nothing, не удалось сменить культуру
			//	}

			//}


		}

		public dynamic DebugFlags { get; set; }

		protected override JsonResult Json(object data, string contentType, 
		                                   System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
		{
			return new Newtonsoft.JsonResult.JsonResult
			{
				Data = data,
				ContentType = contentType,
				ContentEncoding = contentEncoding,
				JsonRequestBehavior = behavior
			};
		}
	}
}
