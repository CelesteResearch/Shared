using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.CrushBlocks
{
    public interface IOriginalCrushBlockConstructionPolicy
    {
        OriginalCrushBlockState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world);
    }
}
