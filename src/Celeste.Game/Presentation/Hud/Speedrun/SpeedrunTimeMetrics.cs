using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Game.Presentation.Hud.Speedrun
{
// Original SpeedrunTimerDisplay metrics are process fields, shared by every scene in one Engine.
    public sealed class SpeedrunTimeMetrics
    {
        public float NumberWidth;
        public float SpacerWidth;

        public void CalculateBaseSizes(SourcePixelFont font, float baseSize)
        {
            var size = font.Get(baseSize);
            for (var i = 0; i < 10; i++)
            {
                var width = size.Measure(i.ToString()).X;
                if (width > NumberWidth) NumberWidth = width;
            }

            SpacerWidth = size.Measure('.'.ToString()).X;
        }
    }
}
