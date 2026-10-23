using System;
using System.IO;
using System.IO.Compression;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    internal static class SourceAssemblyStorageExtensions
    {
        public static MemoryStream ExtractStream(this ZipArchiveEntry entry)
        {
            var memoryStream = new MemoryStream();
            using (var stream = entry.Open())
            {
                stream.CopyTo(memoryStream);
            }

            memoryStream.Seek(0L, SeekOrigin.Begin);
            return memoryStream;
        }

        public static string ToHexadecimalString(this byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }
    }
}
