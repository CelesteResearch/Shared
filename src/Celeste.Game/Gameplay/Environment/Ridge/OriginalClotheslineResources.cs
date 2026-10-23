using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Game.Gameplay.Environment.Ridge;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public sealed class OriginalClotheslineResources : IOriginalRidgeClothResources
    {
        public readonly PackedColor[] colors;
        public readonly PackedColor lineColor;
        public readonly PackedColor pinColor;
        PackedColor[] IOriginalRidgeClothResources.Colors => colors;
        PackedColor IOriginalRidgeClothResources.LineColor => lineColor;
        PackedColor IOriginalRidgeClothResources.PinColor => pinColor;

        public OriginalClotheslineResources(ISourceScalarArithmetic arithmetic)
        {
            colors = new PackedColor[4]
            {
                SourceHexColor.HexToColor("0d2e6b"),
                SourceHexColor.HexToColor("3d2688"),
                SourceHexColor.HexToColor("4f6e9d"),
                SourceHexColor.HexToColor("47194a")
            };

            lineColor = SourceColorInterpolation.Lerp(PackedColor.Gray, PackedColor.DarkBlue, 0.25f, arithmetic);

            pinColor = PackedColor.Gray;
        }
    }
}
