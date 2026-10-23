using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Display;

namespace Celeste.Game.Presentation.Effects.Distortion
{
    public static class OriginalDistortionRender
    {
        public static void Render(ISourceEngineContext engine, SourceTexture2DResource source,
            SourceTexture2DResource map, bool hasDistortion)
        {
            var fxDistort = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .FxDistort;
            if (fxDistort != null && (engine.Effects.Anxiety > 0f || engine.Effects.GameRate < 1f || hasDistortion))
            {
                if (engine.Effects.Anxiety > 0f || engine.Effects.GameRate < 1f)
                    fxDistort.CurrentTechnique = fxDistort.Techniques["Distort"];
                else
                    fxDistort.CurrentTechnique = fxDistort.Techniques["Displace"];
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[1] = map;
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(new SourceRenderBatchState(
                    SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp,
                    SourceDepthStencilState.Default, SourceRasterizerState.CullNone, fxDistort, Matrix4x4.Identity));
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(source, Vector2.Zero, PackedColor.White.PackedValue);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            }
            else
            {
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(new SourceRenderBatchState(
                    SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp,
                    SourceDepthStencilState.Default, SourceRasterizerState.CullNone, null, Matrix4x4.Identity));
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(source, Vector2.Zero, PackedColor.White.PackedValue);
                ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            }
        }
    }
}
