using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.CrushBlocks
{
    public sealed class OriginalCrushBlockConstructionPolicy : IOriginalCrushBlockConstructionPolicy
    {
        public static readonly OriginalCrushBlockConstructionPolicy Instance = new();

        private OriginalCrushBlockConstructionPolicy()
        {
        }

        public OriginalCrushBlockState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            => new OriginalCrushBlockState(engine, data, offset, world);
    }
}
