using Celeste.Everest.Content.Sources;
using System.IO;

namespace Celeste.Everest.Content.Assets
{
    public class ZipContentAsset : EverestContentAsset<ZipContentSource>
    {
        public readonly string Path;

        public override byte[] Data
        {
            get
            {
                using Stream stream = base.Source.Open(Path);
                using MemoryStream memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public ZipContentAsset(ZipContentSource source, string path)
            : base(source)
        {
            Path = path;
        }

        protected override void Open(out Stream stream, out bool isSection)
        {
            stream = base.Source.Open(Path);
            isSection = false;
        }
    }
}
