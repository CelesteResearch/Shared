using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.FinalBossMovingBlock
{
    public sealed class EverestFinalBossMovingBlockConstruction : IOriginalFinalBossMovingBlockConstruction
    {
        public OriginalFinalBossMovingBlockState Create(EntityData data, Vector2 offset,
            ISourceEngineContext engine, ISourceSolidWorldFactory worlds)
        {
            return new EverestFinalBossMovingBlockState(data, offset, engine, worlds);
        }
    }
}
