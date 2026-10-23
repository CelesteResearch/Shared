using Celeste.Core.Display;

namespace Celeste.Game.Presentation.Backdrops.Blackhole
{
    public readonly struct BlackholeBackdropPalette
    {
        public PackedColor[] MildColors { get; }
        public PackedColor[] WildColors { get; }
        public PackedColor InnerColor { get; }
        public PackedColor OuterMildColor { get; }
        public PackedColor OuterWildColor { get; }

        public BlackholeBackdropPalette(PackedColor[] mildColors, PackedColor[] wildColors,
            PackedColor innerColor, PackedColor outerMildColor, PackedColor outerWildColor)
        {
            MildColors = mildColors;
            WildColors = wildColors;
            InnerColor = innerColor;
            OuterMildColor = outerMildColor;
            OuterWildColor = outerWildColor;
        }
    }
}
