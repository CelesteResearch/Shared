using Celeste.Core.Rendering.States;

namespace Celeste.Game.Presentation.Effects.Bloom
{
    public interface IOriginalBloomBlendStates
    {
        SourceBlendState BlurredScreenToMask { get; }
        SourceBlendState AdditiveMaskToScreen { get; }
        SourceBlendState CutoutBlendstate { get; }
    }
}
