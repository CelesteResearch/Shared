using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Text.BitmapFonts;

namespace Celeste.Graphics.Text
{
    public sealed class ActiveBitmapFont(IActiveBitmapFontEnvironment environment)
    {
        private readonly IActiveBitmapFontEnvironment environment =
            environment ?? throw new ArgumentNullException(nameof(environment));

        public SourcePixelFont Font => environment.Font;
        public float BaseSize => environment.BaseSize;
        public float LineHeight => Font.Get(BaseSize).LineHeight;

        public Vector2 Measure(string text)
        {
            return Font.Get(BaseSize).Measure(text);
        }

        public Vector2 Measure(char text)
        {
            return Font.Get(BaseSize).Measure(text);
        }

        public float WidthToNextLine(string text, int start)
        {
            return Font.Get(BaseSize).WidthToNextLine(text, start);
        }

        public float HeightOf(string text)
        {
            return Font.Get(BaseSize).HeightOf(text);
        }

        public void Draw(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color)
        {
            Font.Draw(context, actualEntity, BaseSize, text, position, justify, scale, color);
        }

        public void Draw(ISourceRenderContext context, object actualEntity, char text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color)
        {
            Font.Draw(context, actualEntity, BaseSize, text, position, justify, scale, color);
        }

        public void DrawOutline(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color, float stroke, PackedColor strokeColor)
        {
            Font.DrawOutline(context, actualEntity, BaseSize, text, position, justify, scale, color, stroke,
                strokeColor);
        }

        public void DrawEdgeOutline(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color, float edgeDepth, PackedColor edgeColor, float stroke,
            PackedColor strokeColor)
        {
            Font.Draw(context, actualEntity, BaseSize, text, position, justify, scale, color, edgeDepth, edgeColor,
                stroke, strokeColor);
        }
    }
}
