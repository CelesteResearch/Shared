using System.IO;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Atlases;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess : IEverestAtlasIngestDiagnostics
    {
        public void TextureOverridden(EverestAtlasData atlas, EverestContentAsset asset, string path)
        {
            if (shouldLog("Atlas.Ingest", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "Atlas.Ingest",
                    Path.GetFileName(atlas.DataPath) + " + (" + (asset.Source?.Name ?? "???") + ") " + path);
        }

        public void TextureLoadFailed(EverestAtlasData atlas, EverestContentAsset asset, string path)
        {
            if (shouldLog("Atlas.Ingest", EverestLogLevel.Error))
                LogUnchecked(EverestLogLevel.Error, "Atlas.Ingest",
                    "Error while loading texture " + path + " (" + (asset.Source?.Name ?? "???") + ") into atlas " +
                    Path.GetFileName(atlas.DataPath));
        }
    }
}
