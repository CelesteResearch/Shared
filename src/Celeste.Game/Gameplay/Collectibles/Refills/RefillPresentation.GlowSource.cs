using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Display;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public static partial class RefillPresentation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateTimerAndGlowFromSource<TSource>(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ref float respawnTimer, Action respawn, in TSource source, PackedColor color)
            where TSource : struct, IRefillGlowParticleSource
        {
            UpdateTimerAndGlow(owner, engine, level, ref respawnTimer, respawn, in source,
                new ColoredParticleEmission(color));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateTimerAndGlow<TSource, TEmission>(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ref float respawnTimer, Action respawn, in TSource source, TEmission emission)
            where TSource : struct, IRefillGlowParticleSource where TEmission : struct, IRefillParticleEmission
        {
            var context = new DefaultRefillPresentationContext(engine);
            UpdateTimerAndGlow(owner, in context, level, ref respawnTimer, respawn, in source, emission);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateTimerAndGlow<TContext, TSource, TEmission>(SceneEntityState owner,
            in TContext context, IOriginalRefillScene level, ref float respawnTimer, Action respawn,
            in TSource source, TEmission emission)
            where TContext : struct, IRefillPresentationContext
            where TSource : struct, IRefillGlowParticleSource
            where TEmission : struct, IRefillParticleEmission
        {
            if (respawnTimer > 0f)
            {
                respawnTimer -= context.DeltaTime;
                if (respawnTimer <= 0f) respawn();
            }
            else if (context.OnInterval(owner.Scene, .1f))
            {
                var particles = level.ParticlesFG;
                var glow = source.GetGlow();
                emission.Emit(particles, glow, 1, owner.Position, Vector2.One * 5f);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateTimerAndGlow<TContext>(SceneEntityState owner, in TContext context,
            IOriginalRefillScene level, ref float respawnTimer, Action respawn, ParticleTypePresentation glow)
            where TContext : struct, IRefillPresentationContext
        {
            UpdateTimerAndGlow(owner, in context, level, ref respawnTimer, respawn,
                new FixedGlowParticleSource(glow), default(DefaultParticleEmission));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateTimerAndGlowFromSource<TContext, TSource>(SceneEntityState owner, in TContext context,
            IOriginalRefillScene level, ref float respawnTimer, Action respawn, in TSource source, PackedColor color)
            where TContext : struct, IRefillPresentationContext
            where TSource : struct, IRefillGlowParticleSource
        {
            UpdateTimerAndGlow(owner, in context, level, ref respawnTimer, respawn, in source,
                new ColoredParticleEmission(color));
        }

        private readonly struct FixedGlowParticleSource(ParticleTypePresentation glow) : IRefillGlowParticleSource
        {
            public ParticleTypePresentation GetGlow()
            {
                return glow;
            }
        }
    }
}
