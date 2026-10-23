using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Particles.Sources;
using Celeste.Graphics.Particles.Tracking;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.Particles.Simulation;

namespace Celeste.Simulation.Presentation.Particles.Emission
{
    public class ParticleEmitterState : SourceComponentState
    {
        public ParticleSystemPresentation System;
        public ParticleTypePresentation Type;
        public IParticleTrack Track;
        public float Interval;
        public Vector2 Position;
        public Vector2 Range;
        public int Amount;
        public float? Direction;
        private float timer;
        private readonly ISourceEngineContext engine;

        public ParticleEmitterState(ParticleSystemPresentation system, ParticleTypePresentation type,
            Vector2 position, Vector2 range, int amount, float interval, ISourceEngineContext engine)
            : base(true, false)
        {
            System = system;
            Type = type;
            Position = position;
            Range = range;
            Amount = amount;
            Interval = interval;
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public ParticleEmitterState(ParticleSystemPresentation system, ParticleTypePresentation type,
            Vector2 position, Vector2 range, float direction, int amount, float interval, ISourceEngineContext engine)
            : this(system, type, position, range, amount, interval, engine)
        {
            Direction = direction;
        }

        public ParticleEmitterState(ParticleSystemPresentation system, ParticleTypePresentation type,
            IParticleTrack track,
            Vector2 position, Vector2 range, float direction, int amount, float interval, ISourceEngineContext engine)
            : this(system, type, position, range, amount, interval, engine)
        {
            Direction = direction;
            Track = track;
        }

        public void SimulateCycle()
        {
            Simulate(Type.LifeMax);
        }

        public void Simulate(float duration)
        {
            var amount = duration / Interval;
            for (var i = 0; i < amount; i++)
            for (var j = 0; j < Amount; j++)
            {
                ParticlePresentation particle = default;
                var random = ((ISourceRandomEnvironment)engine).Random;
                var range = SourceRandomMath.Range(random, -Range, Range);
                var position = ((ISourceEntityPosition)Entity).Position + Position + range;
                particle = Type.Create(ref particle, null, position, Direction ?? Type.Direction, Type.Color,
                    random, (ISourceParticleTextureEnvironment)engine);
                particle.Track = Track;
                var remainingDuration = duration - Interval * i;
                if (particle.SimulateFor((ISourceParticleTextureEnvironment)engine, remainingDuration,
                        engine.Effects.TimeRate,
                        ((ISourceEngineTimingEnvironment)engine).TargetElapsedTime))
                    System.Add(particle);
            }
        }

        public void Emit()
        {
            var position = ((ISourceEntityPosition)Entity).Position + Position;
            if (Direction.HasValue) System.Emit(Type, Amount, position, Range, Direction.Value);
            else System.Emit(Type, Amount, position, Range);
        }

        public override void Update()
        {
            timer -= engine.DeltaTime;
            if (timer <= 0f)
            {
                timer = Interval;
                Emit();
            }
        }
    }
}
