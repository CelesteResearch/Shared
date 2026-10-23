using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;

namespace Celeste.Game.Presentation.Lighting
{
    public sealed class LightingRendererProcessState
    {
        public SourceBlendState GradientBlendState = new()
        {
            AlphaBlendFunction = SourceBlendFunction.Max,
            ColorBlendFunction = SourceBlendFunction.Max,
            ColorSourceBlend = SourceBlendFactor.One,
            ColorDestinationBlend = SourceBlendFactor.One,
            AlphaSourceBlend = SourceBlendFactor.One,
            AlphaDestinationBlend = SourceBlendFactor.One,
        };

        public SourceBlendState OccludeBlendState = new()
        {
            AlphaBlendFunction = SourceBlendFunction.Min,
            ColorBlendFunction = SourceBlendFunction.Min,
            ColorSourceBlend = SourceBlendFactor.One,
            ColorDestinationBlend = SourceBlendFactor.One,
            AlphaSourceBlend = SourceBlendFactor.One,
            AlphaDestinationBlend = SourceBlendFactor.One,
        };
    }
}
