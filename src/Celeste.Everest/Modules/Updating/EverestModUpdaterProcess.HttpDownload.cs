using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Celeste.Everest.Modules.Updating
{
    public partial class EverestModUpdaterProcess
    {
        public void DownloadFileWithProgress(string url, string destPath, Func<int, long, int, bool> progressCallback)
        {
            DateTime now = DateTime.Now;
            if (File.Exists(destPath))
            {
                File.Delete(destPath);
            }

            using HttpClient httpClient = ((IEverestCompressedHttpEnvironment)engine).CompressedHttp.CreateClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(10000.0);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/octet-stream");
            Task<HttpResponseMessage> async = httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            HttpResponseMessage result;
            try
            {
                result = async.Result;
            }
            catch (AggregateException ex)
            {
                if (async.IsCanceled)
                {
                    throw new TimeoutException("The request to " + url + " timed out.", ex.InnerException);
                }

                throw;
            }

            using (result)
            {
                using Stream stream = result.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
                using FileStream fileStream = File.OpenWrite(destPath);
                if (stream.CanTimeout)
                {
                    stream.ReadTimeout = 10000;
                }

                long num =
                    ((!stream.CanSeek) ? result.Content.Headers.ContentLength.GetValueOrDefault() : stream.Length);
                progressCallback(0, num, 0);
                byte[] array = new byte[4096];
                DateTime dateTime = now;
                int num2 = 1;
                int num3 = 0;
                int num4 = 0;
                int arg = 0;
                int num5 = 0;
                while (num2 > 0)
                {
                    num5 = (int)((num > 0) ? Math.Min(array.Length, num - num4) : array.Length);
                    num2 = stream.Read(array, 0, num5);
                    fileStream.Write(array, 0, num2);
                    num4 += num2;
                    num3 += num2;
                    TimeSpan timeSpan = DateTime.Now - dateTime;
                    if (timeSpan.TotalMilliseconds > 100.0)
                    {
                        arg = (int)((double)num3 / 1024.0 / timeSpan.TotalSeconds);
                        num3 = 0;
                        dateTime = DateTime.Now;
                    }

                    if (!progressCallback(num4, num, arg))
                    {
                        break;
                    }
                }
            }
        }
    }
}
