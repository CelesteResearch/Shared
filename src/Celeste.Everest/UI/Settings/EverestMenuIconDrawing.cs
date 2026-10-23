using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Framework;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.UI.Settings
{
    public static class EverestMenuIconDrawing
    {
        public static void DrawIcon(TextMenuResources resources, ISourceRenderContext context, object actualEntity,
            Vector2 position, string iconName, float? inputWidth, float inputHeight,
            bool outline, PackedColor color, ref Vector2 textPosition)
        {
            if (iconName != null && resources.HasGui(iconName))
            {
                var texture = resources.Gui(iconName);
                float width = inputWidth ?? (float)texture.FrameWidth;
                float scale = inputHeight / (float)texture.FrameHeight;
                if (width > (float)texture.FrameWidth)
                    scale = SourceFrameworkMath.Min(scale, width / (float)texture.FrameWidth);
                var iconPosition = new Vector2(position.X + width * 0.5f * scale, position.Y);
                if (outline)
                    SourceAtlasDrawing.DrawOutline(context, actualEntity, texture, iconPosition, texture.Center, color,
                        scale);
                else
                    SourceAtlasDrawing.DrawCentered(context, actualEntity, texture, iconPosition, color, scale);
                textPosition.X += inputWidth ?? ((float)texture.FrameWidth * scale);
            }
        }
    }
}
