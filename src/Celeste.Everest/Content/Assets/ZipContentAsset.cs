using System.IO;
using Celeste.Everest.Content.Sources;

namespace Celeste.Everest.Content.Assets
{
    public class ZipContentAsset : EverestContentAsset<ZipContentSource>
    {
        public readonly string Path;

        public override byte[] Data
        {
            get
            {
                using var stream = Source.Open(Path);
                using var memoryStream = new MemoryStream();
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
            stream = Source.Open(Path);
            isSection = false;
        }
    }
}
