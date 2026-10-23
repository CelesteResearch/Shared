using System.IO;

namespace Celeste.Everest.Content.Registry
{
    public sealed class SourceEverestFileProxyProcess
    {
        private readonly EverestContentRegistry content;
        private readonly string Dummy;

        public SourceEverestFileProxyProcess(EverestContentRegistry content, string actualPathTmp)
        {
            this.content = content;
            Dummy = Path.Combine(actualPathTmp, "FileProxyStreamDummy.txt");
        }

        public bool Exists(string path)
        {
            if (File.Exists(path))
                return true;
            path = EverestFileProxyPath.Modize(path, content);
            return content.Get(path) != null;
        }

        public FileStream OpenRead(string path)
        {
            if (content.TryGet(EverestFileProxyPath.Modize(path, content), out var metadata))
                return new SourceEverestFileProxyStream(Dummy, metadata.Stream);
            return File.OpenRead(path);
        }

        public void DeleteDummy()
        {
            try
            {
                if (File.Exists(Dummy))
                    File.Delete(Dummy);
            }
            catch
            {
            }
        }

        public byte[] ReadAllBytes(string path)
        {
            return content.TryGet(EverestFileProxyPath.Modize(path, content), out var metadata)
                ? metadata.Data
                : File.ReadAllBytes(path);
        }
    }
}
