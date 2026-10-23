using Celeste.Graphics.Effects.MagicGlow;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Game.Execution.Graphics
{
    public sealed partial class OriginalGameGraphicsResources : ISourceMagicGlowResources
    {
        SourceEffect ISourceMagicGlowResources.FxMagicGlow => FxMagicGlow;
    }
}
