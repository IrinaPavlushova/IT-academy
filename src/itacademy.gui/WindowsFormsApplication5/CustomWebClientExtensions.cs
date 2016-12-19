using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
	public static class CustomWebClientExtensions
	{
		public static async Task DownloadFileAsync(this CustomWebClient webClient, string uri, string filename, IProgress<ProgressReport> progress, CancellationToken token)
		{
			if(webClient == null) throw new ArgumentNullException(nameof(webClient));
			if(filename == null) throw new ArgumentNullException(nameof(filename));

			using(var fileStream = new FileStream(filename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			{
				await webClient
					.DownloadDataAsync(uri, fileStream, progress, token)
					.ConfigureAwait(continueOnCapturedContext: false);
			}
		}
	}
}
