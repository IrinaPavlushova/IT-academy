using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class LogRepository
	{
		public event EventHandler<LogRecordAddedArgs> LogRecordAdded;

		private void OnLogRecordAdded(LogRecordAddedArgs e)
		{
			LogRecordAdded?.Invoke(this, e);
		}

		private readonly List<LogRecord> _logList;
		private readonly Random _random;

		public LogRepository()
		{
			_logList = new List<LogRecord>();
			_random	 = new Random();
		}

		public void AddRecord(LogRecordData data)
		{
			var newRecord = new LogRecord(Guid.NewGuid(), data.Text);
			_logList.Add(newRecord);
			OnLogRecordAdded(new LogRecordAddedArgs(newRecord));
		}
	}
}
