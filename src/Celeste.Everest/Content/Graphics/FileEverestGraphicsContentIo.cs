using System.IO;
using Celeste.Core.IO.Content;
using Celeste.Everest.Content.Registry;

namespace Celeste.Everest.Content.Graphics
{
    public sealed class FileEverestGraphicsContentIo : IEverestGraphicsContentIo
    {
        private readonly EverestContentRegistry content;

        public FileEverestGraphicsContentIo(EverestContentRegistry content)
        {
            this.content = content;
        }

        public bool OriginalXmlExists(string path)
        {
            return File.Exists(ContentFilePath.Resolve(content.PathContentOrig, path));
        }

        public Stream OpenOriginalXml(string path)
        {
            return File.OpenRead(ContentFilePath.Resolve(content.PathContentOrig, path));
        }
    }
}
