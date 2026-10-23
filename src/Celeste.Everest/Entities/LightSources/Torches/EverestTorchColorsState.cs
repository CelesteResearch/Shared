using Celeste.Core.Display;
using Celeste.Game.Entities.LightSources.Torches;

namespace Celeste.Everest.Entities.LightSources.Torches
{
    public sealed class EverestTorchColorsState : IOriginalTorchColors
    {
        public PackedColor Color = PackedColor.Lerp(PackedColor.White, PackedColor.Cyan, 0.5f);
        public PackedColor StartLitColor = PackedColor.Lerp(PackedColor.White, PackedColor.Orange, 0.5f);
        PackedColor IOriginalTorchColors.Color => Color;
        PackedColor IOriginalTorchColors.StartLitColor => StartLitColor;
    }
}
