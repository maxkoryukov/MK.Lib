using System;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace MK.WebLib.Web.Mvc
{
	public class FromJsonAttribute : CustomModelBinderAttribute
	{
		private static readonly Newtonsoft.Json.JsonSerializer ser = new Newtonsoft.Json.JsonSerializer();

		public override IModelBinder GetBinder()
		{
			return new JsonModelBinder();
		}

		private class JsonModelBinder: IModelBinder
		{
			#region IModelBinder implementation
			public object BindModel(ControllerContext controller_context, ModelBindingContext binding_context)
			{

				var str = controller_context.HttpContext.Request[binding_context.ModelName];
				if (string.IsNullOrWhiteSpace(str))
					return null;
				using (var x = new StringReader(str))
				using (var j = new JsonTextReader(x))
				{
					var result = ser.Deserialize(j, binding_context.ModelType);
					return result;
				}
			}
			#endregion
		}
	}
}