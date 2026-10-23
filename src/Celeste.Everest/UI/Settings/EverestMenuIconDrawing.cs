using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.UI.Menus.Text;

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
                var width = inputWidth ?? texture.FrameWidth;
                var scale = inputHeight / texture.FrameHeight;
                if (width > texture.FrameWidth)
                    scale = SourceFrameworkMath.Min(scale, width / texture.FrameWidth);
                var iconPosition = new Vector2(position.X + width * 0.5f * scale, position.Y);
                if (outline)
                    SourceAtlasDrawing.DrawOutline(context, actualEntity, texture, iconPosition, texture.Center, color,
                        scale);
                else
                    SourceAtlasDrawing.DrawCentered(context, actualEntity, texture, iconPosition, color, scale);
                textPosition.X += inputWidth ?? texture.FrameWidth * scale;
            }
        }
    }
}
