using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Effects.Blur
{
    public static class GaussianBlurPresentation
    {
        private static string[] techniques = { "GaussianBlur3", "GaussianBlur5", "GaussianBlur9" };

        public static SourceTexture2DResource Blur(ISourceGaussianBlurEnvironment environment,
            SourceTexture2DResource texture, VirtualRenderTarget temp, VirtualRenderTarget output,
            float fade = 0f, bool clear = true, GaussianBlurSamples samples = GaussianBlurSamples.Nine,
            float sampleScale = 1f, GaussianBlurDirection direction = GaussianBlurDirection.Both, float alpha = 1f)
        {
            var effect = environment.FxGaussianBlur;
            string name = techniques[(int)samples];
            if (effect != null)
            {
                effect.CurrentTechnique = effect.Techniques[name];
                effect.Parameters["fade"].SetValue(fade);
                effect.Parameters["pixel"].SetValue(new Vector2(1f / temp.Width, 0f) * sampleScale);
                environment.GraphicsDevice.SetRenderTarget((SourceRenderTarget2DResource)temp.Target);
                if (clear) environment.GraphicsDevice.Clear(PackedColor.Transparent);
                environment.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                    SourceSamplerState.PointClamp, SourceDepthStencilState.Default, SourceRasterizerState.CullNone,
                    direction != GaussianBlurDirection.Vertical ? effect : null);
                environment.Draw.SpriteBatch.Draw(texture, new IntRect(0, 0, temp.Width, temp.Height),
                    PackedColor.White.PackedValue);
                environment.Draw.SpriteBatch.End();
                effect.Parameters["pixel"].SetValue(new Vector2(0f, 1f / output.Height) * sampleScale);
                environment.GraphicsDevice.SetRenderTarget((SourceRenderTarget2DResource)output.Target);
                if (clear) environment.GraphicsDevice.Clear(PackedColor.Transparent);
                environment.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                    SourceSamplerState.PointClamp, SourceDepthStencilState.Default, SourceRasterizerState.CullNone,
                    direction != GaussianBlurDirection.Horizontal ? effect : null);
                environment.Draw.SpriteBatch.Draw((SourceTexture2DResource)temp.Target,
                    new IntRect(0, 0, output.Width, output.Height), PackedColor.White.PackedValue);
                environment.Draw.SpriteBatch.End();
                return (SourceTexture2DResource)output.Target;
            }

            return texture;
        }
    }
}
