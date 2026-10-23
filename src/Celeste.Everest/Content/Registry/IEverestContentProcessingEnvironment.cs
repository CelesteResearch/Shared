using System;
using System.IO;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Atlases;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Content.Types.Directories;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Text.BitmapFonts;
using Celeste.Game.Content.Dialogs;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Content.Registry
{
    public interface IEverestContentProcessingEnvironment
    {
        EverestLoggerProcess Logger { get; }
        IEverestContentDumpEnvironment ContentDump { get; }
        global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment AtlasLoader { get; }
        global::Celeste.Everest.Modules.Updating.EverestLoaderProcess Loader { get; }
        global::Celeste.Everest.Content.Serialization.EverestYamlProcess Yaml { get; }
        EverestMainThreadProcess MainThread { get; }
        EverestAssetReloadProcess AssetReload { get; }
        OriginalGameTextProcess Text { get; }
        SourceEverestEmojiState Emoji { get; }
        EverestMountainExtensionProcess MountainExtension { get; }
        EverestVirtualContent VirtualContent { get; }
        IEverestAtlasIngestDiagnostics AtlasIngestDiagnostics { get; }
        AtlasData GuiAtlas { get; }
        bool ContentLoaded { get; }
        global::Celeste.Game.Execution.ProcessState.OriginalGameProcessTiming ProcessTiming { get; }
    }
}
