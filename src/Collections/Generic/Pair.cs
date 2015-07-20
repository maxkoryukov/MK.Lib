using System;

namespace MK.Collections.Generic
{
	public class Pair<M, N>
	{
		public M A { get; set; }
		public N B { get; set; }
	}

	public class Pair<M>
		:Pair<M, M>
	{
		public void Swap()
		{
			M t;
			t = this.A;
			this.A = this.B;
			this.B = t;
		}
	}
}
