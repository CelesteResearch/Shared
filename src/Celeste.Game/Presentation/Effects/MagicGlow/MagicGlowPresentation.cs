using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering.States;
using Celeste.Game.Profiles;
using Celeste.Graphics.Effects.MagicGlow;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Presentation.Effects.MagicGlow
{
    public static class MagicGlowPresentation
    {
        public static void Render(ISourceMagicGlowEnvironment environment,
            SourceTexture2DResource texture, float noiseEase, float direction, Matrix4x4 matrix)
        {
            var resources = (ISourceMagicGlowResources)environment.GameGraphics;
            resources.FxMagicGlow.Parameters["alpha"].SetValue(.5f);
            resources.FxMagicGlow.Parameters["pixel"].SetValue(
                new Vector2(1f / texture.Width, 1f / texture.Height) * 3f);
            resources.FxMagicGlow.Parameters["noiseSample"].SetValue(new Vector2(1f, .5f));
            resources.FxMagicGlow.Parameters["noiseDistort"].SetValue(new Vector2(1f, 1f));
            resources.FxMagicGlow.Parameters["noiseEase"].SetValue(noiseEase * .05f);
            resources.FxMagicGlow.Parameters["direction"].SetValue(0f - direction);
            environment.GraphicsDevice.Textures[1] =
                environment.SourceProfile == GameProfile.InstalledEverest
                    ? resources.MagicGlowNoise.TextureSafe
                    : resources.MagicGlowNoise.Texture;
            environment.GraphicsDevice.SamplerStates[1] = SourceSamplerState.LinearWrap;
            environment.Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, null, null, resources.FxMagicGlow, matrix);
            environment.Draw.SpriteBatch.Draw(texture, Vector2.Zero, PackedColor.White.PackedValue);
            environment.Draw.SpriteBatch.End();
        }
    }
}
