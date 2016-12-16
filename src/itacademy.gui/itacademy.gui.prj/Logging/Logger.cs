using System;
using System.IO;

namespace itacademy.gui.Logging
{
	public class Logger : ILog
	{
		#region Data
		/// <summary>Путь к файлу лога.</summary>
		private static string _path;
		/// <summary>Путь к папке с логами.</summary>
		private static string _directory;
		/// <summary>Информация о каталоге.</summary> 
		private static DirectoryInfo _directoryInfo;
		/// <summary>Информация о файле.</summary>
		private static FileInfo _fileInfo;

		/// <summary>Размер файла лога в байтах.</summary>
		private const int FILE_SIZE = 102400;
		#endregion

		#region .ctor
		public Logger()
		{
			_directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IT_Academy/Log");
			_path = Path.Combine(_directory, "logs.log");
			_directoryInfo = new DirectoryInfo(_directory);
			_directoryInfo.Create();
			if(!File.Exists(_path))
			{
				File.AppendAllText(_path, "---------Start----------" + Environment.NewLine);
			}
		}
		#endregion

		#region Methods
		public void LogFileBuilder()
		{
			DateTime dateTimeNow = DateTime.Now;
			string newFile = _directory + @"\" + dateTimeNow.ToString("ddMMyyHHmmss") + ".old";
			_fileInfo = new FileInfo(_path);

			if(_fileInfo.Length > FILE_SIZE)
			{
				
				if(File.Exists(newFile))
				{
					File.Delete(newFile);
				}
				else
				{
					File.Move(_path, newFile);
					File.SetCreationTime(newFile, dateTimeNow);
				}
			}
		}

		public void Info(string message)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [INFO] {1}", DateTime.Now, message);
			}
		}

		public void Info(string message, Exception exception)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [INFO] [description] : {1} [source] : {2}", DateTime.Now, message, exception.Message, exception.Source);
			}
		}

		public void Info(Exception exception)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [INFO] [description] : {1} [source] : {2}", DateTime.Now, exception.Message, exception.Source);
			}
		}

		public void Error(string message)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [ERROR] {1}", DateTime.Now, message);
			}
		}

		public void Error(string message, Exception exception)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [ERROR] {1} [description] : {2} [source] : {3}", DateTime.Now, message, exception.Message, exception.Source);
			}
		}

		public void Error(Exception exception)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [ERROR] [description] : {1} [source] : {2}", DateTime.Now, exception.Message, exception.Source);
			}
		}

		public void Warning(string message)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [WARNING] [description] : {1}", DateTime.Now, message);
			}
		}

		public void Warning(string message, Exception exception)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [WARNING] {1} [description] : {2} [source] : {3}", DateTime.Now, message, exception.Message, exception.Source);
			}
		}

		public void Warning(Exception exception)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [WARNING] [description] : {1} [source] : {2}", DateTime.Now, exception.Message, exception.Source);
			}
		}

		public void Fatal(string message)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [FATAL ERROR] [description] : {1}", DateTime.Now, message);
			}
		}

		public void Fatal(string message, Exception exception)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [FATAL ERROR] {1} [description] : {2} [source] : {3}", DateTime.Now, message, exception.Message, exception.Source);
			}
		}

		public void Fatal(Exception exception)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [FATAL ERROR] [description] : {1} [source] : {2}", DateTime.Now, exception.Message, exception.Source);
			}
		}

		#endregion
	}
}
