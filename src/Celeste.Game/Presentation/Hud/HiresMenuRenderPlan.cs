using System;

namespace Celeste.Game.Presentation.Hud
{
    // Original Celeste.HiresRenderer/HudTarget policy. Pixel coordinates stay
    // in the 1920x1080 HUD coordinate space; the buffer has a one-pixel gutter.
    public readonly struct HiresMenuRenderPlan
    {
        public const int LogicalWidth = 1920;
        public const int LogicalHeight = 1080;
        public const int TargetWidth = 1922;
        public const int TargetHeight = 1082;
        public const int CompositeX = -1;
        public const int CompositeY = -1;

        public readonly bool DrawToBuffer;

        private HiresMenuRenderPlan(bool drawToBuffer)
        {
            DrawToBuffer = drawToBuffer;
        }

        // Width/height are Engine.ViewWidth/ViewHeight after viewport padding.
        public static HiresMenuRenderPlan ForView(int width, int height)
        {
            if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            return new(width < LogicalWidth ||
                       height < LogicalHeight);
        }
    }
}
