using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itacademy.gui.Logging
{
	public static class LogCreator
	{
		/**
		public static ILog GetLogger(Type type) { }
		public static ILog GetLogger(string name) { }

		public static ILoggerFactoryAdapter Adapter;
		/**/
		static LogCreator()
		{
			Log = new Logger();
		}


		public static ILog Log { get; }
	}
}
