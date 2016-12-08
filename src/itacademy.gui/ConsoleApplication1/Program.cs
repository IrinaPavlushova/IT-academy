using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			//var func = Calculate2(Calculate);
			//var list = new List<int>();
			//list.Where(x => Where(x));
			//Console.WriteLine(func(5, 7));


			//var myDelegate = new MyDelegate((a, b) => { });

			//var device = new Device();
			//device.ConnectionChanged += OnDeviceConnectionChanged;

			//device.Connect();
			//device.Disconnect();

			//Console.ReadKey();

			//device.ConnectionChanged -= OnDeviceConnectionChanged;

			var logRepository = new LogRepository();
			logRepository.LogRecordAdded += OnLogRecordAdded;

			logRepository.AddRecord(new LogRecordData("Text1"));
			logRepository.AddRecord(new LogRecordData("Text2"));
			logRepository.AddRecord(new LogRecordData("Text3"));
			logRepository.AddRecord(new LogRecordData("Text4"));
			logRepository.AddRecord(new LogRecordData("Text5"));
	
			Console.ReadKey();
			logRepository.LogRecordAdded -= OnLogRecordAdded;
		}

		private static void OnLogRecordAdded(object sender, LogRecordAddedArgs e)
		{
			Console.WriteLine($@"Id: {e.NewLogRecord.Id}, Text: {e.NewLogRecord.Text}");
		}

		private static void OnDeviceConnectionChanged(object sender, EventArgs e)
		{
			Console.WriteLine("Device connection changed");
		}

		private static bool Where(int x)
		{
			return x == 10;
		}

		private static int Calculate(int a, int b)
		{
			return a + b;
		}

		private static Func<int, int, int> Calculate2(Func<int, int, int> calculate)
		{
			return calculate;
		}
	}
}
