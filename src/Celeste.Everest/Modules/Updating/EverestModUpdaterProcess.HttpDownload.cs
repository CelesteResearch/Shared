using System;
using System.IO;
using System.Net.Http;

namespace Celeste.Everest.Modules.Updating
{
    public partial class EverestModUpdaterProcess
    {
        public void DownloadFileWithProgress(string url, string destPath, Func<int, long, int, bool> progressCallback)
        {
            var now = DateTime.Now;
            if (File.Exists(destPath)) File.Delete(destPath);

            using var httpClient = ((IEverestCompressedHttpEnvironment)engine).CompressedHttp.CreateClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(10000.0);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/octet-stream");
            var async = httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            HttpResponseMessage result;
            try
            {
                result = async.Result;
            }
            catch (AggregateException ex)
            {
                if (async.IsCanceled)
                    throw new TimeoutException("The request to " + url + " timed out.", ex.InnerException);

                throw;
            }

            using (result)
            {
                using var stream = result.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
                using var fileStream = File.OpenWrite(destPath);
                if (stream.CanTimeout) stream.ReadTimeout = 10000;

                var num =
                    !stream.CanSeek ? result.Content.Headers.ContentLength.GetValueOrDefault() : stream.Length;
                progressCallback(0, num, 0);
                var array = new byte[4096];
                var dateTime = now;
                var num2 = 1;
                var num3 = 0;
                var num4 = 0;
                var arg = 0;
                var num5 = 0;
                while (num2 > 0)
                {
                    num5 = (int)(num > 0 ? Math.Min(array.Length, num - num4) : array.Length);
                    num2 = stream.Read(array, 0, num5);
                    fileStream.Write(array, 0, num2);
                    num4 += num2;
                    num3 += num2;
                    var timeSpan = DateTime.Now - dateTime;
                    if (timeSpan.TotalMilliseconds > 100.0)
                    {
                        arg = (int)(num3 / 1024.0 / timeSpan.TotalSeconds);
                        num3 = 0;
                        dateTime = DateTime.Now;
                    }

                    if (!progressCallback(num4, num, arg)) break;
                }
            }
        }
    }
}
