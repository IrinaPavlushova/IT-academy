using System;
using System.IO;

namespace itacademy.gui.Logging
{
	public class LogCreator : ILog
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

		public LogCreator()
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
		public static void LogFileBuilder()
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
				sw.WriteLine("{0} [INFO] {1}[description] : {2}" + Environment.NewLine + "[source] : {3}", DateTime.Now, message, exception.Message, exception.Source);
			}
		}

		public void Error(string message)
		{
			LogFileBuilder();
			DateTime now = DateTime.Now;
			using(StreamWriter sw = File.AppendText(_path))
			{
				sw.WriteLine("{0} [ERR] {1}", DateTime.Now, message);
			}
		}

		public void Error(string message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void Warning(string message)
		{
			throw new NotImplementedException();
		}

		public void Warning(string message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void Fatal(string message)
		{
			throw new NotImplementedException();
		}

		public void Fatal(string message, Exception exception)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
