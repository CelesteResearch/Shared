using System.Xml;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.ProcessState;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Settings;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Text;

namespace Celeste.Game.Execution.Startup
{
// This resource loan holds no parallel banks, fonts, input, settings or scene state.
// Each member resolves the same process owner at the original reading point.
    public sealed class OriginalStartupResources : IGameLoaderSourceResources,
        global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope
    {
        private readonly ISourceEngineContext engine;
        public OriginalStartupResources(ISourceEngineContext engine) => this.engine = engine;

        public global::Celeste.Graphics.Rendering.Drawing.SourceDrawState Draw =>
            ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)engine).Draw;

        public OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;
        public OriginalGameProcessTiming ProcessTiming => ((IOriginalGameProcessTimingEnvironment)engine).ProcessTiming;
        public OriginalGameThreadSession Threads => ((IOriginalThreadEnvironment)engine).Threads;
        public ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        public ISourceRandom SpriteRandomContext => ((ISourceRandomProxyEnvironment)engine).RandomProxy;
        public OriginalParticleCatalog ParticleTypes => ((IOriginalGameplayProcess)engine).ParticleTypes;
        public OriginalMountainResources MountainResources => ((IOriginalMountainEnvironment)engine).MountainResources;

        public OriginalGameGraphicsResources GraphicsResources =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        public OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        public AtlasData OverworldAtlas => ((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas;
        public ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;
        public WigglerComponentPool WigglerPool => ((ISourceWigglerPoolScope)engine).WigglerPool;

        public ISourceAtlasConstruction AtlasConstruction =>
            ((global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment)engine).AtlasConstruction;

        public global::Celeste.Core.IO.Content.IContentSource ContentFiles =>
            ((global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment)engine).ContentFiles;

        public string ContentDirectory =>
            ((global::Celeste.Core.IO.ISourceContentDirectoryEnvironment)engine).ContentDirectory;

        public VirtualContent VirtualContent =>
            ((global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment)engine).VirtualContent;

        public XmlDocument LoadContentXml(string filename) =>
            ((global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment)engine).LoadContentXml(filename);

        public bool FmodLiveUpdate => ((ISettingsContext)engine).Settings.LaunchWithFMODLiveUpdate;
        public int MusicVolume => ((ISettingsContext)engine).Settings.MusicVolume;
        public int SfxVolume => ((ISettingsContext)engine).Settings.SFXVolume;

        public string SettingsLanguage
        {
            get => ((ISettingsContext)engine).Settings.LanguageId;
            set => ((ISettingsContext)engine).Settings.LanguageId = value;
        }

        public Sprite CreateSaveIcon() => GraphicsResources.GuiSpriteBank.Create("save");
        public string CleanDialog(string key) => Text.CleanDialog(key);
        public AtlasEntry GetGameParticleSource(string path) => GraphicsResources.GameAtlas[path];
        public void LoadAreas() => ((IOriginalAreaRegistryLoadEnvironment)engine).AreaRegistryLoad.Load();

        public OverworldLoaderSequence CreateTitlescreenLoader(HiresSnowState snow)
            => ((IOriginalOverworldLoaderEnvironment)engine).OverworldLoaders.CreateOverworldLoader(
                OverworldStartMode.Titlescreen, snow);
    }
}
