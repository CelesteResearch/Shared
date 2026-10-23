using System.IO;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Game.Execution.Graphics
{
    public sealed partial class OriginalGameGraphicsResources
    {
        public SourceEffect FxMountain;
        public SourceEffect FxGaussianBlur;
        public SourceEffect FxDistort;
        public SourceEffect FxDust;
        public SourceEffect FxPrimitive;
        public SourceEffect FxDither;
        public SourceEffect FxMagicGlow;
        public SourceEffect FxMirrors;
        public SourceEffect FxColorGrading;
        public SourceEffect FxGlitch;
        public SourceEffect FxTexture;
        public SourceEffect FxLighting;
        public SourceBasicEffect FxDebug;

        public readonly SourceBlendState Subtract = new SourceBlendState
        {
            ColorSourceBlend = SourceBlendFactor.One,
            ColorDestinationBlend = SourceBlendFactor.One,
            ColorBlendFunction = SourceBlendFunction.ReverseSubtract,
            AlphaSourceBlend = SourceBlendFactor.One,
            AlphaDestinationBlend = SourceBlendFactor.One,
            AlphaBlendFunction = SourceBlendFunction.Add
        };

        public readonly SourceBlendState DestinationTransparencySubtract = new SourceBlendState
        {
            ColorSourceBlend = SourceBlendFactor.One,
            ColorDestinationBlend = SourceBlendFactor.One,
            ColorBlendFunction = SourceBlendFunction.ReverseSubtract,
            AlphaSourceBlend = SourceBlendFactor.Zero,
            AlphaDestinationBlend = SourceBlendFactor.One,
            AlphaBlendFunction = SourceBlendFunction.Add
        };

        public void LoadEffects(SourceContentManager content, SourceGraphicsDevice device,
            SourceStockEffectResources stockEffects)
        {
            FxMountain = LoadFx(content, "MountainRender");
            FxGaussianBlur = LoadFx(content, "GaussianBlur");
            FxDistort = LoadFx(content, "Distort");
            FxDust = LoadFx(content, "Dust");
            FxPrimitive = LoadFx(content, "Primitive");
            FxDither = LoadFx(content, "Dither");
            FxMagicGlow = LoadFx(content, "MagicGlow");
            FxMirrors = LoadFx(content, "Mirrors");
            FxColorGrading = LoadFx(content, "ColorGrade");
            FxGlitch = LoadFx(content, "Glitch");
            FxTexture = LoadFx(content, "Texture");
            FxLighting = LoadFx(content, "Lighting");
            FxDebug = new SourceBasicEffect(device, stockEffects);
        }

        public SourceEffect LoadFx(SourceContentManager content, string name)
            => content.Load<SourceEffect>(Path.Combine("Effects", name));
    }
}
