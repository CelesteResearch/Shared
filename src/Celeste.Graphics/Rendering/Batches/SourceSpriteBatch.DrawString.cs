using System;
using System.Numerics;
using System.Text;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Graphics.Rendering.Batches
{
    public partial class SourceSpriteBatch
    {
        private static readonly float[] axisDirectionX = [-1f, 1f, -1f, 1f];

        private static readonly float[] axisDirectionY = [-1f, -1f, 1f, 1f];

        private static readonly float[] axisIsMirroredX = [0f, 1f, 0f, 1f];

        private static readonly float[] axisIsMirroredY = [0f, 0f, 1f, 1f];

        public void DrawString(SourceSpriteFont spriteFont, StringBuilder text, Vector2 position, uint color)
        {
            if (text == null) throw new ArgumentNullException("text");

            DrawString(spriteFont, text, position, color, 0f, Vector2.Zero, Vector2.One, SourceSpriteEffects.None, 0f);
        }

        public void DrawString(SourceSpriteFont spriteFont, StringBuilder text, Vector2 position, uint color,
            float rotation, Vector2 origin, float scale, SourceSpriteEffects effects, float layerDepth)
        {
            if (text == null) throw new ArgumentNullException("text");

            DrawString(spriteFont, text, position, color, rotation, origin, new Vector2(scale), effects, layerDepth);
        }

        public void DrawString(SourceSpriteFont spriteFont, StringBuilder text, Vector2 position, uint color,
            float rotation, Vector2 origin, Vector2 scale, SourceSpriteEffects effects, float layerDepth)
        {
            CheckBegin("DrawString");
            if (text == null) throw new ArgumentNullException("text");

            if (text.Length == 0) return;

            effects &= SourceSpriteEffects.FlipHorizontally | SourceSpriteEffects.FlipVertically;
            var textureValue = spriteFont.textureValue;
            var glyphData = spriteFont.glyphData;
            var croppingData = spriteFont.croppingData;
            var kerning = spriteFont.kerning;
            var characterIndexMap = spriteFont.characterIndexMap;
            var vector = origin;
            var num = axisDirectionX[(int)effects];
            var num2 = axisDirectionY[(int)effects];
            var num3 = 0f;
            var num4 = 0f;
            if (effects != SourceSpriteEffects.None)
            {
                var vector2 = spriteFont.MeasureString(text);
                vector.X -= vector2.X * axisIsMirroredX[(int)effects];
                vector.Y -= vector2.Y * axisIsMirroredY[(int)effects];
                num3 = axisIsMirroredX[(int)effects];
                num4 = axisIsMirroredY[(int)effects];
            }

            var zero = Vector2.Zero;
            var flag = true;
            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                switch (c)
                {
                    case '\n':
                        zero.X = 0f;
                        zero.Y += spriteFont.LineSpacing;
                        flag = true;
                        continue;
                    case '\r':
                        continue;
                }

                if (!characterIndexMap.TryGetValue(c, out var value))
                {
                    if (!spriteFont.DefaultCharacter.HasValue)
                        throw new ArgumentException(
                            "Text contains characters that cannot be resolved by this SourceSpriteFont.", "text");

                    value = characterIndexMap[spriteFont.DefaultCharacter.Value];
                }

                var vector3 = kerning[value];
                if (flag)
                {
                    zero.X += Math.Abs(vector3.X);
                    flag = false;
                }
                else
                {
                    zero.X += spriteFont.Spacing + vector3.X;
                }

                var rectangle = croppingData[value];
                var rectangle2 = glyphData[value];
                var num5 = vector.X + (zero.X + rectangle.X) * num;
                var num6 = vector.Y + (zero.Y + rectangle.Y) * num2;
                if (effects != SourceSpriteEffects.None)
                {
                    num5 += rectangle2.Width * num3;
                    num6 += rectangle2.Height * num4;
                }

                var num7 = Math.Sign(rectangle2.Width) *
                    Math.Max(Math.Abs(rectangle2.Width), machineEpsilonFloat) / textureValue.Width;
                var num8 = Math.Sign(rectangle2.Height) *
                    Math.Max(Math.Abs(rectangle2.Height), machineEpsilonFloat) / textureValue.Height;
                PushSprite(textureValue, rectangle2.X / (float)textureValue.Width,
                    rectangle2.Y / (float)textureValue.Height, num7, num8, position.X, position.Y,
                    rectangle2.Width * scale.X, rectangle2.Height * scale.Y, color,
                    num5 / num7 / textureValue.Width, num6 / num8 / textureValue.Height,
                    (float)Math.Sin(rotation), (float)Math.Cos(rotation), layerDepth, (byte)effects);
                zero.X += vector3.Y + vector3.Z;
            }
        }

        public void DrawString(SourceSpriteFont spriteFont, string text, Vector2 position, uint color)
        {
            DrawString(spriteFont, text, position, color, 0f, Vector2.Zero, Vector2.One, SourceSpriteEffects.None, 0f);
        }

        public void DrawString(SourceSpriteFont spriteFont, string text, Vector2 position, uint color, float rotation,
            Vector2 origin, float scale, SourceSpriteEffects effects, float layerDepth)
        {
            DrawString(spriteFont, text, position, color, rotation, origin, new Vector2(scale), effects, layerDepth);
        }

        public void DrawString(SourceSpriteFont spriteFont, string text, Vector2 position, uint color, float rotation,
            Vector2 origin, Vector2 scale, SourceSpriteEffects effects, float layerDepth)
        {
            CheckBegin("DrawString");
            if (text == null) throw new ArgumentNullException("text");

            if (text.Length == 0) return;

            effects &= SourceSpriteEffects.FlipHorizontally | SourceSpriteEffects.FlipVertically;
            var textureValue = spriteFont.textureValue;
            var glyphData = spriteFont.glyphData;
            var croppingData = spriteFont.croppingData;
            var kerning = spriteFont.kerning;
            var characterIndexMap = spriteFont.characterIndexMap;
            var vector = origin;
            var num = axisDirectionX[(int)effects];
            var num2 = axisDirectionY[(int)effects];
            var num3 = 0f;
            var num4 = 0f;
            if (effects != SourceSpriteEffects.None)
            {
                var vector2 = spriteFont.MeasureString(text);
                vector.X -= vector2.X * axisIsMirroredX[(int)effects];
                vector.Y -= vector2.Y * axisIsMirroredY[(int)effects];
                num3 = axisIsMirroredX[(int)effects];
                num4 = axisIsMirroredY[(int)effects];
            }

            var zero = Vector2.Zero;
            var flag = true;
            foreach (var c in text)
            {
                switch (c)
                {
                    case '\n':
                        zero.X = 0f;
                        zero.Y += spriteFont.LineSpacing;
                        flag = true;
                        continue;
                    case '\r':
                        continue;
                }

                if (!characterIndexMap.TryGetValue(c, out var value))
                {
                    if (!spriteFont.DefaultCharacter.HasValue)
                        throw new ArgumentException(
                            "Text contains characters that cannot be resolved by this SourceSpriteFont.", "text");

                    value = characterIndexMap[spriteFont.DefaultCharacter.Value];
                }

                var vector3 = kerning[value];
                if (flag)
                {
                    zero.X += Math.Abs(vector3.X);
                    flag = false;
                }
                else
                {
                    zero.X += spriteFont.Spacing + vector3.X;
                }

                var rectangle = croppingData[value];
                var rectangle2 = glyphData[value];
                var num5 = vector.X + (zero.X + rectangle.X) * num;
                var num6 = vector.Y + (zero.Y + rectangle.Y) * num2;
                if (effects != SourceSpriteEffects.None)
                {
                    num5 += rectangle2.Width * num3;
                    num6 += rectangle2.Height * num4;
                }

                var num7 = Math.Sign(rectangle2.Width) *
                    Math.Max(Math.Abs(rectangle2.Width), machineEpsilonFloat) / textureValue.Width;
                var num8 = Math.Sign(rectangle2.Height) *
                    Math.Max(Math.Abs(rectangle2.Height), machineEpsilonFloat) / textureValue.Height;
                PushSprite(textureValue, rectangle2.X / (float)textureValue.Width,
                    rectangle2.Y / (float)textureValue.Height, num7, num8, position.X, position.Y,
                    rectangle2.Width * scale.X, rectangle2.Height * scale.Y, color,
                    num5 / num7 / textureValue.Width, num6 / num8 / textureValue.Height,
                    (float)Math.Sin(rotation), (float)Math.Cos(rotation), layerDepth, (byte)effects);
                zero.X += vector3.Y + vector3.Z;
            }
        }
    }
}
