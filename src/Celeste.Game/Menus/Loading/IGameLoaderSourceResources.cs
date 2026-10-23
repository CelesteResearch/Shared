using System;
using System.Diagnostics;
using System.Threading;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Menus.Loading
{
// Resource/thread IO and actual shared resource publications. No Scene update callbacks.
// Implementations must borrow the process resource and audio owners, never menu copies.
    public interface IGameLoaderSourceResources : IAutoSavingNoticeResources,
        global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment,
        global::Celeste.Game.Presentation.Particles.IOriginalParticleResources
    {
        AtlasData OverworldAtlas { get; }
        global::Celeste.Core.Randomness.ISourceRandom Random { get; }
        global::Celeste.Core.Randomness.ISourceRandom SpriteRandomContext { get; }
        OriginalGameAudioSession Audio { get; }
        Celeste.Game.Execution.ProcessState.OriginalGameProcessTiming ProcessTiming { get; }
        global::Celeste.Game.Execution.Threading.OriginalGameThreadSession Threads { get; }
        bool FmodLiveUpdate { get; }
        int MusicVolume { get; }
        int SfxVolume { get; }
        global::Celeste.Game.Presentation.Particles.OriginalParticleCatalog ParticleTypes { get; }
        global::Celeste.Game.Execution.Graphics.OriginalMountainResources MountainResources { get; }
        Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources GraphicsResources { get; }
        Celeste.Game.Content.Dialogs.OriginalGameTextProcess Text { get; }
        string SettingsLanguage { get; set; }
        void LoadAreas();
        OverworldLoaderSequence CreateTitlescreenLoader(HiresSnowState snow);
    }
}
