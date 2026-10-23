using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.FinalBossMovingBlock
{
    public sealed class EverestFinalBossMovingBlockState : OriginalFinalBossMovingBlockState
    {
        public EverestFinalBossMovingBlockState(EntityData data, Vector2 offset, ISourceEngineContext engine,
            ISourceSolidWorldFactory worlds) : base(data, offset, engine, worlds)
        {
        }

        public EverestFinalBossMovingBlockState(Vector2[] nodes, float width, float height, int bossNodeIndex,
            ISourceEngineContext engine, ISourceSolidWorldFactory worlds) : base(nodes, width, height, bossNodeIndex,
            engine, worlds)
        {
        }

        internal Vector2 movementCounter { get; }

        protected override void MoveAlongTween(Vector2 from, Vector2 to, float eased)
        {
            var x = from.X + (to.X - (double)from.X) * eased;
            var y = from.Y + (to.Y - (double)from.Y) * eased;
            MoveH((float)(x - Position.X - MovementCounter.X));
            MoveV((float)(JitBarrier((float)y) - (double)Position.Y - MovementCounter.Y));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static float JitBarrier(float value)
        {
            return value;
        }
    }
}
