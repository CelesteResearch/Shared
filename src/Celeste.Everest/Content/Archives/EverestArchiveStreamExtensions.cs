using System.IO;
using System.IO.Compression;

namespace Celeste.Everest.Content.Archives
{
    public static class EverestArchiveStreamExtensions
    {
        public static MemoryStream ExtractStream(this ZipArchiveEntry entry)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (Stream stream = entry.Open())
            {
                stream.CopyTo(memoryStream);
            }

            memoryStream.Seek(0L, SeekOrigin.Begin);
            return memoryStream;
        }
    }
}
