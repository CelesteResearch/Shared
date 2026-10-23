using Celeste.Core.Display;
using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Settings;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;

namespace Celeste.Game.Menus.Files
{
    public partial class FileNamingSequence
    {
        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * 0.8f * ease);
            Vector2 vector = boxtopleft + new Vector2(boxPadding, boxPadding);
            int num = 0;
            string[] array = letters;
            foreach (string text in array)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    bool flag = num == line && j == index && !selectingOptions;
                    Vector2 scale = Vector2.One * (flag ? 1.2f : 1f);
                    Vector2 at = vector + new Vector2(widestLetter, lineHeight) / 2f;
                    if (flag)
                    {
                        at += new Vector2(0f, wiggler.Value) * 8f;
                    }

                    DrawOptionText(context, text[j].ToString(), at, new Vector2(0.5f, 0.5f), scale, flag);
                    vector.X += widestLetter;
                }

                vector.X = boxtopleft.X + boxPadding;
                vector.Y += lineHeight + lineSpacing;
                num++;
            }

            float num2 = wiggler.Value * 8f;
            vector.Y = boxtopleft.Y + boxHeight - lineHeight - boxPadding;
            SourcePrimitiveDrawing.Rect(context, this, vector.X, vector.Y - boxPadding * 0.5f,
                boxWidth - boxPadding * 2f,
                4f, PackedColor.White);
            DrawOptionText(context, cancel,
                vector + new Vector2(0f, lineHeight + ((selectingOptions && optionsIndex == 0) ? num2 : 0f)),
                new Vector2(0f, 1f), Vector2.One * optionsScale, selectingOptions && optionsIndex == 0);
            vector.X = boxtopleft.X + boxWidth - backspaceWidth - widestLetter - spaceWidth - widestLetter -
                       beginWidth -
                       boxPadding;
            DrawOptionText(context, space,
                vector + new Vector2(0f, lineHeight + ((selectingOptions && optionsIndex == 1) ? num2 : 0f)),
                new Vector2(0f, 1f), Vector2.One * optionsScale, selectingOptions && optionsIndex == 1,
                Name.Length == 0 || !Focused);
            vector.X += spaceWidth + widestLetter;
            DrawOptionText(context, backspace,
                vector + new Vector2(0f, lineHeight + ((selectingOptions && optionsIndex == 2) ? num2 : 0f)),
                new Vector2(0f, 1f), Vector2.One * optionsScale, selectingOptions && optionsIndex == 2,
                Name.Length <= 0 || !Focused);
            vector.X += backspaceWidth + widestLetter;
            DrawOptionText(context, accept,
                vector + new Vector2(0f, lineHeight + ((selectingOptions && optionsIndex == 3) ? num2 : 0f)),
                new Vector2(0f, 1f), Vector2.One * optionsScale * 1.25f, selectingOptions && optionsIndex == 3,
                Name.Length < 1 || !Focused);
            if (Japanese)
            {
                float num3 = 1f;
                string text2 =
                    ((IOriginalGameTextEnvironment)engine).Text.CleanDialog(hiragana
                        ? "NAME_LETTERS_SWAP_KATAKANA"
                        : "NAME_LETTERS_SWAP_HIRAGANA");
                var mTexture = Input.GuiButton(Input.MenuJournal);
                ActiveFont.Measure(text2);
                float num4 = (float)mTexture.FrameWidth * num3;
                Vector2 vector2 = new Vector2(70f, 1144f - 154f * ease);
                SourceAtlasDrawing.DrawJustified(context, this, mTexture, vector2, new Vector2(0f, 0.5f),
                    PackedColor.White,
                    num3, 0f);
                ActiveFont.DrawOutline(context, this, text2, vector2 + new Vector2(16f + num4, 0f),
                    new Vector2(0f, 0.5f),
                    Vector2.One * num3, PackedColor.White, 2f, PackedColor.Black);
            }
        }

        protected virtual void DrawOptionText(ISourceRenderContext context, string text, Vector2 at, Vector2 justify,
            Vector2 scale, bool selected, bool disabled = false)
        {
            bool num = selected && pressedTimer > 0f;
            PackedColor color = (disabled ? disableColor : GetTextColor(selected));
            PackedColor edgeColor = (disabled
                ? SourceColorInterpolation.Lerp(disableColor, PackedColor.Black, 0.7f,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic)
                : PackedColor.Gray);
            if (num)
            {
                ActiveFont.Draw(context, this, text, at + Vector2.UnitY, justify, scale, color);
            }
            else
            {
                ActiveFont.DrawEdgeOutline(context, this, text, at, justify, scale, color, 4f, edgeColor, 0f,
                    default(PackedColor));
            }
        }

        protected virtual PackedColor GetTextColor(bool selected)
        {
            if (selected)
            {
                if (Settings.DisableFlashes)
                {
                    return selectColorA;
                }

                if (!IntervalQueries.BetweenInterval(timer, 0.1f))
                {
                    return selectColorB;
                }

                return selectColorA;
            }

            return unselectColor;
        }
    }
}
