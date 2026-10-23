using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;
using Celeste.Graphics.Animation;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public static partial class RefillPresentation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateTimerAndGlow(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ref float respawnTimer, Action respawn, ParticleTypePresentation glow,
            PackedColor color)
        {
            UpdateTimerAndGlow(owner, engine, level, ref respawnTimer, respawn, glow,
                new ColoredParticleEmission(color));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Respawn(SceneEntityState owner, IOriginalRefillProcess engine, IOriginalRefillScene level,
            Sprite sprite, SpriteImage outline, WigglerComponent wiggler, ParticleTypePresentation regen,
            string returnSound, int depth, PackedColor color)
        {
            Respawn(owner, engine, level, sprite, outline, wiggler, regen, returnSound, depth,
                new ColoredParticleEmission(color));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FinishRoutine(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ParticleTypePresentation shatter, float angle, PackedColor color)
        {
            FinishRoutine(owner, engine, level, shatter, angle, true, new ColoredParticleEmission(color));
        }

        private readonly struct DefaultParticleEmission : IRefillParticleEmission
        {
            public void Emit(ParticleSystemPresentation particles, ParticleTypePresentation type, int amount,
                Vector2 position, Vector2 range)
            {
                particles.Emit(type, amount, position, range);
            }

            public void Emit(ParticleSystemPresentation particles, ParticleTypePresentation type, int amount,
                Vector2 position, Vector2 range, float direction)
            {
                particles.Emit(type, amount, position, range, direction);
            }
        }

        private readonly struct ColoredParticleEmission : IRefillParticleEmission
        {
            private readonly PackedColor color;

            public ColoredParticleEmission(PackedColor color)
            {
                this.color = color;
            }

            public void Emit(ParticleSystemPresentation particles, ParticleTypePresentation type, int amount,
                Vector2 position, Vector2 range)
            {
                particles.Emit(type, amount, position, range, color);
            }

            public void Emit(ParticleSystemPresentation particles, ParticleTypePresentation type, int amount,
                Vector2 position, Vector2 range, float direction)
            {
                particles.Emit(type, amount, position, range, color, direction);
            }
        }
    }
}
