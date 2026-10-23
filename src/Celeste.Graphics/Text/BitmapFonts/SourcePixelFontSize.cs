using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;

namespace Celeste.Graphics.Text.BitmapFonts
{
    public class SourcePixelFontSize
    {
        public List<AtlasEntry> Textures;

        public Dictionary<int, SourcePixelFontCharacter> Characters;

        public int LineHeight;

        public float Size;

        public bool Outline;

        private readonly StringBuilder temp = new();

        public string AutoNewline(string text, int width)
        {
            if (string.IsNullOrEmpty(text)) return text;

            temp.Clear();
            var array = Regex.Split(text, "(\\s)");
            var num = 0f;
            var array2 = array;
            foreach (var text2 in array2)
            {
                var x = Measure(text2).X;
                if (x + num > width)
                {
                    temp.Append('\n');
                    num = 0f;
                    if (text2.Equals(" ")) continue;
                }

                if (x > width)
                {
                    var j = 1;
                    var num2 = 0;
                    for (; j < text2.Length; j++)
                        if (j - num2 > 1 && Measure(text2.Substring(num2, j - num2 - 1)).X > width)
                        {
                            temp.Append(text2.Substring(num2, j - num2 - 1));
                            temp.Append('\n');
                            num2 = j - 1;
                        }

                    var text3 = text2.Substring(num2, text2.Length - num2);
                    temp.Append(text3);
                    num += Measure(text3).X;
                }
                else
                {
                    num += x;
                    temp.Append(text2);
                }
            }

            return temp.ToString();
        }

        public SourcePixelFontCharacter Get(int id)
        {
            SourcePixelFontCharacter value = null;
            if (Characters.TryGetValue(id, out value)) return value;

            return null;
        }

        public Vector2 Measure(char text)
        {
            SourcePixelFontCharacter value = null;
            if (Characters.TryGetValue(text, out value)) return new(value.XAdvance, LineHeight);

            return Vector2.Zero;
        }

        public Vector2 Measure(string text)
        {
            if (string.IsNullOrEmpty(text)) return Vector2.Zero;

            var result = new Vector2(0f, LineHeight);
            var num = 0f;
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    result.Y += LineHeight;
                    if (num > result.X) result.X = num;

                    num = 0f;
                    continue;
                }

                SourcePixelFontCharacter value = null;
                if (Characters.TryGetValue(text[i], out value))
                {
                    num += value.XAdvance;
                    if (i < text.Length - 1 && value.Kerning.TryGetValue(text[i + 1], out var value2)) num += value2;
                }
            }

            if (num > result.X) result.X = num;

            return result;
        }

        public float WidthToNextLine(string text, int start)
        {
            if (string.IsNullOrEmpty(text)) return 0f;

            var num = 0f;
            var i = start;
            for (var length = text.Length; i < length && text[i] != '\n'; i++)
            {
                SourcePixelFontCharacter value = null;
                if (Characters.TryGetValue(text[i], out value))
                {
                    num += value.XAdvance;
                    if (i < length - 1 && value.Kerning.TryGetValue(text[i + 1], out var value2)) num += value2;
                }
            }

            return num;
        }

        public float HeightOf(string text)
        {
            if (string.IsNullOrEmpty(text)) return 0f;

            var num = 1;
            if (text.IndexOf('\n') >= 0)
                for (var i = 0; i < text.Length; i++)
                    if (text[i] == '\n')
                        num++;

            return num * LineHeight;
        }

        public void Draw(ISourceRenderContext context, object actualEntity, char character, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color)
        {
            if (!char.IsWhiteSpace(character))
            {
                SourcePixelFontCharacter value = null;
                if (Characters.TryGetValue(character, out value))
                {
                    var vector = Measure(character);
                    var vector2 = new Vector2(vector.X * justify.X, vector.Y * justify.Y);
                    var val = position + (new Vector2(value.XOffset, value.YOffset) - vector2) * scale;
                    SourceAtlasDrawing.Draw(context, actualEntity, value.Texture, Vector2Geometry.Floor(val),
                        Vector2.Zero,
                        color, scale);
                }
            }
        }

        public void Draw(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify,
            Vector2 scale, PackedColor color, float edgeDepth, PackedColor edgeColor, float stroke,
            PackedColor strokeColor)
        {
            if (string.IsNullOrEmpty(text)) return;

            var zero = Vector2.Zero;
            var num = justify.X != 0f ? WidthToNextLine(text, 0) : 0f;
            var vector = new Vector2(num * justify.X, HeightOf(text) * justify.Y);
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    zero.X = 0f;
                    zero.Y += LineHeight;
                    if (justify.X != 0f) vector.X = WidthToNextLine(text, i + 1) * justify.X;

                    continue;
                }

                SourcePixelFontCharacter value = null;
                if (!Characters.TryGetValue(text[i], out value)) continue;

                var vector2 = position + (zero + new Vector2(value.XOffset, value.YOffset) - vector) * scale;
                if (stroke > 0f && !Outline)
                {
                    if (edgeDepth > 0f)
                    {
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(0f, 0f - stroke), Vector2.Zero, strokeColor, scale);
                        for (var num2 = 0f - stroke; num2 < edgeDepth + stroke; num2 += stroke)
                        {
                            SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                                vector2 + new Vector2(0f - stroke, num2), Vector2.Zero, strokeColor, scale);
                            SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                                vector2 + new Vector2(stroke, num2), Vector2.Zero, strokeColor, scale);
                        }

                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(0f - stroke, edgeDepth + stroke), Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(0f, edgeDepth + stroke), Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(stroke, edgeDepth + stroke), Vector2.Zero, strokeColor, scale);
                    }
                    else
                    {
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(-1f, -1f) * stroke, Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(0f, -1f) * stroke, Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(1f, -1f) * stroke, Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(-1f, 0f) * stroke, Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(1f, 0f) * stroke, Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(-1f, 1f) * stroke, Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(0f, 1f) * stroke, Vector2.Zero, strokeColor, scale);
                        SourceAtlasDrawing.Draw(context, actualEntity, value.Texture,
                            vector2 + new Vector2(1f, 1f) * stroke, Vector2.Zero, strokeColor, scale);
                    }
                }

                if (edgeDepth > 0f)
                    SourceAtlasDrawing.Draw(context, actualEntity, value.Texture, vector2 + Vector2.UnitY * edgeDepth,
                        Vector2.Zero, edgeColor, scale);

                SourceAtlasDrawing.Draw(context, actualEntity, value.Texture, vector2, Vector2.Zero, color, scale);
                zero.X += value.XAdvance;
                if (i < text.Length - 1 && value.Kerning.TryGetValue(text[i + 1], out var value2)) zero.X += value2;
            }
        }

        public void Draw(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            PackedColor color)
        {
            Draw(context, actualEntity, text, position, Vector2.Zero, Vector2.One, color, 0f, PackedColor.Transparent,
                0f,
                PackedColor.Transparent);
        }

        public void Draw(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify,
            Vector2 scale, PackedColor color)
        {
            Draw(context, actualEntity, text, position, justify, scale, color, 0f, PackedColor.Transparent, 0f,
                PackedColor.Transparent);
        }

        public void DrawOutline(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color, float stroke, PackedColor strokeColor)
        {
            Draw(context, actualEntity, text, position, justify, scale, color, 0f, PackedColor.Transparent, stroke,
                strokeColor);
        }

        public void DrawEdgeOutline(ISourceRenderContext context, object actualEntity, string text, Vector2 position,
            Vector2 justify, Vector2 scale, PackedColor color, float edgeDepth, PackedColor edgeColor,
            float stroke = 0f,
            PackedColor strokeColor = default)
        {
            Draw(context, actualEntity, text, position, justify, scale, color, edgeDepth, edgeColor, stroke,
                strokeColor);
        }
    }
}
