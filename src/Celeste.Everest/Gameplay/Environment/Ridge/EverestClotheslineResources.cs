using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Game.Gameplay.Environment.Ridge;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Everest.Gameplay.Environment.Ridge
{
    public sealed class EverestClotheslineResources : IOriginalRidgeClothResources
    {
        public PackedColor[] colors;
        public PackedColor lineColor;
        public PackedColor pinColor;
        PackedColor[] IOriginalRidgeClothResources.Colors => colors;
        PackedColor IOriginalRidgeClothResources.LineColor => lineColor;
        PackedColor IOriginalRidgeClothResources.PinColor => pinColor;

        public EverestClotheslineResources(ISourceScalarArithmetic arithmetic)
        {
            colors =
            [
                SourceHexColor.HexToColor("0d2e6b"),
                SourceHexColor.HexToColor("3d2688"),
                SourceHexColor.HexToColor("4f6e9d"),
                SourceHexColor.HexToColor("47194a"),
            ];

            lineColor = SourceColorInterpolation.Lerp(PackedColor.Gray, PackedColor.DarkBlue, 0.25f, arithmetic);

            pinColor = PackedColor.Gray;
        }
    }
}
