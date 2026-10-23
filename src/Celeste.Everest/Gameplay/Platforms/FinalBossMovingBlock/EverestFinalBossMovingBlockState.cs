using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock;

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
            double x = (double)from.X + ((double)to.X - (double)from.X) * (double)eased;
            double y = (double)from.Y + ((double)to.Y - (double)from.Y) * (double)eased;
            MoveH((float)(x - (double)Position.X - (double)MovementCounter.X));
            MoveV((float)((double)JitBarrier((float)y) - (double)Position.Y - (double)MovementCounter.Y));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static float JitBarrier(float value) => value;
    }
}
