using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.Audio
{
    public readonly struct SourceSurfaceSoundSelection
    {
        public SourcePlatformEntityState Platform { get; }
        public bool HasValue { get; }
        private readonly int wallSoundIndex;

        public SourceSurfaceSoundSelection(SourcePlatformEntityState platform)
        {
            Platform = platform;
            HasValue = platform != null;
            wallSoundIndex = 8;
        }

        public SourceSurfaceSoundSelection(int wallSoundIndex)
        {
            Platform = null;
            HasValue = true;
            this.wallSoundIndex = wallSoundIndex;
        }

        public int GetWallSoundIndex(ISourceEntityCollider player, int side) =>
            Platform != null ? Platform.GetWallSoundIndex(player, side) : wallSoundIndex;

        // The upstream holder overrides only wall sounds; Platform defaults remain 8.
        public int GetLandSoundIndex(ISourceEntityCollider entity) =>
            Platform != null ? Platform.GetLandSoundIndex(entity) : 8;

        public int GetStepSoundIndex(ISourceEntityCollider entity) =>
            Platform != null ? Platform.GetStepSoundIndex(entity) : 8;
    }
}
