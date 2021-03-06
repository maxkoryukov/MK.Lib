﻿using System;

namespace MK.Ext
{
	public static class DateTimeExt
	{
		public static bool IsInRange(this DateTime t, DateTime? tfrom, DateTime? ttrim)
		{
			if (!tfrom.HasValue || t >= tfrom.Value)
			if (!ttrim.HasValue || t < ttrim.Value)
				return true;
			return false;
		}
	}
}