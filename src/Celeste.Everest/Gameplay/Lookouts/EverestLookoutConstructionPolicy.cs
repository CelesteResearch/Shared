using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Lookouts;

namespace Celeste.Everest.Gameplay.Lookouts
{
    public sealed class EverestLookoutConstructionPolicy : IOriginalLookoutConstructionPolicy
    {
        public OriginalLookoutState Create(EntityData data, Vector2 offset, IOriginalLookoutProcess process)
        {
            return new EverestLookoutState(data, offset, process);
        }
    }
}
