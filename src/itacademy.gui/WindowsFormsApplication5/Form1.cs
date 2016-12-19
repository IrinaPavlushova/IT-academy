using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication5
{
	public partial class Form1 : Form
	{
		private readonly CustomWebClient _webClient;

		public Form1()
		{
			_webClient = new CustomWebClient();

			InitializeComponent();

			_lblFilename.Text = string.Empty;
		}

		private static Task<long> CalcAsync()
		{
			return Task.Run(() =>
			{
				long result = 0;
				for(int i = 0; i < 1000; ++i)
				{
					result += i * i;
				}
				return result;
			});
		}

		private static async Task<string> DownloadStringAsync(string uri, CancellationToken token)
		{
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			var request = WebRequest.Create(uri);
			var response = await request
				.GetResponseAsync()
				.ConfigureAwait(continueOnCapturedContext: false);
			token.ThrowIfCancellationRequested();
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			var builder = new StringBuilder();
			using(var stream = response.GetResponseStream())
			{
				var buffer = new byte[1024 * 10];
				while(true)
				{
					token.ThrowIfCancellationRequested();
					var readBytes = await stream
						.ReadAsync(buffer, 0, buffer.Length, token)
						.ConfigureAwait(continueOnCapturedContext: false);
					Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
					if(readBytes == 0)
					{
						break;
					}
					builder.Append(Encoding.UTF8.GetString(buffer, 0, readBytes));
				}
			}
			return builder.ToString();
		}

		private static byte[] Join(IReadOnlyList<byte[]> arrays)
		{
			var length = arrays.Sum(a => a.Length);
			var result = new byte[length];
			var offset = 0;
			foreach(var array in arrays)
			{
				Array.Copy(array, 0, result, offset, array.Length);
				offset += array.Length;
			}
			return result;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			using(var src = new CancellationTokenSource())
			{
				string str;
				src.Cancel();
				try
				{
					str = await DownloadStringAsync(@"https://yandex.ru/", src.Token);
				}
				catch(OperationCanceledException)
				{
					MessageBox.Show("Canceled");
					return;
				}
				button1.Text = str.Length.ToString();
			}
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			//MessageBox.Show(str.Substring(0, 10) + ", " + str.Length.ToString());
		}

		private CancellationTokenSource _cts;

		private async void button2_Click(object sender, EventArgs e)
		{
			button2.Enabled = false;
			button3.Enabled = true;
			_cts?.Dispose();
			_cts = new CancellationTokenSource();
			var progress = new Progress<ProgressReport>();
			progress.ProgressChanged += (s, args) =>
			{
				progressBar1.Style = ProgressBarStyle.Blocks;
				progressBar1.Maximum = (int)args.Total;
				progressBar1.Value = (int)args.Downloaded;
			};

			//var url = @"https://download.microsoft.com/download/E/A/E/EAE6F7FC-767A-4038-A954-49B8B05D04EB/Express%2032BIT/SQLEXPR_x86_ENU.exe";
			var url2 = @"https://download.mozilla.org/?product=firefox-stub&os=win&lang=ru";
			var filename = DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".exe";
			var path = Path.Combine(@"D:\", filename);
			progressBar1.Visible = true;
			progressBar1.Style = ProgressBarStyle.Marquee;
			try
			{
				await _webClient.DownloadFileAsync(url2, path, progress, _cts.Token);
				_lblFilename.Text = path;

			}
			catch(OperationCanceledException)
			{
				button2.Enabled = true;
				progressBar1.Visible = false;
				return;
			}
			button2.Enabled = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			_cts?.Cancel();
			button3.Enabled = false;
		}

		interface ICalc
		{
			Task<int> Sum(int a, int b);
		}

		class C : ICalc
		{
			public Task<int> Sum(int a, int b) => Task.FromResult(a + b);
		}

		class UserInput : ICalc
		{
			public Task<int> Sum(int a, int b)
			{
				var result = Interaction.InputBox($"{a} + {b} = ?");
				return Task.FromResult(int.Parse(result));
			}
		}

		private static Task<T> FromResult<T>(T result)
		{
			var x = new TaskCompletionSource<T>();
			x.SetResult(result);
			return x.Task;
		}

		private async void button4_Click(object sender, EventArgs e)
		{
			TaskCompletionSource<int> x = new TaskCompletionSource<int>();
			x.TrySetResult(42);
			var task = x.Task;
			await task;


			ICalc calc = new UserInput();
			MessageBox.Show((await calc.Sum(10, 20)).ToString());
		}

		private void OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(_lblFilename.Text);
			}
			catch
			{
			}
		}
	}
}
