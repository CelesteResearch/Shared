using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Presentation.Environment
{
    public class HiresSnowState : SceneRenderer
    {
        private struct Particle
        {
            public float Scale;
            public Vector2 Position;
            public float Speed, Sin, Rotation;
            public PackedColor Color;

            public void Reset(Vector2 direction, HiresSnowState owner)
            {
                float amount = SourceRandomMath.NextFloat(owner.Random);
                amount *= amount * amount * amount;
                Scale = ScalarMath.Map(amount, 0f, 1f, .05f, .8f);
                Speed = Scale * SourceRandomMath.Range(owner.Random, 2500, 5000);
                if (direction.X < 0f)
                    Position = new Vector2(owner.Graphics.Width + 128,
                        SourceRandomMath.NextFloat(owner.Random, owner.Graphics.Height));
                else if (direction.X > 0f)
                    Position = new Vector2(-128f, SourceRandomMath.NextFloat(owner.Random, owner.Graphics.Height));
                else if (direction.Y > 0f)
                    Position = new Vector2(SourceRandomMath.NextFloat(owner.Random, owner.Graphics.Width), -128f);
                else if (direction.Y < 0f)
                    Position = new Vector2(SourceRandomMath.NextFloat(owner.Random, owner.Graphics.Width),
                        owner.Graphics.Height + 128);
                Sin = SourceRandomMath.NextFloat(owner.Random, (float)Math.PI * 2f);
                Rotation = SourceRandomMath.NextFloat(owner.Random, (float)Math.PI * 2f);
                Color = SourceColorInterpolation.Lerp(PackedColor.White, PackedColor.Transparent, amount * .8f,
                    ((ISourceScalarEnvironment)owner.engine).ScalarArithmetic);
            }
        }

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private IOriginalEngineGraphicsState Graphics => ((IOriginalEngineGraphicsEnvironment)engine).EngineGraphics;
        public float Alpha = 1f;
        public float ParticleAlpha = 1f;
        public Vector2 Direction = new(-1f, 0f);
        public ScreenWipePresentation AttachAlphaTo;
        private Particle[] particles;
        private AtlasEntry overlay, snow;
        private float timer, overlayAlpha;

        protected AtlasEntry ParticleTexture
        {
            get => snow;
            set => snow = value;
        }

        protected AtlasEntry OverlayTexture
        {
            get => overlay;
            set => overlay = value;
        }

        protected float Timer
        {
            get => timer;
            set => timer = value;
        }

        public float OverlayAlpha
        {
            get => overlayAlpha;
            set => overlayAlpha = value;
        }

        public HiresSnowState(ISourceEngineContext engine, float overlayAlpha = .45f)
        {
            this.engine = engine;
            this.overlayAlpha = overlayAlpha;
            overlay = ((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas.Entries["overlay"];
            snow = ((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas.Entries["snow"]
                .GetSubtexture(1, 1, 254, 254);
            particles = new Particle[50];
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Reset(Direction, this);
                particles[i].Position.X = SourceRandomMath.NextFloat(Random, Graphics.Width);
                particles[i].Position.Y = SourceRandomMath.NextFloat(Random, Graphics.Height);
            }
        }

        public override void Update(object scene)
        {
            base.Update(scene);
            if (AttachAlphaTo != null) Alpha = AttachAlphaTo.Percent;
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Position += Direction * particles[i].Speed * engine.DeltaTime;
                particles[i].Position.Y += (float)Math.Sin(particles[i].Sin) * 100f * engine.DeltaTime;
                particles[i].Sin += engine.DeltaTime;
                if (particles[i].Position.X < -128f || particles[i].Position.X > (float)(Graphics.Width + 128) ||
                    particles[i].Position.Y < -128f || particles[i].Position.Y > (float)(Graphics.Height + 128))
                    particles[i].Reset(Direction, this);
            }

            timer += engine.DeltaTime;
        }

        public override void Render(object scene)
        {
            float speed = ScalarMath.Clamp(Direction.Length(), 0f, 20f);
            float angle = 0f;
            Vector2 scale = Vector2.One;
            bool stretched = speed > 1f;
            if (stretched)
            {
                angle = (float)Math.Atan2(Direction.Y, Direction.X);
                scale = new Vector2(speed, .2f + (1f - speed / 20f) * .8f);
            }

            var context = ((ISourceRenderEnvironment)engine).CurrentContext;
            var batch = new SourceRenderBatchState(SourceSpriteSortMode.Deferred, SourceBlendState.Additive,
                SourceSamplerState.LinearWrap, SourceDepthStencilState.None, SourceRasterizerState.CullCounterClockwise,
                null, Graphics.ScreenMatrix);
            context.BeginBatch(in batch);
            float alpha = Alpha * ParticleAlpha;
            for (int i = 0; i < particles.Length; i++)
            {
                PackedColor color = particles[i].Color;
                float rotation = particles[i].Rotation;
                if (alpha < 1f) color *= alpha;
                SourceAtlasDrawing.DrawCentered(context, this, snow, particles[i].Position, color,
                    scale * particles[i].Scale, stretched ? angle : rotation);
            }

            float x = timer * 32f % overlay.FrameWidth;
            float y = timer * 20f % overlay.FrameHeight;
            var draw = new AtlasTextureDraw(overlay, new Celeste.Core.Geometry.IntRect(-(int)x, -(int)y, 1920, 1080),
                Vector2.Zero, Vector2.Zero, (PackedColor.White * (Alpha * overlayAlpha)), Vector2.One);
            ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
            context.EndBatch();
        }
    }
}
