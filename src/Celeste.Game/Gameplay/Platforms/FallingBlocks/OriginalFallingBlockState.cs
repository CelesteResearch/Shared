using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.FallingBlocks
{
    public partial class OriginalFallingBlockState : FallingBlockState
    {
        public OriginalFallingBlockState(Vector2 position, char tile, int width, int height, bool finalBoss,
            bool behind, bool climbFall, ISourceSolidWorld world, ISourceEngineContext engine)
            : base(position, tile, width, height, finalBoss, behind, climbFall, world, engine)
        {
        }

        public override void OnShake(Vector2 amount) => base.OnShake(amount);

        public override void OnStaticMoverTrigger(
            Celeste.Simulation.Gameplay.Platforms.StaticMovers.SourceStaticMoverState mover) =>
            base.OnStaticMoverTrigger(mover);

        // Concrete source methods remain hook targets. Helper siblings bypass those original-only hooks.
        protected override IEnumerator CreateSequence() => Sequence();

        private IEnumerator Sequence()
        {
            var routine = SequenceCore();
            try
            {
                while (routine.MoveNext()) yield return routine.Current;
            }
            finally
            {
                (routine as IDisposable)?.Dispose();
            }
        }

        protected override IEnumerator HighlightFadeCore(float to) => HighlightFade(to);

        private IEnumerator HighlightFade(float to)
        {
            var routine = base.HighlightFadeCore(to);
            try
            {
                while (routine.MoveNext()) yield return routine.Current;
            }
            finally
            {
                (routine as IDisposable)?.Dispose();
            }
        }

        protected override bool PlayerFallCheckCore() => PlayerFallCheck();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool PlayerFallCheck() => base.PlayerFallCheckCore();

        protected override bool PlayerWaitCheckCore() => PlayerWaitCheck();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool PlayerWaitCheck() => base.PlayerWaitCheckCore();

        protected override void LandParticlesCore() => LandParticles();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void LandParticles() => base.LandParticlesCore();

        protected override void ShakeSfxCore() => ShakeSfx();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ShakeSfx() => base.ShakeSfxCore();

        protected override void ImpactSfxCore() => ImpactSfx();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ImpactSfx() => base.ImpactSfxCore();
    }
}
