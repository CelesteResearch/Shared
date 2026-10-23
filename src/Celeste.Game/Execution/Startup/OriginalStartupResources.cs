using System.Xml;
using Celeste.Core.IO;
using Celeste.Core.IO.Content;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.ProcessState;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Settings;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text;
using Celeste.Scene.Components.Oscillation;

namespace Celeste.Game.Execution.Startup
{
// This resource loan holds no parallel banks, fonts, input, settings or scene state.
// Each member resolves the same process owner at the original reading point.
    public sealed class OriginalStartupResources : IGameLoaderSourceResources,
        ISourceDrawScope
    {
        private readonly ISourceEngineContext engine;

        public OriginalStartupResources(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public SourceDrawState Draw =>
            ((ISourceDrawScope)engine).Draw;

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
            ((ISourceAtlasLoaderEnvironment)engine).AtlasConstruction;

        public IContentSource ContentFiles =>
            ((ISourceAtlasLoaderEnvironment)engine).ContentFiles;

        public string ContentDirectory =>
            ((ISourceContentDirectoryEnvironment)engine).ContentDirectory;

        public VirtualContent VirtualContent =>
            ((ISourceAtlasLoaderEnvironment)engine).VirtualContent;

        public XmlDocument LoadContentXml(string filename)
        {
            return ((ISourceAtlasLoaderEnvironment)engine)
                .LoadContentXml(filename);
        }

        public bool FmodLiveUpdate => ((ISettingsContext)engine).Settings.LaunchWithFMODLiveUpdate;
        public int MusicVolume => ((ISettingsContext)engine).Settings.MusicVolume;
        public int SfxVolume => ((ISettingsContext)engine).Settings.SFXVolume;

        public string SettingsLanguage
        {
            get => ((ISettingsContext)engine).Settings.LanguageId;
            set => ((ISettingsContext)engine).Settings.LanguageId = value;
        }

        public Sprite CreateSaveIcon()
        {
            return GraphicsResources.GuiSpriteBank.Create("save");
        }

        public string CleanDialog(string key)
        {
            return Text.CleanDialog(key);
        }

        public AtlasEntry GetGameParticleSource(string path)
        {
            return GraphicsResources.GameAtlas[path];
        }

        public void LoadAreas()
        {
            ((IOriginalAreaRegistryLoadEnvironment)engine).AreaRegistryLoad.Load();
        }

        public OverworldLoaderSequence CreateTitlescreenLoader(HiresSnowState snow)
        {
            return ((IOriginalOverworldLoaderEnvironment)engine).OverworldLoaders.CreateOverworldLoader(
                OverworldStartMode.Titlescreen, snow);
        }
    }
}
