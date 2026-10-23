using System.Numerics;
using Celeste.Game.Entities.Lookouts;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Everest.Gameplay.Lookouts
{
    public sealed class EverestLookoutConstructionPolicy : IOriginalLookoutConstructionPolicy
    {
        public OriginalLookoutState Create(EntityData data, Vector2 offset, IOriginalLookoutProcess process)
            => new EverestLookoutState(data, offset, process);
    }
}
