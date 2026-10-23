using Celeste.Everest.Content.Sources;
using System.IO;

namespace Celeste.Everest.Content.Assets
{
    public class FileSystemContentAsset : EverestContentAsset<FileSystemContentSource>
    {
        public readonly string Path;

        public FileSystemContentAsset(FileSystemContentSource source, string path)
            : base(source)
        {
            Path = path;
        }

        protected override void Open(out Stream stream, out bool isSection)
        {
            if (!File.Exists(Path))
            {
                stream = null;
                isSection = false;
            }
            else
            {
                stream = File.OpenRead(Path);
                isSection = false;
            }
        }

        public override string GetCachedPath()
        {
            return Path;
        }
    }
}
