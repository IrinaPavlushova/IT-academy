using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
	public class CustomWebClient
	{
		public async Task DownloadDataAsync(string uri, Stream stream, IProgress<ProgressReport> progress, CancellationToken token)
		{
			if(uri == null) throw new ArgumentNullException(nameof(uri));
			if(stream == null) throw new ArgumentNullException(nameof(stream));

			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			var request = WebRequest.Create(uri);
			var response = await request
				.GetResponseAsync()
				.ConfigureAwait(continueOnCapturedContext: false);
			token.ThrowIfCancellationRequested();
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			var totalLength = response.ContentLength;
			progress?.Report(new ProgressReport(totalLength, 0));
			using(var responseStream = response.GetResponseStream())
			{
				var buffer = new byte[1024 * 4];
				var downloaded = 0;
				while(true)
				{
					token.ThrowIfCancellationRequested();
					var readBytes = await responseStream
						.ReadAsync(buffer, 0, buffer.Length, token)
						.ConfigureAwait(continueOnCapturedContext: false);
					downloaded += readBytes;
					progress?.Report(new ProgressReport(totalLength, downloaded));
					Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
					if(readBytes == 0)
					{
						break;
					}
					await stream
						.WriteAsync(buffer, 0, readBytes, token)
						.ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}
	}
}
