using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Birds.Paths;

namespace Celeste.Everest.Entities.Birds.Paths
{
    public sealed class EverestBirdPathFactory : IOriginalBirdPathFactory
    {
        public BirdPathState Create(MapEntityId id, EntityData data, Vector2 offset, ISourceEngineContext engine)
            => new EverestBirdPathState(id, data, offset, engine);
    }
}
