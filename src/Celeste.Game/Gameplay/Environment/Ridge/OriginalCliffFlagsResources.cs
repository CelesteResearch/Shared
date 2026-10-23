using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public sealed class OriginalCliffFlagsResources : IOriginalRidgeClothResources
    {
        public readonly PackedColor[] colors;
        public readonly PackedColor lineColor;
        public readonly PackedColor pinColor;
        PackedColor[] IOriginalRidgeClothResources.Colors => colors;
        PackedColor IOriginalRidgeClothResources.LineColor => lineColor;
        PackedColor IOriginalRidgeClothResources.PinColor => pinColor;

        public OriginalCliffFlagsResources(ISourceScalarArithmetic arithmetic)
        {
            colors =
            [
                SourceHexColor.HexToColor("d85f2f"),
                SourceHexColor.HexToColor("d82f63"),
                SourceHexColor.HexToColor("2fd8a2"),
                SourceHexColor.HexToColor("d8d62f"),
            ];

            lineColor = SourceColorInterpolation.Lerp(PackedColor.Gray, PackedColor.DarkBlue, 0.25f, arithmetic);

            pinColor = PackedColor.Gray;
        }
    }
}
