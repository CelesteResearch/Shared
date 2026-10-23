namespace Celeste.Core.Rendering
{
    public readonly struct SourceRenderBlendState(
        SourceBlendFactor colorSource,
        SourceBlendFactor colorDestination,
        SourceBlendFunction colorFunction,
        SourceBlendFactor alphaSource,
        SourceBlendFactor alphaDestination,
        SourceBlendFunction alphaFunction)
    {
        public readonly SourceBlendFactor ColorSource = colorSource, ColorDestination = colorDestination;
        public readonly SourceBlendFunction ColorFunction = colorFunction;
        public readonly SourceBlendFactor AlphaSource = alphaSource, AlphaDestination = alphaDestination;
        public readonly SourceBlendFunction AlphaFunction = alphaFunction;
    }
}
