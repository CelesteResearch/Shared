using Celeste.Input.Bindings;
using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;

namespace Celeste.Game.UI.Controls
{
    public static class OriginalButtonUi
    {
        public static float Width(ISourceEngineContext engine, string label, SourceVirtualButton button)
        {
            var texture = ((IOriginalGameInputProcessEnvironment)engine).InputSource.GuiButton(button);
            return ((ISourceActiveFontScope)engine).ActiveFont.Measure(label).X + 8f + texture.FrameWidth;
        }

        public static void Render(ISourceRenderContext context, object entity, ISourceEngineContext engine,
            Vector2 position, string label, SourceVirtualButton button, float scale,
            float justifyX = 0.5f, float wiggle = 0f, float alpha = 1f)
        {
            var texture = ((IOriginalGameInputProcessEnvironment)engine).InputSource.GuiButton(button);
            float width = Width(engine, label, button);
            position.X -= scale * width * (justifyX - 0.5f);
            SourceAtlasDrawing.Draw(context, entity, texture, position,
                new Vector2(texture.FrameWidth - width / 2f, texture.FrameHeight / 2f),
                PackedColor.White * alpha, scale + wiggle);
            DrawText(context, entity, engine, label, position, width / 2f, scale + wiggle, alpha);
        }

        private static void DrawText(ISourceRenderContext context, object entity, ISourceEngineContext engine,
            string text, Vector2 position, float justify, float scale, float alpha)
        {
            float x = ((ISourceActiveFontScope)engine).ActiveFont.Measure(text).X;
            ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, entity, text, position,
                new Vector2(justify / x, 0.5f), Vector2.One * scale,
                PackedColor.White * alpha, 2f, PackedColor.Black * alpha);
        }
    }
}
