using Celeste.Core.Randomness;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.ProcessState;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Particles;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Menus.Loading
{
// Resource/thread IO and actual shared resource publications. No Scene update callbacks.
// Implementations must borrow the process resource and audio owners, never menu copies.
    public interface IGameLoaderSourceResources : IAutoSavingNoticeResources,
        ISourceAtlasLoaderEnvironment,
        IOriginalParticleResources
    {
        AtlasData OverworldAtlas { get; }
        ISourceRandom Random { get; }
        ISourceRandom SpriteRandomContext { get; }
        OriginalGameAudioSession Audio { get; }
        OriginalGameProcessTiming ProcessTiming { get; }
        OriginalGameThreadSession Threads { get; }
        bool FmodLiveUpdate { get; }
        int MusicVolume { get; }
        int SfxVolume { get; }
        OriginalParticleCatalog ParticleTypes { get; }
        OriginalMountainResources MountainResources { get; }
        OriginalGameGraphicsResources GraphicsResources { get; }
        OriginalGameTextProcess Text { get; }
        string SettingsLanguage { get; set; }
        void LoadAreas();
        OverworldLoaderSequence CreateTitlescreenLoader(HiresSnowState snow);
    }
}
