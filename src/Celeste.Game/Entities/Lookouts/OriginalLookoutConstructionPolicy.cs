using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Lookouts
{
    public sealed class OriginalLookoutConstructionPolicy : IOriginalLookoutConstructionPolicy
    {
        public OriginalLookoutState Create(EntityData data, Vector2 offset, IOriginalLookoutProcess process)
            => new OriginalLookoutState(data, offset, process);
    }
}
