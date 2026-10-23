using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Platforms.CrushBlocks;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.CrushBlocks
{
    public sealed class EverestCrushBlockConstructionPolicy : IOriginalCrushBlockConstructionPolicy
    {
        public static readonly EverestCrushBlockConstructionPolicy Instance = new();

        private EverestCrushBlockConstructionPolicy()
        {
        }

        public OriginalCrushBlockState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
        {
            return new EverestCrushBlockState(engine, data, offset, world);
        }
    }
}
