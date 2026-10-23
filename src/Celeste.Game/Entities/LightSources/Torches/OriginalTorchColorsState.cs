using Celeste.Core.Display;
using Celeste.Graphics.Display;

namespace Celeste.Game.Entities.LightSources.Torches
{
    public sealed class OriginalTorchColorsState : IOriginalTorchColors
    {
        public readonly PackedColor Color = PackedColor.Lerp(PackedColor.White, PackedColor.Cyan, 0.5f);
        public readonly PackedColor StartLitColor = PackedColor.Lerp(PackedColor.White, PackedColor.Orange, 0.5f);
        PackedColor IOriginalTorchColors.Color => Color;
        PackedColor IOriginalTorchColors.StartLitColor => StartLitColor;
    }
}
