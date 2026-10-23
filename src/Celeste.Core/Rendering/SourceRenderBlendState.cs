namespace Celeste.Core.Rendering
{
    public readonly struct SourceRenderBlendState
    {
        public readonly SourceBlendFactor ColorSource, ColorDestination;
        public readonly SourceBlendFunction ColorFunction;
        public readonly SourceBlendFactor AlphaSource, AlphaDestination;
        public readonly SourceBlendFunction AlphaFunction;

        public SourceRenderBlendState(SourceBlendFactor colorSource, SourceBlendFactor colorDestination,
            SourceBlendFunction colorFunction, SourceBlendFactor alphaSource,
            SourceBlendFactor alphaDestination, SourceBlendFunction alphaFunction)
        {
            ColorSource = colorSource;
            ColorDestination = colorDestination;
            ColorFunction = colorFunction;
            AlphaSource = alphaSource;
            AlphaDestination = alphaDestination;
            AlphaFunction = alphaFunction;
        }
    }
}
