using System.IO;
using Celeste.Everest.Content.Sources;

namespace Celeste.Everest.Content.Assets
{
    public class MapBinsInModsContentAsset : EverestContentAsset<MapBinsInModsContentSource>
    {
        /// <summary>
        ///     The path to the source file.
        /// </summary>
        public readonly string Path;

        public MapBinsInModsContentAsset(MapBinsInModsContentSource source, string path)
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
