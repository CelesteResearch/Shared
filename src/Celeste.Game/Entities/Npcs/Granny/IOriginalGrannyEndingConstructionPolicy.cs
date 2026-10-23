using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Npcs.Granny
{
    public interface IOriginalGrannyEndingConstructionPolicy
    {
        OriginalGrannyEndingState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            bool ch9EasterEgg = false);
    }
}
