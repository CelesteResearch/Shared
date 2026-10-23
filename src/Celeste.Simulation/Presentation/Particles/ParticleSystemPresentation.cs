using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Particles.Sources;
using Celeste.Graphics.Particles.Tracking;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.Particles.Simulation;

namespace Celeste.Simulation.Presentation.Particles
{
    public sealed class ParticleSystemPresentation : SceneEntityState
    {
        public bool MirrorReflection { get; set; }
        public ParticlePresentation[] Particles { get; }
        public int NextSlot { get; private set; }
        private readonly ISourceEngineContext engine;

        public ISourceRandom Random =>
            ((ISourceRandomEnvironment)engine).Random;

        private readonly ISourceParticleTextureEnvironment textures;

        public ParticleSystemPresentation(int depth, int maxParticles,
            ISourceEngineContext engine,
            ISourceParticleTextureEnvironment textureEnvironment)
            : base(textureEnvironment.EntitySourceDataRegistration)
        {
            Particles =
                new ParticlePresentation[maxParticles];
            Depth = depth;
            textures = textureEnvironment ?? throw new ArgumentNullException(nameof(textureEnvironment));
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public void Clear()
        {
            for (var i = 0; i < Particles.Length; i++) Particles[i].Active = false;
        }

        public void ClearRect(IntRect rect, bool inside)
        {
            for (var i = 0; i < Particles.Length; i++)
            {
                var p = Particles[i].Position;
                if ((p.X > rect.Left && p.Y > rect.Top && p.X < rect.Right && p.Y < rect.Bottom) == inside)
                    Particles[i].Active = false;
            }
        }

        public override void Update()
        {
            for (var i = 0; i < Particles.Length; i++)
                if (Particles[i].Active)
                    Particles[i].Update(textures, engine);
        }

        public void Simulate(float duration, float interval,
            Action<ParticleSystemPresentation> emitter)
        {
            const float step = .016f;
            for (float at = 0; at < duration; at += step)
            {
                if ((int)((at - step) / interval) < (int)(at / interval)) emitter(this);
                for (var i = 0; i < Particles.Length; i++)
                    if (Particles[i].Active)
                        Particles[i].Advance(textures, step);
            }
        }

        public void Add(ParticlePresentation particle)
        {
            Particles[NextSlot] = particle;
            Advance();
        }

        private void Advance()
        {
            NextSlot = (NextSlot + 1) % Particles.Length;
        }

        public void Emit(ParticleTypePresentation type,
            Vector2 position)
        {
            Emit(type, position, type.Color, type.Direction);
        }

        public void Emit(ParticleTypePresentation type,
            Vector2 position, float direction)
        {
            Emit(type, position, type.Color, direction);
        }

        public void Emit(ParticleTypePresentation type,
            Vector2 position, PackedColor color)
        {
            Emit(type, position, color, type.Direction);
        }

        public void Emit(ParticleTypePresentation type,
            Vector2 position, PackedColor color, float direction)
        {
            type.Create(ref Particles[NextSlot], null, position, direction, color, Random, textures);
            Advance();
        }

        public void Emit(ParticleTypePresentation type,
            int amount, Vector2 position, Vector2 range)
        {
            Emit(type, amount, position, range, type.Color, type.Direction);
        }

        public void Emit(ParticleTypePresentation type,
            int amount, Vector2 position, Vector2 range, float direction)
        {
            Emit(type, amount, position, range, type.Color, direction);
        }

        public void Emit(ParticleTypePresentation type,
            int amount, Vector2 position, Vector2 range, PackedColor color)
        {
            Emit(type, amount, position, range, color, type.Direction);
        }

        public void Emit(ParticleTypePresentation type,
            int amount, Vector2 position, Vector2 range, PackedColor color,
            float direction)
        {
            for (var i = 0; i < amount; i++) Emit(type, RandomPosition(position, range), color, direction);
        }

        public void Emit(ParticleTypePresentation type,
            IParticleTrack track, int amount, Vector2 position,
            Vector2 range, float direction)
        {
            for (var i = 0; i < amount; i++)
            {
                type.Create(ref Particles[NextSlot], track, RandomPosition(position, range), direction, type.Color,
                    Random, textures);
                Advance();
            }
        }

        private Vector2 RandomPosition(Vector2 position, Vector2 range)
        {
            Vector2 min = position - range, max = position + range;
            return min + new Vector2((float)Random.NextDouble() * (max.X - min.X),
                (float)Random.NextDouble() * (max.Y - min.Y));
        }

        public override void Render(ISourceRenderContext context)
        {
            var array = Particles;
            for (var i = 0; i < array.Length; i++)
            {
                var particle = array[i];
                if (particle.Active) particle.Render(context, this);
            }
        }

        public void Render(ISourceRenderContext context, float alpha)
        {
            var array = Particles;
            for (var i = 0; i < array.Length; i++)
            {
                var particle = array[i];
                if (particle.Active) particle.Render(context, this, alpha);
            }
        }
    }
}
