using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.Clouds
{
    public sealed class OriginalCloudConstructionPolicy : IOriginalCloudConstructionPolicy
    {
        public static readonly OriginalCloudConstructionPolicy Instance = new();

        private OriginalCloudConstructionPolicy()
        {
        }

        public OriginalCloudState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            => new OriginalCloudState(engine, data, offset, world);
    }
}
