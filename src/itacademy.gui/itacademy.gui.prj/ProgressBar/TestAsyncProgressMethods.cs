using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itacademy.gui
{
	public static class TestAsyncProgressMethods

	{
		public static async Task TestProgress(IProgress<ProgressArgs> progress)
		{
			var x = 200;

			for(var i = 1; i <= 100; i++)
			{
				var a = x * i / 100;

				await Task.Delay(1000);

				progress.Report(new ProgressArgs() { Text = $@"Text: {a} / {i}", Percent = i });
			}
		}
	}
}
