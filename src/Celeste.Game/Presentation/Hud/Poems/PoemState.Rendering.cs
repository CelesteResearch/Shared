using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Game.Presentation.Effects.MagicGlow;
using Celeste.Game.Execution.Graphics;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Display;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Presentation.Hud.Poems
{
    public partial class PoemState
    {
        public void BeforeRender()
        {
            if (!disposed)
            {
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(poem.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
                Matrix4x4 transform = SourceMatrixMath.CreateScale((float)poem.Width / 1920f);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, null, null, transform);
                ISourceRenderContext context = ((ISourceRenderEnvironment)engine).CurrentContext;
                Heart.Position = Offset + new Vector2(1920f, 1080f) * .5f;
                Heart.Scale = Vector2.One * (1f + Shake * .1f);
                var texture = ((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["snow"];
                for (int i = 0; i < particles.Length; i++)
                {
                    Particle particle = particles[i];
                    float ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.SineIn(particle.Percent);
                    Vector2 position = Heart.Position + particle.Direction * (1f - ease) * 1920f;
                    float x = 1f + ease * 2f;
                    float y = .25f * (.25f + (1f - ease) * .75f);
                    float alpha = 1f - ease;
                    SourceAtlasDrawing.DrawCentered(context, this, texture, position, Color * alpha,
                        new Vector2(x, y), Vector2Geometry.Angle(-particle.Direction));
                }

                Heart.Position += new Vector2(
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -1f, 1f),
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -1f, 1f)) * 16f * Shake;
                Heart.Render(context);
                if (!string.IsNullOrEmpty(text))
                {
                    DrawPoem(context, Offset + new Vector2(-2f, 0f), PackedColor.Black * TextAlpha);
                    DrawPoem(context, Offset + new Vector2(2f, 0f), PackedColor.Black * TextAlpha);
                    DrawPoem(context, Offset + new Vector2(0f, -2f), PackedColor.Black * TextAlpha);
                    DrawPoem(context, Offset + new Vector2(0f, 2f), PackedColor.Black * TextAlpha);
                    DrawPoem(context, Offset + Vector2.Zero, Color * TextAlpha);
                }

                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(smoke.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
                MagicGlowPresentation.Render((ISourceMagicGlowEnvironment)engine, poem.Target,
                    timer, -1f, SourceMatrixMath.CreateScale(.5f));
                GaussianBlurPresentation.Blur((ISourceGaussianBlurEnvironment)engine, smoke.Target, temp, smoke);
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!disposed && !((ISourceScene)Scene).SourceScene.Paused)
            {
                float scale = 1920f / poem.Width;
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(smoke.Target, Vector2.Zero,
                    smoke.Bounds, (PackedColor.White * .3f * Alpha).PackedValue, 0f, Vector2.Zero,
                    scale * 2f, SourceSpriteEffects.None, 0f);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(poem.Target, Vector2.Zero,
                    poem.Bounds, (PackedColor.White * Alpha).PackedValue, 0f, Vector2.Zero,
                    scale, SourceSpriteEffects.None, 0f);
            }
        }
    }
}
