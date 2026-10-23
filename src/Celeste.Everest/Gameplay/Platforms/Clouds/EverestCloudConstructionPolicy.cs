using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Gameplay.Platforms.Clouds;

namespace Celeste.Everest.Gameplay.Platforms.Clouds
{
    public sealed class EverestCloudConstructionPolicy : IOriginalCloudConstructionPolicy
    {
        public static readonly EverestCloudConstructionPolicy Instance = new();

        private EverestCloudConstructionPolicy()
        {
        }

        public OriginalCloudState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            => new EverestCloudState(engine, data, offset, world);
    }
}
