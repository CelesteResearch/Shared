using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Game.Gameplay.Effects.Slashes;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public static partial class RefillPresentation
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void UpdateTimerAndGlow(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ref float respawnTimer, Action respawn, ParticleTypePresentation glow)
            => UpdateTimerAndGlow(owner, engine, level, ref respawnTimer, respawn, glow,
                default(DefaultParticleEmission));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateTimerAndGlow<TEmission>(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ref float respawnTimer, Action respawn, ParticleTypePresentation glow,
            TEmission emission) where TEmission : struct, IRefillParticleEmission
            => UpdateTimerAndGlow(owner, engine, level, ref respawnTimer, respawn, new FixedGlowParticleSource(glow),
                emission);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateY(Sprite sprite, Sprite flash, BloomPointState bloom, SineWaveState sine)
        {
            float y = bloom.Y = sine.Value * 2f;
            sprite.Position.Y = y;
            flash.Position.Y = y;
        }

        public static void UpdateLightAndFlash(SceneEntityState owner, IOriginalRefillProcess engine, Sprite sprite,
            Sprite flash, VertexLightState light, BloomPointState bloom)
        {
            var context = new DefaultRefillPresentationContext(engine);
            UpdateLighting(owner, in context, sprite, flash, light, bloom);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Respawn(SceneEntityState owner, IOriginalRefillProcess engine, IOriginalRefillScene level,
            Sprite sprite, SpriteImage outline, WigglerComponent wiggler, ParticleTypePresentation regen,
            string returnSound)
            => Respawn(owner, engine, level, sprite, outline, wiggler, regen, returnSound, -100,
                default(DefaultParticleEmission));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Respawn<TEmission>(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level,
            Sprite sprite, SpriteImage outline, WigglerComponent wiggler, ParticleTypePresentation regen,
            string returnSound, int depth, TEmission emission) where TEmission : struct, IRefillParticleEmission
            => Respawn(owner, engine, level, sprite, outline, wiggler, regen, returnSound, depth, emission,
                default(IdentityReturnSound));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Respawn<TEmission, TSound>(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, Sprite sprite, SpriteImage outline, WigglerComponent wiggler,
            ParticleTypePresentation regen, string returnSound, int depth, TEmission emission, TSound sound)
            where TEmission : struct, IRefillParticleEmission
            where TSound : struct, IRefillReturnSound
        {
            if (!owner.Collidable)
            {
                owner.Collidable = true;
                sprite.Visible = true;
                outline.Visible = false;
                owner.Depth = depth;
                wiggler.Start();
                engine.SpatialAudio.Play(sound.Resolve(returnSound), owner.Position);
                emission.Emit(level.ParticlesFG, regen, 16, owner.Position, Vector2.One * 2f);
            }
        }

        public static void RenderOutline(ISourceRenderContext context, Sprite sprite)
        {
            if (sprite.Visible) sprite.DrawOutline(context);
        }

        public static void BeginRoutine(IOriginalRefillProcess engine) => engine.Freeze(0.05f);

        public static void HideForRoutine(SceneEntityState owner,
            Sprite sprite, Sprite flash, SpriteImage outline, bool oneUse)
        {
            sprite.Visible = flash.Visible = false;
            if (!oneUse) outline.Visible = true;
            owner.Depth = 8999;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void FinishRoutine(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ParticleTypePresentation shatter, RoomPlayerSession player)
        {
            FinishRoutine(owner, engine, level, shatter, Vector2Geometry.Angle(player.Speed));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FinishRoutine(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ParticleTypePresentation shatter, float angle)
            => FinishRoutine(owner, engine, level, shatter, angle, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FinishRoutine(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ParticleTypePresentation shatter, float angle, bool emitFirstShatter)
            => FinishRoutine(owner, engine, level, shatter, angle, emitFirstShatter, default(DefaultParticleEmission));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void FinishRoutine<TEmission>(SceneEntityState owner, IOriginalRefillProcess engine,
            IOriginalRefillScene level, ParticleTypePresentation shatter, float angle, bool emitFirstShatter,
            TEmission emission) where TEmission : struct, IRefillParticleEmission
        {
            if (emitFirstShatter)
                emission.Emit(level.ParticlesFG, shatter, 5, owner.Position, Vector2.One * 4f,
                    angle - (float)Math.PI / 2f);
            emission.Emit(level.ParticlesFG, shatter, 5, owner.Position, Vector2.One * 4f, angle + (float)Math.PI / 2f);
            OriginalSlashFxState.Burst(engine, owner.Position, angle);
        }
    }
}
