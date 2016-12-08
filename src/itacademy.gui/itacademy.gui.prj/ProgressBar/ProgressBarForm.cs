using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itacademy.gui.ProgressBar
{
	public partial class ProgressBarForm : Form
	{
		public ProgressBarForm()
		{
			InitializeComponent();

			Font = SystemFonts.MessageBoxFont;

			_progressBar.Style = ProgressBarStyle.Continuous;
			MinimumSize = Size;
			MaximumSize = Size;

		}

		private Task ProcessData(List<string> list, IProgress<ProgressReport> progress)
		{
			int index = 1;
			int totalProcess = list.Count;
			var progressReport = new ProgressReport();
			return Task.Run(() =>
			{
				for(int i = 0; i < totalProcess; i++)
				{
					progressReport.PercentComplete = index++ * 100 / totalProcess;
					progress.Report(progressReport);
					Task.Delay(10).Wait();
				}
			});
		}

		private void _btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void ProgressBarForm_Load(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			for(int i = 0; i < 1000; i++)
				list.Add(i.ToString());
			_lblText.Text = "Working...";
			var progress = new Progress<ProgressReport>();
			progress.ProgressChanged += (o, report) =>
			{
				_lblText.Text = string.Format("Processing...{0}%", report.PercentComplete);
				_progressBar.Value = report.PercentComplete;
				_progressBar.Update();
			};
			await ProcessData(list, progress);
			Close();
		}
	}
}
