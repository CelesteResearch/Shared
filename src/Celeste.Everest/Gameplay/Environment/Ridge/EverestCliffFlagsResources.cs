using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Game.Gameplay.Environment.Ridge;

namespace Celeste.Everest.Gameplay.Environment.Ridge
{
    public sealed class EverestCliffFlagsResources : IOriginalRidgeClothResources
    {
        public PackedColor[] colors;
        public PackedColor lineColor;
        public PackedColor pinColor;
        PackedColor[] IOriginalRidgeClothResources.Colors => colors;
        PackedColor IOriginalRidgeClothResources.LineColor => lineColor;
        PackedColor IOriginalRidgeClothResources.PinColor => pinColor;

        public EverestCliffFlagsResources(ISourceScalarArithmetic arithmetic)
        {
            colors = new PackedColor[4]
            {
                SourceHexColor.HexToColor("d85f2f"),
                SourceHexColor.HexToColor("d82f63"),
                SourceHexColor.HexToColor("2fd8a2"),
                SourceHexColor.HexToColor("d8d62f")
            };

            lineColor = SourceColorInterpolation.Lerp(PackedColor.Gray, PackedColor.DarkBlue, 0.25f, arithmetic);

            pinColor = PackedColor.Gray;
        }
    }
}
