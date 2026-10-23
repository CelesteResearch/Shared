using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Game.Entities.PlaybackBillboard;

namespace Celeste.Game.Entities.PlaybackBillboard
{
    public sealed class OriginalPlaybackBillboardColors : IPlaybackBillboardColors
    {
        public readonly PackedColor BackgroundColor;

        public OriginalPlaybackBillboardColors(ISourceScalarArithmetic arithmetic)
        {
            BackgroundColor =
                SourceColorInterpolation.Lerp(PackedColor.DarkSlateBlue, PackedColor.Black, .6f, arithmetic);
        }

        PackedColor IPlaybackBillboardColors.BackgroundColor => BackgroundColor;
    }
}
