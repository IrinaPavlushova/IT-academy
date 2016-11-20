using System;

namespace itacademy.gui.Logging
{
	public interface ILog
	{
		#region Methods
		void Info(string message);
		void Info(string message, Exception exception);

		void Error(string message);
		void Error(string message, Exception exception);

		void Warning(string message);
		void Warning(string message, Exception exception);
	
		void Fatal(string message);
		void Fatal(string message, Exception exception);
		#endregion


		//#region Properties
		//bool IsDebugEnabled { get; }
		//bool IsErrorEnabled { get; }
		//bool IsFatalEnabled { get; }
		//bool IsInfoEnabled { get; }
		//bool IsTraceEnabled { get; }
		//bool IsWarnEnabled { get; }
		//#endregion

	}
}
