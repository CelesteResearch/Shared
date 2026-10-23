using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock
{
    public sealed class OriginalFinalBossMovingBlockConstruction : IOriginalFinalBossMovingBlockConstruction
    {
        public OriginalFinalBossMovingBlockState Create(EntityData data, Vector2 offset,
            ISourceEngineContext engine, ISourceSolidWorldFactory worlds)
        {
            return new(data, offset, engine, worlds);
        }
    }
}
