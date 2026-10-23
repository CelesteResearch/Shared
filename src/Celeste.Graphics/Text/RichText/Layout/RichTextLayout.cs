using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Nodes;

namespace Celeste.Graphics.Text.RichText.Layout
{
    public class RichTextLayout
    {
        public List<RichTextNode> Nodes;

        public int Lines;

        public int Pages;

        public SourcePixelFont Font;

        public float BaseSize;

        public int Count => Nodes.Count;

        public RichTextNode this[int index] => Nodes[index];

        public int GetCharactersOnPage(int start)
        {
            var num = 0;
            for (var i = start; i < Count; i++)
                if (Nodes[i] is RichTextGlyph)
                    num++;
                else if (Nodes[i] is RichTextPageBreak) break;

            return num;
        }

        public int GetNextPageStart(int start)
        {
            for (var i = start; i < Count; i++)
                if (Nodes[i] is RichTextPageBreak)
                    return i + 1;

            return Nodes.Count;
        }

        public float WidestLine()
        {
            var num = 0;
            for (var i = 0; i < Nodes.Count; i++)
                if (Nodes[i] is RichTextGlyph)
                    num = Math.Max(num, (int)(Nodes[i] as RichTextGlyph).LineWidth);

            return num;
        }

        public void Draw(ISourceRenderContext context, object actualEntity, ISourceRichTextDrawProcess engine,
            Vector2 position, Vector2 justify, Vector2 scale, float alpha, int start = 0, int end = int.MaxValue)
        {
            var num = Math.Min(Nodes.Count, end);
            var num2 = 0;
            var num3 = 0f;
            var num4 = 0f;
            var pixelFontSize = Font.Get(BaseSize);
            for (var i = start; i < num; i++)
                if (Nodes[i] is RichTextLineBreak)
                {
                    if (num3 == 0f) num3 = 1f;

                    num4 += num3;
                    num3 = 0f;
                }
                else if (Nodes[i] is RichTextGlyph)
                {
                    num2 = Math.Max(num2, (int)(Nodes[i] as RichTextGlyph).LineWidth);
                    num3 = engine.ExtremaArithmetic.Max(num3, (Nodes[i] as RichTextGlyph).Scale);
                }
                else if (Nodes[i] is RichTextPageBreak)
                {
                    break;
                }

            num4 += num3;
            position -= justify * new Vector2(num2, num4 * pixelFontSize.LineHeight) * scale;
            num3 = 0f;
            for (var j = start; j < num && Nodes[j] is not RichTextPageBreak; j++)
            {
                if (Nodes[j] is RichTextLineBreak)
                {
                    if (num3 == 0f) num3 = 1f;

                    position.Y += pixelFontSize.LineHeight * num3 * scale.Y;
                    num3 = 0f;
                }

                if (Nodes[j] is RichTextGlyph)
                {
                    var obj = Nodes[j] as RichTextGlyph;
                    obj.Draw(context, actualEntity, engine, Font, BaseSize, position, scale, alpha);
                    num3 = engine.ExtremaArithmetic.Max(num3, obj.Scale);
                }
            }
        }

        public void DrawJustifyPerLine(ISourceRenderContext context, object actualEntity,
            ISourceRichTextDrawProcess engine,
            Vector2 position, Vector2 justify, Vector2 scale, float alpha, int start = 0, int end = int.MaxValue)
        {
            var num = Math.Min(Nodes.Count, end);
            var num2 = 0f;
            var num3 = 0f;
            var pixelFontSize = Font.Get(BaseSize);
            for (var i = start; i < num; i++)
                if (Nodes[i] is RichTextLineBreak)
                {
                    if (num2 == 0f) num2 = 1f;

                    num3 += num2;
                    num2 = 0f;
                }
                else if (Nodes[i] is RichTextGlyph)
                {
                    num2 = engine.ExtremaArithmetic.Max(num2, (Nodes[i] as RichTextGlyph).Scale);
                }
                else if (Nodes[i] is RichTextPageBreak)
                {
                    break;
                }

            num3 += num2;
            num2 = 0f;
            for (var j = start; j < num && Nodes[j] is not RichTextPageBreak; j++)
            {
                if (Nodes[j] is RichTextLineBreak)
                {
                    if (num2 == 0f) num2 = 1f;

                    position.Y += num2 * pixelFontSize.LineHeight * scale.Y;
                    num2 = 0f;
                }

                if (Nodes[j] is RichTextGlyph)
                {
                    var obj = Nodes[j] as RichTextGlyph;
                    var vector = -justify * new Vector2(obj.LineWidth, num3 * pixelFontSize.LineHeight) *
                                 scale;
                    obj.Draw(context, actualEntity, engine, Font, BaseSize, position + vector, scale, alpha);
                    num2 = engine.ExtremaArithmetic.Max(num2, obj.Scale);
                }
            }
        }
    }
}
