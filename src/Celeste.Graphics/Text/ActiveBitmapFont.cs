using Celeste.Core.Display;
using Celeste.Graphics.Display;
using Celeste.Graphics.Text.BitmapFonts;
using System;
using System.Numerics;
using Celeste.Core.Rendering;

namespace Celeste.Graphics.Text
{
    public sealed class ActiveBitmapFont
    {
        private readonly IActiveBitmapFontEnvironment environment;

        public ActiveBitmapFont(IActiveBitmapFontEnvironment environment)
            => this.environment = environment ?? throw new ArgumentNullException(nameof(environment));

        public SourcePixelFont Font => environment.Font;
        public float BaseSize => environment.BaseSize;
        public float LineHeight => Font.Get(BaseSize).LineHeight;
        public Vector2 Measure(string text) => Font.Get(BaseSize).Measure(text);
        public Vector2 Measure(char text) => Font.Get(BaseSize).Measure(text);
        public float WidthToNextLine(string text, int start) => Font.Get(BaseSize).WidthToNextLine(text, start);
        public float HeightOf(string text) => Font.Get(BaseSize).HeightOf(text);

        public void Draw(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color)
            => Font.Draw(context, actualEntity, BaseSize, text, position, justify, scale, color);

        public void Draw(ISourceRenderContext context, object actualEntity, char text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color)
            => Font.Draw(context, actualEntity, BaseSize, text, position, justify, scale, color);

        public void DrawOutline(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color, float stroke, PackedColor strokeColor)
            => Font.DrawOutline(context, actualEntity, BaseSize, text, position, justify, scale, color, stroke,
                strokeColor);

        public void DrawEdgeOutline(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color, float edgeDepth, PackedColor edgeColor,
            float stroke, PackedColor strokeColor)
            => Font.Draw(context, actualEntity, BaseSize, text, position, justify, scale, color,
                edgeDepth, edgeColor, stroke, strokeColor);
    }
}
