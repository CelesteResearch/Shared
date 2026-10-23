using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Presentation.Effects.Glitch
{
    public static class OriginalGlitchRender
    {
        public static void Apply(ISourceEngineContext engine, VirtualRenderTarget source,
            float timer, float seed, float amplitude)
        {
            if (engine.Effects.Glitch > 0f &&
                ((IOriginalLevelScreenEffectsProcess)engine).AllowGlitch)
            {
                var fxGlitch = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .FxGlitch;
                var dimensions = new Vector2(
                    ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Viewport.Width,
                    ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Viewport.Height);
                fxGlitch.Parameters["dimensions"].SetValue(dimensions);
                fxGlitch.Parameters["amplitude"].SetValue(amplitude);
                fxGlitch.Parameters["minimum"].SetValue(-1f);
                fxGlitch.Parameters["glitch"].SetValue(engine.Effects.Glitch);
                fxGlitch.Parameters["timer"].SetValue(timer);
                fxGlitch.Parameters["seed"].SetValue(seed);
                var tempA = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .Buffers
                    .TempA;
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(tempA.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(new(
                    SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp,
                    SourceDepthStencilState.Default, SourceRasterizerState.CullNone, fxGlitch, Matrix4x4.Identity));
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(source.Target, Vector2.Zero,
                    PackedColor.White.PackedValue);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(source.Target);
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(new(
                    SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp,
                    SourceDepthStencilState.Default, SourceRasterizerState.CullNone, fxGlitch, Matrix4x4.Identity));
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(tempA.Target, Vector2.Zero,
                    PackedColor.White.PackedValue);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            }
        }
    }
}
