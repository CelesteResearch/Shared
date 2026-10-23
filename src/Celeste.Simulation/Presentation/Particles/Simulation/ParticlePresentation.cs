using Celeste.Core.Display;
using System;
using Celeste.Core.Rendering.States;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Particles.Simulation
{
    public struct ParticlePresentation
    {
        public global::Celeste.Graphics.Particles.Tracking.IParticleTrack Track;
        public global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation Type;
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Source;
        public bool Active;
        public global::Celeste.Core.Display.PackedColor Color, StartColor;
        public Vector2 Position, Speed;
        public float Size, StartSize, Life, StartLife, ColorSwitch, Rotation, Spin;

        public Vector2 RenderPosition => new Vector2((int)Position.X, (int)Position.Y) +
                                         (Track == null ? Vector2.Zero : Track.Position);

        public void Update(global::Celeste.Graphics.Particles.Sources.ISourceParticleTextureEnvironment environment,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            Advance(environment, Type.UseActualDeltaTime ? engine.RawDeltaTime : engine.DeltaTime);
        }

        public void Advance(global::Celeste.Graphics.Particles.Sources.ISourceParticleTextureEnvironment environment,
            float dt)
        {
            float percent = Life / StartLife;
            Life -= dt;
            if (Life <= 0)
            {
                Active = false;
                return;
            }

            if (Type.RotationMode == global::Celeste.Simulation.Presentation.Particles.Definitions
                    .ParticleTypePresentation.RotationModes.SameAsDirection)
            {
                if (Speed != Vector2.Zero) Rotation = (float)Math.Atan2(Speed.Y, Speed.X);
            }
            else Rotation += Spin * dt;

            float fade = Type.FadeMode == global::Celeste.Simulation.Presentation.Particles.Definitions
                    .ParticleTypePresentation.FadeModes.Linear ? percent :
                Type.FadeMode == global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
                    .FadeModes.Late ? environment.ExtremaArithmetic.Min(1f, percent / .25f) :
                Type.FadeMode != global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
                    .FadeModes.InAndOut ? 1 :
                percent > .75f ? 1 - (percent - .75f) / .25f :
                percent < .25f ? percent / .25f : 1;
            if (fade == 0) Color = global::Celeste.Core.Display.PackedColor.Transparent;
            else
            {
                switch (Type.ColorMode)
                {
                    case global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
                        .ColorModes.Static:
                    case global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
                        .ColorModes.Choose: Color = StartColor; break;
                    case global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
                        .ColorModes.Fade:
                        Color = global::Celeste.Graphics.Display.Colors.SourceColorInterpolation.Lerp(Type.Color2,
                            StartColor, percent, environment.ScalarArithmetic); break;
                    case global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
                        .ColorModes.Blink:
                        Color = Life % .2f > .1f ? StartColor : Type.Color2; break;
                }

                if (fade < 1) Color = Color * fade;
            }

            Position += Speed * dt;
            Speed += Type.Acceleration * dt;
            Speed = environment.VectorArithmetic.Approach(Speed, Vector2.Zero, Type.Friction * dt);

            if (Type.SpeedMultiplier != 1) Speed *= (float)Math.Pow(Type.SpeedMultiplier, dt);
            if (Type.ScaleOut)
            {
                Size = StartSize * environment.EasingArithmetic.CubeOut(percent);
            }
        }

        // TargetElapsedTime.Milliseconds intentionally discards whole seconds, as the original does.
        public bool SimulateFor(
            global::Celeste.Graphics.Particles.Sources.ISourceParticleTextureEnvironment environment, float duration,
            float timeRate, TimeSpan targetElapsedTime)
        {
            if (duration > Life)
            {
                Life = 0;
                Active = false;
                return false;
            }

            float dt = timeRate * (targetElapsedTime.Milliseconds / 1000f);
            if (dt > 0)
                for (float at = 0; at < duration; at += dt)
                    Advance(environment, dt);
            return true;
        }

        public void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, object entity)
        {
            Vector2 position = new Vector2((int)Position.X, (int)Position.Y);
            if (Track != null) position += Track.Position;
            ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                Source.ReadTextureForSpriteBatch(), position, Source.ClipRect, Color.PackedValue,
                Rotation, Source.Center, Size,
                SourceSpriteEffects.None, 0f);
        }

        public void Render(global::Celeste.Core.Rendering.ISourceRenderContext context, object entity, float alpha)
        {
            Vector2 position = new Vector2((int)Position.X, (int)Position.Y);
            if (Track != null) position += Track.Position;
            ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)context).Draw.SpriteBatch.Draw(
                Source.ReadTextureForSpriteBatch(), position, Source.ClipRect, (Color * alpha).PackedValue,
                Rotation, Source.Center, Size,
                SourceSpriteEffects.None, 0f);
        }
    }
}
