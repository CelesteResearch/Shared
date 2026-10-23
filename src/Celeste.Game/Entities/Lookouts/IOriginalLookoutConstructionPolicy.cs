using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Lookouts
{
    public interface IOriginalLookoutConstructionPolicy
    {
        OriginalLookoutState Create(EntityData data, Vector2 offset, IOriginalLookoutProcess process);
    }
}
