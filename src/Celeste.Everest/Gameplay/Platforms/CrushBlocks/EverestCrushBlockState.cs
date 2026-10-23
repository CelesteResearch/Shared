using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Platforms.CrushBlocks;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.CrushBlocks
{
    public class EverestCrushBlockState : OriginalCrushBlockState
    {
        public EverestCrushBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Axes axes,
            ISourceSolidWorld world, bool chillOut = false)
            : base(engine, position, width, height, axes, world, chillOut)
        {
        }

        public EverestCrushBlockState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : base(engine, data, offset, world)
        {
        }

        protected EverestCrushBlockState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world, string spriteDirectory)
            : base(engine, data, offset, world, spriteDirectory)
        {
        }

        protected override void StopMoveLoopForSlowdown()
        {
            var soundSource = CurrentMoveLoopSource;
            if (soundSource != null) soundSource = soundSource.Stop();
        }
    }
}
