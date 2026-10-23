using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Modules.Updating;
using System.IO;

namespace Celeste.Everest.Content.Sources
{
    public class MapBinsInModsContentSource : EverestContentSource
    {
        private readonly EverestLoaderProcess Loader;

        /// <summary>
        ///       The path to the mod directory.
        ///       </summary>
        public readonly string Path;

        public override string DefaultName => System.IO.Path.GetFileName(Path);

        public MapBinsInModsContentSource(EverestContentRegistry registry, EverestLoaderProcess loader, string path) :
            base(registry)
        {
            Path = path;
            Loader = loader;
        }

        protected override void Crawl()
        {
            string[] files = Directory.GetFiles(Path);
            foreach (string text in files)
            {
                string file = text.Substring(Path.Length + 1);
                if (text.EndsWith(".bin") && Loader.ShouldLoadFile(file))
                {
                    Add("Maps/" + text.Substring(Path.Length + 1), new MapBinsInModsContentAsset(this, text));
                }
            }
        }
    }
}
