using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Effects.MagicGlow
{
    public interface ISourceMagicGlowResources
    {
        SourceEffect FxMagicGlow { get; }
        VirtualTexture MagicGlowNoise { get; }
    }
}
