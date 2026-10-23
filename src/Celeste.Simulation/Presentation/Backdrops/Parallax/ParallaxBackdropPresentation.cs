using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Presentation.Backdrops.Parallax
{
    public class ParallaxBackdropPresentation : BackdropPresentation
    {
        public Vector2 CameraOffset;
        public SourceBlendState BlendState = SourceBlendState.AlphaBlend;
        public AtlasEntry Texture;
        public bool DoFadeIn;
        public float Alpha = 1f;
        private float fadeIn = 1f;
        public float FadeIn => fadeIn;

        public ParallaxBackdropPresentation(AtlasEntry texture)
        {
            Name = texture.Name;
            Texture = texture;
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            Position += Speed * scene.EngineContext.Frame.DeltaTime;
            Position += WindMultiplier * scene.Wind * scene.EngineContext.Frame.DeltaTime;
            if (DoFadeIn)
                fadeIn = ScalarMath.Approach(fadeIn, Visible ? 1 : 0, scene.EngineContext.Frame.DeltaTime,
                    ((ISourceExtremaEnvironment)scene.EngineContext).ExtremaArithmetic);
            else fadeIn = Visible ? 1 : 0;
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            ((ISourceBackdropBeforeRenderEnvironment)scene.EngineContext).BackdropBeforeRender.RenderParallax(this,
                context,
                scene);
        }

        public void RenderOriginal(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            var camera = Vector2Geometry.Floor(scene.Camera.Position + CameraOffset);
            var at = Vector2Geometry.Floor(Position - camera * Scroll);
            float amount = fadeIn * Alpha * FadeAlphaMultiplier;
            if (FadeX != null) amount *= FadeX.Value(camera.X + 160f);
            if (FadeY != null) amount *= FadeY.Value(camera.Y + 90f);
            PackedColor color = Color;
            if (amount < 1f) color *= amount;
            if (color.A <= 1) return;
            if (LoopX)
            {
                while (at.X < 0f) at.X += Texture.FrameWidth;
                while (at.X > 0f) at.X -= Texture.FrameWidth;
            }

            if (LoopY)
            {
                while (at.Y < 0f) at.Y += Texture.FrameHeight;
                while (at.Y > 0f) at.Y -= Texture.FrameHeight;
            }

            bool flipX = false, flipY = false;
            if (FlipX && FlipY)
            {
                flipX = true;
                flipY = true;
            }
            else if (FlipX) flipX = true;
            else if (FlipY) flipY = true;

            for (float x = at.X; x < 320f; x += Texture.FrameWidth)
            {
                for (float y = at.Y; y < 180f; y += Texture.FrameHeight)
                {
                    var draw = new AtlasTextureDraw(Texture, new Vector2(x, y), Vector2.Zero,
                        color, Vector2.One, 0f, flipX, flipY);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, null);
                    if (!LoopY) break;
                }

                if (!LoopX) break;
            }
        }
    }
}
