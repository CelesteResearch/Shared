using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Particles.Sources;
using Celeste.Graphics.Particles.Tracking;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Simulation.Presentation.Particles.Simulation
{
    public struct ParticlePresentation
    {
        public IParticleTrack Track;
        public ParticleTypePresentation Type;
        public AtlasEntry Source;
        public bool Active;
        public PackedColor Color, StartColor;
        public Vector2 Position, Speed;
        public float Size, StartSize, Life, StartLife, ColorSwitch, Rotation, Spin;

        public Vector2 RenderPosition => new Vector2((int)Position.X, (int)Position.Y) +
                                         (Track == null ? Vector2.Zero : Track.Position);

        public void Update(ISourceParticleTextureEnvironment environment,
            ISourceEngineContext engine)
        {
            Advance(environment, Type.UseActualDeltaTime ? engine.RawDeltaTime : engine.DeltaTime);
        }

        public void Advance(ISourceParticleTextureEnvironment environment,
            float dt)
        {
            var percent = Life / StartLife;
            Life -= dt;
            if (Life <= 0)
            {
                Active = false;
                return;
            }

            if (Type.RotationMode == ParticleTypePresentation.RotationModes.SameAsDirection)
            {
                if (Speed != Vector2.Zero) Rotation = (float)Math.Atan2(Speed.Y, Speed.X);
            }
            else
            {
                Rotation += Spin * dt;
            }

            var fade = Type.FadeMode == ParticleTypePresentation.FadeModes.Linear
                ? percent
                :
                Type.FadeMode == ParticleTypePresentation.FadeModes.Late
                    ?
                    environment.ExtremaArithmetic.Min(1f, percent / .25f)
                    :
                    Type.FadeMode != ParticleTypePresentation.FadeModes.InAndOut
                        ? 1
                        :
                        percent > .75f
                            ? 1 - (percent - .75f) / .25f
                            :
                            percent < .25f
                                ? percent / .25f
                                : 1;
            if (fade == 0)
            {
                Color = PackedColor.Transparent;
            }
            else
            {
                switch (Type.ColorMode)
                {
                    case ParticleTypePresentation.ColorModes.Static:
                    case ParticleTypePresentation.ColorModes.Choose: Color = StartColor; break;
                    case ParticleTypePresentation.ColorModes.Fade:
                        Color = SourceColorInterpolation.Lerp(Type.Color2,
                            StartColor, percent, environment.ScalarArithmetic); break;
                    case ParticleTypePresentation.ColorModes.Blink:
                        Color = Life % .2f > .1f ? StartColor : Type.Color2; break;
                }

                if (fade < 1) Color = Color * fade;
            }

            Position += Speed * dt;
            Speed += Type.Acceleration * dt;
            Speed = environment.VectorArithmetic.Approach(Speed, Vector2.Zero, Type.Friction * dt);

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Type.SpeedMultiplier != 1) Speed *= (float)Math.Pow(Type.SpeedMultiplier, dt);
            if (Type.ScaleOut) Size = StartSize * environment.EasingArithmetic.CubeOut(percent);
        }

        // TargetElapsedTime.Milliseconds intentionally discards whole seconds, as the original does.
        public bool SimulateFor(
            ISourceParticleTextureEnvironment environment, float duration,
            float timeRate, TimeSpan targetElapsedTime)
        {
            if (duration > Life)
            {
                Life = 0;
                Active = false;
                return false;
            }

            var dt = timeRate * (targetElapsedTime.Milliseconds / 1000f);
            if (dt > 0)
                for (float at = 0; at < duration; at += dt)
                    Advance(environment, dt);
            return true;
        }

        public void Render(ISourceRenderContext context, object entity)
        {
            var position = new Vector2((int)Position.X, (int)Position.Y);
            if (Track != null) position += Track.Position;
            ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                Source.ReadTextureForSpriteBatch(), position, Source.ClipRect, Color.PackedValue,
                Rotation, Source.Center, Size,
                SourceSpriteEffects.None, 0f);
        }

        public void Render(ISourceRenderContext context, object entity, float alpha)
        {
            var position = new Vector2((int)Position.X, (int)Position.Y);
            if (Track != null) position += Track.Position;
            ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                Source.ReadTextureForSpriteBatch(), position, Source.ClipRect, (Color * alpha).PackedValue,
                Rotation, Source.Center, Size,
                SourceSpriteEffects.None, 0f);
        }
    }
}
