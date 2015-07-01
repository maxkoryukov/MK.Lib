using System;
using System.Collections.Generic;
using BLToolkit.Mapping;
using BLToolkit.Data;

namespace MK.WebLib.Data
{
	public class Db
		: BLToolkit.Data.DbManager
	{
		private bool _IsQueryLogged = false;
		public bool IsQueryLogged
		{
			get { return this._IsQueryLogged; }
			set { this._IsQueryLogged = value; }
		}
			
		protected override void OnBeforeOperation(OperationType op)
		{
			var x = op;

			if (this.IsQueryLogged)
			{
				// append user id:
				//int? user_id = User.CurrentUser();
			}

			base.OnBeforeOperation(op);
		}
	}
}