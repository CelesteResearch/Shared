using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;

namespace Celeste.Game.Presentation.Effects.Bloom
{
    public sealed class OriginalBloomBlendStates : IOriginalBloomBlendStates
    {
        public readonly SourceBlendState BlurredScreenToMask = new()
        {
            ColorSourceBlend = SourceBlendFactor.One,
            ColorDestinationBlend = SourceBlendFactor.Zero,
            ColorBlendFunction = SourceBlendFunction.Add,
            AlphaSourceBlend = SourceBlendFactor.Zero,
            AlphaDestinationBlend = SourceBlendFactor.One,
            AlphaBlendFunction = SourceBlendFunction.Add,
        };

        public readonly SourceBlendState AdditiveMaskToScreen = new()
        {
            ColorSourceBlend = SourceBlendFactor.SourceAlpha,
            ColorDestinationBlend = SourceBlendFactor.One,
            ColorBlendFunction = SourceBlendFunction.Add,
            AlphaSourceBlend = SourceBlendFactor.Zero,
            AlphaDestinationBlend = SourceBlendFactor.One,
            AlphaBlendFunction = SourceBlendFunction.Add,
        };

        public readonly SourceBlendState CutoutBlendstate = new()
        {
            ColorSourceBlend = SourceBlendFactor.One,
            ColorDestinationBlend = SourceBlendFactor.One,
            AlphaSourceBlend = SourceBlendFactor.One,
            AlphaDestinationBlend = SourceBlendFactor.One,
            ColorBlendFunction = SourceBlendFunction.Min,
            AlphaBlendFunction = SourceBlendFunction.Min,
        };

        SourceBlendState IOriginalBloomBlendStates.BlurredScreenToMask => BlurredScreenToMask;
        SourceBlendState IOriginalBloomBlendStates.AdditiveMaskToScreen => AdditiveMaskToScreen;
        SourceBlendState IOriginalBloomBlendStates.CutoutBlendstate => CutoutBlendstate;
    }
}
