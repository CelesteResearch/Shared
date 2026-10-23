using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Timing;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestModOptionStringState
    {
        public override void Render(ISourceRenderContext context)
        {
            var num = index;
            if (UseKeyboardInput) index = -1;

            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * 0.8f * ease);
            var vector = boxtopleft + new Vector2(boxPadding, boxPadding);
            var num2 = 0;
            var array = letters;
            foreach (var text in array)
            {
                for (var j = 0; j < text.Length; j++)
                {
                    var flag = num2 == line && j == index && !selectingOptions;
                    var scale = Vector2.One * (flag ? 1.2f : 1f);
                    var at = vector + new Vector2(widestLetter, lineHeight) / 2f;
                    if (flag) at += new Vector2(0f, wiggler.Value) * 8f;

                    DrawOptionText(context, text[j].ToString(), at, new(0.5f, 0.5f), scale, flag);
                    vector.X += widestLetter;
                }

                vector.X = boxtopleft.X + boxPadding;
                vector.Y += lineHeight + lineSpacing;
                num2++;
            }

            var num3 = wiggler.Value * 8f;
            vector.Y = boxtopleft.Y + boxHeight - lineHeight - boxPadding;
            SourcePrimitiveDrawing.Rect(context, this, vector.X, vector.Y - boxPadding * 0.5f,
                boxWidth - boxPadding * 2f,
                4f, PackedColor.White);
            DrawOptionText(context, cancel,
                vector + new Vector2(0f, lineHeight + (selectingOptions && optionsIndex == 0 ? num3 : 0f)),
                new(0f, 1f), Vector2.One * optionsScale, selectingOptions && optionsIndex == 0);
            vector.X = boxtopleft.X + boxWidth - backspaceWidth - widestLetter - spaceWidth - widestLetter -
                       beginWidth -
                       boxPadding;
            DrawOptionText(context, space,
                vector + new Vector2(0f, lineHeight + (selectingOptions && optionsIndex == 1 ? num3 : 0f)),
                new(0f, 1f), Vector2.One * optionsScale, selectingOptions && optionsIndex == 1,
                Value.Length == 0 || !Focused);
            vector.X += spaceWidth + widestLetter;
            DrawOptionText(context, backspace,
                vector + new Vector2(0f, lineHeight + (selectingOptions && optionsIndex == 2 ? num3 : 0f)),
                new(0f, 1f), Vector2.One * optionsScale, selectingOptions && optionsIndex == 2,
                Value.Length <= 0 || !Focused);
            vector.X += backspaceWidth + widestLetter;
            DrawOptionText(context, accept,
                vector + new Vector2(0f, lineHeight + (selectingOptions && optionsIndex == 3 ? num3 : 0f)),
                new(0f, 1f), Vector2.One * optionsScale, selectingOptions && optionsIndex == 3,
                Value.Length < 1 || !Focused);
            ActiveFont.DrawEdgeOutline(context, this, Value, Position + new Vector2(960f, 256f),
                new(0.5f, 0.5f),
                Vector2.One * 2f, PackedColor.Gray, 4f, PackedColor.DarkSlateBlue, 2f, PackedColor.Black);
            index = num;
        }

        private void DrawOptionText(ISourceRenderContext context, string text, Vector2 at, Vector2 justify,
            Vector2 scale,
            bool selected, bool disabled = false)
        {
            if (UseKeyboardInput)
            {
                selected = false;
                disabled = true;
            }

            var color = disabled ? disableColor : GetTextColor(selected);
            var edgeColor = disabled
                ? SourceColorInterpolation.Lerp(disableColor, PackedColor.Black, 0.7f,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic)
                : PackedColor.Gray;
            if (selected && pressedTimer > 0f)
                ActiveFont.Draw(context, this, text, at + Vector2.UnitY, justify, scale, color);
            else
                ActiveFont.DrawEdgeOutline(context, this, text, at, justify, scale, color, 4f, edgeColor, 0f,
                    default);
        }

        private PackedColor GetTextColor(bool selected)
        {
            if (selected) return !IntervalQueries.BetweenInterval(timer, 0.1f) ? selectColorB : selectColorA;

            return unselectColor;
        }
    }
}
