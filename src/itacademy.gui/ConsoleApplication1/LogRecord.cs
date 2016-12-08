using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class LogRecord
	{
		public LogRecord(Guid id, string text)
		{
			Id = id;
			Text = text;
		}

		public string Text { get; }
		public Guid Id { get; }
	}
}
