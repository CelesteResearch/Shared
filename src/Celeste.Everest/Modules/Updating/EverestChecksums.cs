using System.IO;
using System.Security.Cryptography;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Updating
{
    public static class EverestChecksums
    {
        public static byte[] ComputeHash(byte[] buffer)
        {
            using HashAlgorithm hash = XXHash64.Create();
            return hash.ComputeHash(buffer);
        }

        public static byte[] ComputeHash(Stream stream)
        {
            using HashAlgorithm hash = XXHash64.Create();
            return hash.ComputeHash(stream);
        }

        public static byte[] GetChecksum(string path)
        {
            using FileStream stream = File.OpenRead(path);
            return ComputeHash(stream);
        }

        public static byte[] GetChecksum(EverestModuleMetadata metadata)
        {
            if (!string.IsNullOrEmpty(metadata.PathArchive)) return GetChecksum(metadata.PathArchive);
            if (!string.IsNullOrEmpty(metadata.DLL)) return GetChecksum(metadata.DLL);
            return new byte[0];
        }

        public static byte[] GetChecksum(ref Stream stream)
        {
            if (!stream.CanSeek)
            {
                var memory = new MemoryStream();
                stream.CopyTo(memory);
                stream.Dispose();
                stream = memory;
                stream.Seek(0L, SeekOrigin.Begin);
            }

            long position = stream.Position;
            stream.Seek(0L, SeekOrigin.Begin);
            byte[] result = ComputeHash(stream);
            stream.Seek(position, SeekOrigin.Begin);
            return result;
        }
    }
}
