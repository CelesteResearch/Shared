using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Gameplay.Platforms.CrushBlocks;

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
            => new EverestCrushBlockState(engine, data, offset, world);
    }
}
