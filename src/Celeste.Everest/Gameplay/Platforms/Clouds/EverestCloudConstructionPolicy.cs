using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Platforms.Clouds;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

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
        {
            return new EverestCloudState(engine, data, offset, world);
        }
    }
}
