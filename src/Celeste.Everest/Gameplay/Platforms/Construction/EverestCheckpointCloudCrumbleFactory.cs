using Celeste.Core.Scheduling;
using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Checkpoints;
using Celeste.Game.Gameplay.Platforms.Clouds;
using Celeste.Game.Gameplay.Platforms.Crumble;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Gameplay.Platforms.Construction;
using Celeste.Everest.Gameplay.Platforms.Clouds;
using Celeste.Everest.Gameplay.Platforms.Crumble;

namespace Celeste.Everest.Gameplay.Platforms.Construction
{
    public sealed class EverestCheckpointCloudCrumbleFactory : IOriginalCheckpointCloudCrumbleFactory
    {
        public OriginalCheckpointState CreateCheckpoint(EntityData data, Vector2 offset,
            IOriginalCheckpointProcess process)
            => new OriginalCheckpointState(data, offset, process);

        public OriginalCloudState CreateCloud(EntityData data, Vector2 offset, ISourceEngineContext process,
            ISourceSolidWorldFactory worlds)
            => new EverestCloudState(process, data, offset, worlds.CreateJumpThru(data.Position + offset, false));

        public OriginalCrumblePlatformState CreateCrumble(EntityData data, Vector2 offset,
            IOriginalCrumbleProcess process, ISourceSolidWorldFactory worlds)
            => new EverestCrumblePlatformState(data, offset, process, worlds);
    }
}
