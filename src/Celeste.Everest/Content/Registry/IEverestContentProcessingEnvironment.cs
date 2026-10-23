using Celeste.Everest.Content.Atlases;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Text.BitmapFonts;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.ProcessState;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Content.Registry
{
    public interface IEverestContentProcessingEnvironment
    {
        EverestLoggerProcess Logger { get; }
        IEverestContentDumpEnvironment ContentDump { get; }
        ISourceAtlasLoaderEnvironment AtlasLoader { get; }
        EverestLoaderProcess Loader { get; }
        EverestYamlProcess Yaml { get; }
        EverestMainThreadProcess MainThread { get; }
        EverestAssetReloadProcess AssetReload { get; }
        OriginalGameTextProcess Text { get; }
        SourceEverestEmojiState Emoji { get; }
        EverestMountainExtensionProcess MountainExtension { get; }
        EverestVirtualContent VirtualContent { get; }
        IEverestAtlasIngestDiagnostics AtlasIngestDiagnostics { get; }
        AtlasData GuiAtlas { get; }
        bool ContentLoaded { get; }
        OriginalGameProcessTiming ProcessTiming { get; }
    }
}
