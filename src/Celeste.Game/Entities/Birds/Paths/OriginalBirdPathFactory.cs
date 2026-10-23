using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Birds.Paths
{
    public sealed class OriginalBirdPathFactory : IOriginalBirdPathFactory
    {
        public BirdPathState Create(MapEntityId id, EntityData data, Vector2 offset, ISourceEngineContext engine)
            => new BirdPathState(id, data, offset, engine);
    }
}
