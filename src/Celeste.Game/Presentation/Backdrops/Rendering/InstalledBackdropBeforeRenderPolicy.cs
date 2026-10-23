using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using System;
using System.Numerics;
using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Presentation.Backdrops.Rendering
{
    public sealed class InstalledBackdropBeforeRenderPolicy : ISourceBackdropBeforeRenderPolicy
    {
        public bool ShouldBeforeRender(BackdropPresentation backdrop) => backdrop.Visible;

        public void Render(BackdropRendererPresentation renderer, ISourceRenderContext context,
            ISourceBackdropScene scene)
            => renderer.RenderInstalled(context, scene);

        public void RenderParallax(ParallaxBackdropPresentation backdrop, ISourceRenderContext context,
            ISourceBackdropScene scene)
        {
            if (((ISourceAtlasPacking)backdrop.Texture).IsPacked ||
                ((ISourceDrawScope)scene.EngineContext).Draw.SpriteBatch.CurrentSamplerState !=
                SourceSamplerState.PointWrap)
            {
                backdrop.RenderOriginal(context, scene);
                return;
            }

            Vector2 camera = Vector2Geometry.Floor(scene.Camera.Position + backdrop.CameraOffset);
            Vector2 position = Vector2Geometry.Floor(backdrop.Position - camera * backdrop.Scroll);
            float amount = backdrop.FadeIn * backdrop.Alpha * backdrop.FadeAlphaMultiplier;
            if (backdrop.FadeX != null) amount *= backdrop.FadeX.Value(camera.X + 160f);
            if (backdrop.FadeY != null) amount *= backdrop.FadeY.Value(camera.Y + 90f);
            PackedColor color = backdrop.Color;
            if (amount < 1f) color *= amount;
            if (color.A > 1)
            {
                if (backdrop.LoopX)
                    position.X =
                        (position.X % (float)backdrop.Texture.FrameWidth - (float)backdrop.Texture.FrameWidth) %
                        (float)backdrop.Texture.FrameWidth;
                if (backdrop.LoopY)
                    position.Y =
                        (position.Y % (float)backdrop.Texture.FrameHeight - (float)backdrop.Texture.FrameHeight) %
                        (float)backdrop.Texture.FrameHeight;
                SourceSpriteEffects effects = SourceSpriteEffects.None;
                if (backdrop.FlipX) effects |= SourceSpriteEffects.FlipHorizontally;
                if (backdrop.FlipY) effects |= SourceSpriteEffects.FlipVertically;
                int width = backdrop.LoopX ? (int)Math.Ceiling(320f - position.X) : backdrop.Texture.FrameWidth;
                int height = backdrop.LoopY ? (int)Math.Ceiling(180f - position.Y) : backdrop.Texture.FrameHeight;
                IntRect source = new IntRect(backdrop.FlipX ? -width : 0, backdrop.FlipY ? -height : 0, width, height);
                float scaleFix = ((ISourceAtlasPacking)backdrop.Texture).ScaleFix;
                ((ISourceDrawScope)scene.EngineContext).Draw.SpriteBatch.Draw(
                    backdrop.Texture.Texture.TextureSafe, position, source, color.PackedValue,
                    0f, -backdrop.Texture.DrawOffset / scaleFix, scaleFix, effects, 0f);
            }
        }
    }
}
