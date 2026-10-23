using Celeste.Core.Scheduling;
using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Checkpoints;
using Celeste.Game.Gameplay.Platforms.Clouds;
using Celeste.Game.Gameplay.Platforms.Crumble;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.Construction
{
    public sealed class OriginalCheckpointCloudCrumbleFactory : IOriginalCheckpointCloudCrumbleFactory
    {
        public OriginalCheckpointState CreateCheckpoint(EntityData data, Vector2 offset,
            IOriginalCheckpointProcess process)
            => new OriginalCheckpointState(data, offset, process);

        public OriginalCloudState CreateCloud(EntityData data, Vector2 offset, ISourceEngineContext process,
            ISourceSolidWorldFactory worlds)
            => new OriginalCloudState(process, data, offset, worlds.CreateJumpThru(data.Position + offset, false));

        public OriginalCrumblePlatformState CreateCrumble(EntityData data, Vector2 offset,
            IOriginalCrumbleProcess process, ISourceSolidWorldFactory worlds)
            => new OriginalCrumblePlatformState(data, offset, process, worlds);
    }
}
