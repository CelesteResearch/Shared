using System.IO;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Formats.Graphics.Atlas;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public void DumpAll()
        {
            var environment = processing.AtlasLoader;
            var logger = processing.Logger;
            bool dumpOnLoad = DumpOnLoad;
            DumpOnLoad = true;
            foreach (string item in Directory.EnumerateFiles(Path.Combine(PathContentOrig, "Graphics", "Atlases"),
                         "*.meta", SearchOption.AllDirectories))
            {
                logger.Log(EverestLogLevel.Verbose, "dump-all-atlas-meta", "file: " + item);
                try
                {
                    SourceAtlasLoader.FromAtlas(item.Substring(0, item.Length - 5), AtlasDataFormat.Packer,
                        environment).Dispose();
                }
                catch
                {
                    SourceAtlasLoader.FromAtlas(item.Substring(0, item.Length - 5), AtlasDataFormat.PackerNoAtlas,
                        environment).Dispose();
                }
            }

            DumpOnLoad = dumpOnLoad;
        }
    }
}
