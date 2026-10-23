using System;
using System.IO;

namespace Celeste.Everest.Modules.Persistence
{
    public sealed class EverestModuleFileStorage : IEverestModuleDataStorage
    {
        public string DirectoryPath { get; }
        public Action<string, Exception> Error;

        public EverestModuleFileStorage(string directory)
        {
            DirectoryPath = Path.GetFullPath(directory);
        }

        public byte[] Read(string fileName)
        {
            var path = Path.Combine(DirectoryPath, fileName + ".celeste");
            if (!File.Exists(path)) return null;
            try
            {
                return File.ReadAllBytes(path);
            }
            catch (Exception error)
            {
                Error?.Invoke(path, error);
                return null;
            }
        }

        public void Write(string fileName, byte[] data, bool flushToDisk)
        {
            var path = Path.Combine(DirectoryPath, fileName + ".celeste");
            // The original deletes even for null data and before trying the write.
            if (File.Exists(path)) File.Delete(path);
            if (data == null) return;
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            try
            {
                using (var stream = File.OpenWrite(path))
                {
                    stream.Write(data, 0, data.Length);
                    if (flushToDisk) stream.Flush(true);
                }
            }
            catch (Exception error)
            {
                Error?.Invoke(path, error);
            }
        }
    }
}
