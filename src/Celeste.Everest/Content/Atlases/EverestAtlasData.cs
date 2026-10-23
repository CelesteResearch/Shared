using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Content.Types.Directories;
using Celeste.Everest.Content.Types.Graphics;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Content.Atlases
{
    public class EverestAtlasData : AtlasData
    {
        private readonly EverestAtlasEvents events;
        private readonly EverestLoggerProcess logger;

        public EverestAtlasData(EverestAtlasEvents events,
            EverestLoggerProcess logger)
        {
            this.events = events;
            this.logger = logger;
        }

        public override AtlasEntry this[string id]
        {
            get
            {
                if (!Entries.TryGetValue(id, out var value))
                {
                    var fallback = events.GetCustomFallback(this, id);
                    if (fallback != null) return fallback;
                    logger.AtlasTextureMissing(RelativeDataPath, id);
                    return GetFallback();
                }

                return value;
            }
            set => Entries[id] = value;
        }

        public string DataMethod;
        public string DataPath;
        public string RelativeDataPath;
        public string[] DataPaths;
        public AtlasDataFormat? DataFormat;

        public void FixDataPath(string originalContentDirectory)
        {
            if (!(DataPath != null))
                return;
            var path = DataPath;
            if (path.StartsWith(originalContentDirectory))
                path = path.Substring(originalContentDirectory.Length + 1);
            RelativeDataPath = path.Replace('\\', '/') + "/";
        }

        public void Ingest(EverestContentAsset asset, EverestVirtualContent content,
            IEverestAtlasIngestDiagnostics diagnostics)
        {
            if (asset == null)
                return;
            if (asset.Type == typeof(AssetTypeDirectory))
                lock (asset.Children)
                {
                    foreach (var child in asset.Children)
                        Ingest(child, content, diagnostics);
                    return;
                }

            if (asset.Type != typeof(AssetTypeTexture))
                return;
            var path = asset.PathVirtual;
            if (!path.StartsWith(RelativeDataPath))
                return;
            path = path.Substring(RelativeDataPath.Length);
            if (Entries.TryGetValue(path, out var existing))
            {
                diagnostics.TextureOverridden(this, asset, path);
                ((EverestAtlasEntry)existing).SetOverride(asset, content);
                Entries[path] = existing;
                return;
            }

            EverestVirtualTexture texture;
            try
            {
                texture = content.CreateTexture(asset);
            }
            catch
            {
                diagnostics.TextureLoadFailed(this, asset, path);
                throw;
            }

            var meta = asset.GetMeta<EverestTextureMetadata>();
            EverestAtlasEntry entry;
            if (meta != null)
            {
                if (meta.Width == 0)
                    meta.Width = texture.Width;
                if (meta.Height == 0)
                    meta.Height = texture.Height;
                entry = new(texture, new(meta.X, meta.Y), meta.Width, meta.Height);
            }
            else
            {
                entry = new(texture);
            }

            entry.Name = path;
            entry.AtlasPath = path;
            entry.Atlas = this;
            entry.SetOverride(asset, content);
            Entries[path] = entry;
            Sources.Add(texture);
        }
    }
}
