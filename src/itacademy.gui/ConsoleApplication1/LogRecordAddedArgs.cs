using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class LogRecordAddedArgs : EventArgs
	{
		public LogRecordAddedArgs(LogRecord newLogRecord)
		{
			NewLogRecord = newLogRecord;
		}

		public LogRecord NewLogRecord { get; }
	}
}
