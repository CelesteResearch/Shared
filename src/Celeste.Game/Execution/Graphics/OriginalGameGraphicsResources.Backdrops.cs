using Celeste.Graphics.Content;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Game.Execution.Graphics
{
    public sealed partial class OriginalGameGraphicsResources : ISourceMiscAtlasResources,
        ISourceBackdropEffectResources, ISourceGameplayBlurBufferResources
    {
        SourceEffect ISourceBackdropEffectResources.FxTexture => FxTexture;
        SourceEffect ISourceBackdropEffectResources.FxGaussianBlur => FxGaussianBlur;
        VirtualRenderTarget ISourceGameplayBlurBufferResources.TempA => Buffers.TempA;
    }
}
