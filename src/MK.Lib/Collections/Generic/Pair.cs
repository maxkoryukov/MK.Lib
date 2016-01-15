using System;

namespace MK.Collections.Generic
{
	public interface IPair<M, N>
	{
		M A { get; set; }
		N B { get; set; }
	}

	public interface IPair<M>
		: IPair<M, M>
	{
	}

	public class Pair<M, N>
		: IPair<M, N>
	{
		public M A { get; set; }
		public N B { get; set; }
	}

	public class Pair<M>
		:Pair<M, M>
		,IPair<M, M>
		,IPair<M>	
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
