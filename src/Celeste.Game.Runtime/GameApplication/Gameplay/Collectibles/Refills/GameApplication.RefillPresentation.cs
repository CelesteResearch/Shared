using Celeste.Game.Gameplay.Collectibles.Refills;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IRefillPresentationBinder
    {
        IRefillPresentationBinding IRefillPresentationBinder.Bind<TPhases>(in TPhases phases)
            => new RefillPresentationBinding<TPhases>(this, in phases);

        private sealed class RefillPresentationBinding<TPhases> : IRefillPresentationBinding
            where TPhases : struct, IRefillPresentationPhases
        {
            private readonly GameApplication engine;
            private TPhases phases;

            public RefillPresentationBinding(GameApplication engine, in TPhases phases)
            {
                this.engine = engine;
                this.phases = phases;
            }

            public void Update()
            {
                var context = new RefillPresentationContext(engine);
                RefillPresentation.UpdatePresentation(in context, ref phases);
            }
        }

        private readonly struct RefillPresentationContext(GameApplication engine) : IRefillPresentationContext
        {
            public float DeltaTime => engine.DeltaTime;

            public Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic ExtremaArithmetic =>
                engine.ExtremaArithmetic;

            public bool OnInterval(object scene, float interval)
            {
                var clock = ((Celeste.Scene.Tracking.ISourceScene)scene).SourceScene.Clock;
                var arithmetic = engine.IntervalArithmetic;
                return arithmetic.OnInterval(clock.TimeActive, engine.DeltaTime, interval);
            }
        }
    }
}
