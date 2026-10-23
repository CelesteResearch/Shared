using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;

namespace Celeste.Simulation.UI.Menus.Text
{
    public sealed class TextMenuDrawing
    {
        private readonly TextMenuResources resources;
        public TextMenuDrawing(TextMenuResources resources) => this.resources = resources;
        private ActiveBitmapFont Font => ((ISourceActiveFontScope)resources.EngineContext).ActiveFont;
        public float LineHeight => Font.LineHeight;
        public Vector2 Measure(string text) => Font.Measure(text);
        public float HeightOf(string text) => Font.HeightOf(text);

        public void Image(ISourceRenderContext context, object entity, AtlasEntry entry,
            Vector2 position, Vector2 justify, global::Celeste.Core.Display.PackedColor color)
            => SourceAtlasDrawing.DrawJustified(context, entity, entry, position, justify, color);

        public void DrawOutline(ISourceRenderContext context, object entity, string text,
            Vector2 position, Vector2 justify, Vector2 scale, global::Celeste.Core.Display.PackedColor color,
            float stroke, global::Celeste.Core.Display.PackedColor strokeColor)
            => Font.DrawOutline(context, entity, text, position, justify, scale, color, stroke, strokeColor);

        public void DrawEdgeOutline(ISourceRenderContext context, object entity, string text,
            Vector2 position, Vector2 justify, Vector2 scale, global::Celeste.Core.Display.PackedColor color,
            float edge, global::Celeste.Core.Display.PackedColor edgeColor, float stroke,
            global::Celeste.Core.Display.PackedColor strokeColor)
            => Font.DrawEdgeOutline(context, entity, text, position, justify, scale, color,
                edge, edgeColor, stroke, strokeColor);
    }
}
