using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
	public struct ProgressReport
	{
		public ProgressReport(long total, long downloaded)
		{
			Total = total;
			Downloaded = downloaded;
		}

		public long Total { get; }

		public long Downloaded { get; }
	}
}
