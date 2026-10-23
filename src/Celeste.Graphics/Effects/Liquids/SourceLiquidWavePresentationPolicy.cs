namespace Celeste.Graphics.Effects.Liquids
{
    public sealed class SourceLiquidWavePresentationPolicy : ILiquidWavePresentationPolicy
    {
        public static SourceLiquidWavePresentationPolicy Shared { get; } = new();
        public bool SuppressWaves => false;
    }
}
