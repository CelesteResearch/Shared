using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock;

namespace Celeste.Everest.Gameplay.Platforms.FinalBossMovingBlock
{
    public sealed class EverestFinalBossMovingBlockConstruction : IOriginalFinalBossMovingBlockConstruction
    {
        public OriginalFinalBossMovingBlockState Create(EntityData data, Vector2 offset,
            ISourceEngineContext engine, ISourceSolidWorldFactory worlds) =>
            new EverestFinalBossMovingBlockState(data, offset, engine, worlds);
    }
}
