using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Gameplay.Platforms.Clouds;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Everest.Gameplay.Platforms.Clouds
{
    public class EverestCloudState : OriginalCloudState
    {
        public bool? Small;

        public EverestCloudState(ISourceEngineContext engine, Vector2 position, bool fragile, ISourceSolidWorld world)
            : base(engine, position, fragile, world)
        {
        }

        public EverestCloudState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : base(engine, data, offset, world)
        {
        }

        protected override bool IsSmall(bool isSmall) => Small.GetValueOrDefault(isSmall);
    }
}
