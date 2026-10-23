using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Game.Entities.PlaybackBillboard;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Everest.Entities.PlaybackBillboard
{
    public sealed class EverestPlaybackBillboardColors : IPlaybackBillboardColors
    {
        public PackedColor BackgroundColor;

        public EverestPlaybackBillboardColors(ISourceScalarArithmetic arithmetic)
        {
            BackgroundColor =
                SourceColorInterpolation.Lerp(PackedColor.DarkSlateBlue, PackedColor.Black, .6f, arithmetic);
        }

        PackedColor IPlaybackBillboardColors.BackgroundColor => BackgroundColor;
    }
}
