using System.IO;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Execution.Graphics
{
    public sealed class OriginalOverworldGraphicsResources
    {
        public AtlasData Atlas;
        public bool Loaded { get; private set; }

        public void Load(ISourceAtlasLoaderEnvironment environment)
        {
            Atlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases", "Overworld"),
                AtlasDataFormat.PackerNoAtlas, environment);
            Loaded = true;
        }

        public void Unload()
        {
            Atlas.Dispose();
            Atlas = null;
            Loaded = false;
        }
    }
}
