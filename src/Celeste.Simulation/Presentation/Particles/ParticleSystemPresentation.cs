using Celeste.Core.Display;
using Celeste.Scene.Scheduling;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Particles
{
    public sealed class ParticleSystemPresentation : global::Celeste.Scene.Entities.SceneEntityState
    {
        public bool MirrorReflection { get; set; }
        public global::Celeste.Simulation.Presentation.Particles.Simulation.ParticlePresentation[] Particles { get; }
        public int NextSlot { get; private set; }
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        public global::Celeste.Core.Randomness.ISourceRandom Random =>
            ((global::Celeste.Core.Randomness.ISourceRandomEnvironment)engine).Random;

        private readonly global::Celeste.Graphics.Particles.Sources.ISourceParticleTextureEnvironment textures;

        public ParticleSystemPresentation(int depth, int maxParticles,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            global::Celeste.Graphics.Particles.Sources.ISourceParticleTextureEnvironment textureEnvironment)
            : base(textureEnvironment.EntitySourceDataRegistration)
        {
            Particles =
                new global::Celeste.Simulation.Presentation.Particles.Simulation.ParticlePresentation[maxParticles];
            Depth = depth;
            textures = textureEnvironment ?? throw new ArgumentNullException(nameof(textureEnvironment));
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public void Clear()
        {
            for (int i = 0; i < Particles.Length; i++) Particles[i].Active = false;
        }

        public void ClearRect(global::Celeste.Core.Geometry.IntRect rect, bool inside)
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                var p = Particles[i].Position;
                if ((p.X > rect.Left && p.Y > rect.Top && p.X < rect.Right && p.Y < rect.Bottom) == inside)
                    Particles[i].Active = false;
            }
        }

        public override void Update()
        {
            for (int i = 0; i < Particles.Length; i++)
                if (Particles[i].Active)
                    Particles[i].Update(textures, engine);
        }

        public void Simulate(float duration, float interval,
            Action<global::Celeste.Simulation.Presentation.Particles.ParticleSystemPresentation> emitter)
        {
            const float step = .016f;
            for (float at = 0; at < duration; at += step)
            {
                if ((int)((at - step) / interval) < (int)(at / interval)) emitter(this);
                for (int i = 0; i < Particles.Length; i++)
                    if (Particles[i].Active)
                        Particles[i].Advance(textures, step);
            }
        }

        public void Add(global::Celeste.Simulation.Presentation.Particles.Simulation.ParticlePresentation particle)
        {
            Particles[NextSlot] = particle;
            Advance();
        }

        private void Advance()
        {
            NextSlot = (NextSlot + 1) % Particles.Length;
        }

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            Vector2 position) =>
            Emit(type, position, type.Color, type.Direction);

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            Vector2 position, float direction) =>
            Emit(type, position, type.Color, direction);

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            Vector2 position, global::Celeste.Core.Display.PackedColor color) =>
            Emit(type, position, color, type.Direction);

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            Vector2 position, global::Celeste.Core.Display.PackedColor color, float direction)
        {
            type.Create(ref Particles[NextSlot], null, position, direction, color, Random, textures);
            Advance();
        }

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            int amount, Vector2 position, Vector2 range) =>
            Emit(type, amount, position, range, type.Color, type.Direction);

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            int amount, Vector2 position, Vector2 range, float direction) =>
            Emit(type, amount, position, range, type.Color, direction);

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            int amount, Vector2 position, Vector2 range, global::Celeste.Core.Display.PackedColor color) =>
            Emit(type, amount, position, range, color, type.Direction);

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            int amount, Vector2 position, Vector2 range, global::Celeste.Core.Display.PackedColor color,
            float direction)
        {
            for (int i = 0; i < amount; i++) Emit(type, RandomPosition(position, range), color, direction);
        }

        public void Emit(global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type,
            global::Celeste.Graphics.Particles.Tracking.IParticleTrack track, int amount, Vector2 position,
            Vector2 range, float direction)
        {
            for (int i = 0; i < amount; i++)
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

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            var array = Particles;
            for (int i = 0; i < array.Length; i++)
            {
                var particle = array[i];
                if (particle.Active) particle.Render(context, this);
            }
        }

        public void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, float alpha)
        {
            var array = Particles;
            for (int i = 0; i < array.Length; i++)
            {
                var particle = array[i];
                if (particle.Active) particle.Render(context, this, alpha);
            }
        }
    }
}
