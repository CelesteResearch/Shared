using System.Numerics;
using Celeste.Everest.Content.Registry;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Core.Geometry;
using Celeste.Everest.Content.Textures;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Everest.Content.Atlases
{
    public sealed class EverestAtlasConstruction : ISourceAtlasConstruction, ISourceAtlasLoadProvenance
    {
        private readonly EverestContentRegistry content;
        private readonly EverestAtlasEvents events;
        private readonly global::Celeste.Everest.Diagnostics.Logging.EverestLoggerProcess logger;

        public EverestAtlasConstruction(EverestContentRegistry content, EverestAtlasEvents events,
            global::Celeste.Everest.Diagnostics.Logging.EverestLoggerProcess logger)
        {
            this.content = content;
            this.events = events;
            this.logger = logger;
        }

        public void PublishProvenance(AtlasData atlas, string method, string path, string[] paths,
            AtlasDataFormat? format)
        {
            var installedAtlas = (EverestAtlasData)atlas;
            installedAtlas.DataMethod = method;
            installedAtlas.DataPath = path;
            if (method == "FromMultiAtlas") installedAtlas.DataPaths = paths;
            if (method != "FromDirectory") installedAtlas.DataFormat = format;
            installedAtlas.FixDataPath(content.PathContentOrig);
            content.ProcessLoad(installedAtlas, path);
        }

        public bool UsesInstalledReadPolicy => true;
        public AtlasData CreateAtlas() => new EverestAtlasData(events, logger);

        public AtlasEntry CreateEntry(VirtualTexture texture, AtlasData atlas) =>
            new EverestAtlasEntry(texture) { Atlas = atlas };

        public AtlasEntry CreateEntry(VirtualTexture texture, Vector2 offset, int width, int height, AtlasData atlas) =>
            new EverestAtlasEntry(texture, offset, width, height) { Atlas = atlas };

        public AtlasEntry CreateEntry(AtlasEntry parent, string name, IntRect clip) =>
            new EverestAtlasEntry((EverestAtlasEntry)parent, name, clip);

        public AtlasEntry
            CreateEntry(AtlasEntry parent, string name, IntRect clip, Vector2 offset, int width, int height) =>
            new EverestAtlasEntry((EverestAtlasEntry)parent, name, clip, offset, width, height);
    }
}
