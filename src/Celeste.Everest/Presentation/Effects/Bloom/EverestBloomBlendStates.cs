using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Game.Presentation.Effects.Bloom;

namespace Celeste.Everest.Presentation.Effects.Bloom
{
    public sealed class EverestBloomBlendStates : IOriginalBloomBlendStates
    {
        public SourceBlendState BlurredScreenToMask = new SourceBlendState
        {
            ColorSourceBlend = SourceBlendFactor.One,
            ColorDestinationBlend = SourceBlendFactor.Zero,
            ColorBlendFunction = SourceBlendFunction.Add,
            AlphaSourceBlend = SourceBlendFactor.Zero,
            AlphaDestinationBlend = SourceBlendFactor.One,
            AlphaBlendFunction = SourceBlendFunction.Add
        };

        public SourceBlendState AdditiveMaskToScreen = new SourceBlendState
        {
            ColorSourceBlend = SourceBlendFactor.SourceAlpha,
            ColorDestinationBlend = SourceBlendFactor.One,
            ColorBlendFunction = SourceBlendFunction.Add,
            AlphaSourceBlend = SourceBlendFactor.Zero,
            AlphaDestinationBlend = SourceBlendFactor.One,
            AlphaBlendFunction = SourceBlendFunction.Add
        };

        public SourceBlendState CutoutBlendstate = new SourceBlendState
        {
            ColorSourceBlend = SourceBlendFactor.One,
            ColorDestinationBlend = SourceBlendFactor.One,
            AlphaSourceBlend = SourceBlendFactor.One,
            AlphaDestinationBlend = SourceBlendFactor.One,
            ColorBlendFunction = SourceBlendFunction.Min,
            AlphaBlendFunction = SourceBlendFunction.Min
        };

        SourceBlendState IOriginalBloomBlendStates.BlurredScreenToMask => BlurredScreenToMask;
        SourceBlendState IOriginalBloomBlendStates.AdditiveMaskToScreen => AdditiveMaskToScreen;
        SourceBlendState IOriginalBloomBlendStates.CutoutBlendstate => CutoutBlendstate;
    }
}
