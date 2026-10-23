using Celeste.Graphics.Rendering.Textures;
using System;
using System.Numerics;
using System.Text;
using System.Collections.Generic;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Graphics.Rendering.Batches
{
    public partial class SourceSpriteBatch
    {
        private static readonly float[] axisDirectionX = new float[4] { -1f, 1f, -1f, 1f };

        private static readonly float[] axisDirectionY = new float[4] { -1f, -1f, 1f, 1f };

        private static readonly float[] axisIsMirroredX = new float[4] { 0f, 1f, 0f, 1f };

        private static readonly float[] axisIsMirroredY = new float[4] { 0f, 0f, 1f, 1f };

        public void DrawString(SourceSpriteFont spriteFont, StringBuilder text, Vector2 position, uint color)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            DrawString(spriteFont, text, position, color, 0f, Vector2.Zero, Vector2.One, SourceSpriteEffects.None, 0f);
        }

        public void DrawString(SourceSpriteFont spriteFont, StringBuilder text, Vector2 position, uint color,
            float rotation, Vector2 origin, float scale, SourceSpriteEffects effects, float layerDepth)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            DrawString(spriteFont, text, position, color, rotation, origin, new Vector2(scale), effects, layerDepth);
        }

        public void DrawString(SourceSpriteFont spriteFont, StringBuilder text, Vector2 position, uint color,
            float rotation, Vector2 origin, Vector2 scale, SourceSpriteEffects effects, float layerDepth)
        {
            CheckBegin("DrawString");
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (text.Length == 0)
            {
                return;
            }

            effects &= SourceSpriteEffects.FlipHorizontally | SourceSpriteEffects.FlipVertically;
            SourceTexture2DResource textureValue = spriteFont.textureValue;
            List<IntRect> glyphData = spriteFont.glyphData;
            List<IntRect> croppingData = spriteFont.croppingData;
            List<Vector3> kerning = spriteFont.kerning;
            Dictionary<char, int> characterIndexMap = spriteFont.characterIndexMap;
            Vector2 vector = origin;
            float num = axisDirectionX[(int)effects];
            float num2 = axisDirectionY[(int)effects];
            float num3 = 0f;
            float num4 = 0f;
            if (effects != SourceSpriteEffects.None)
            {
                Vector2 vector2 = spriteFont.MeasureString(text);
                vector.X -= vector2.X * axisIsMirroredX[(int)effects];
                vector.Y -= vector2.Y * axisIsMirroredY[(int)effects];
                num3 = axisIsMirroredX[(int)effects];
                num4 = axisIsMirroredY[(int)effects];
            }

            Vector2 zero = Vector2.Zero;
            bool flag = true;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
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
                    {
                        throw new ArgumentException(
                            "Text contains characters that cannot be resolved by this SourceSpriteFont.", "text");
                    }

                    value = characterIndexMap[spriteFont.DefaultCharacter.Value];
                }

                Vector3 vector3 = kerning[value];
                if (flag)
                {
                    zero.X += Math.Abs(vector3.X);
                    flag = false;
                }
                else
                {
                    zero.X += spriteFont.Spacing + vector3.X;
                }

                IntRect rectangle = croppingData[value];
                IntRect rectangle2 = glyphData[value];
                float num5 = vector.X + (zero.X + (float)rectangle.X) * num;
                float num6 = vector.Y + (zero.Y + (float)rectangle.Y) * num2;
                if (effects != SourceSpriteEffects.None)
                {
                    num5 += (float)rectangle2.Width * num3;
                    num6 += (float)rectangle2.Height * num4;
                }

                float num7 = (float)Math.Sign(rectangle2.Width) *
                    Math.Max(Math.Abs(rectangle2.Width), machineEpsilonFloat) / (float)textureValue.Width;
                float num8 = (float)Math.Sign(rectangle2.Height) *
                    Math.Max(Math.Abs(rectangle2.Height), machineEpsilonFloat) / (float)textureValue.Height;
                PushSprite(textureValue, (float)rectangle2.X / (float)textureValue.Width,
                    (float)rectangle2.Y / (float)textureValue.Height, num7, num8, position.X, position.Y,
                    (float)rectangle2.Width * scale.X, (float)rectangle2.Height * scale.Y, color,
                    num5 / num7 / (float)textureValue.Width, num6 / num8 / (float)textureValue.Height,
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
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (text.Length == 0)
            {
                return;
            }

            effects &= SourceSpriteEffects.FlipHorizontally | SourceSpriteEffects.FlipVertically;
            SourceTexture2DResource textureValue = spriteFont.textureValue;
            List<IntRect> glyphData = spriteFont.glyphData;
            List<IntRect> croppingData = spriteFont.croppingData;
            List<Vector3> kerning = spriteFont.kerning;
            Dictionary<char, int> characterIndexMap = spriteFont.characterIndexMap;
            Vector2 vector = origin;
            float num = axisDirectionX[(int)effects];
            float num2 = axisDirectionY[(int)effects];
            float num3 = 0f;
            float num4 = 0f;
            if (effects != SourceSpriteEffects.None)
            {
                Vector2 vector2 = spriteFont.MeasureString(text);
                vector.X -= vector2.X * axisIsMirroredX[(int)effects];
                vector.Y -= vector2.Y * axisIsMirroredY[(int)effects];
                num3 = axisIsMirroredX[(int)effects];
                num4 = axisIsMirroredY[(int)effects];
            }

            Vector2 zero = Vector2.Zero;
            bool flag = true;
            foreach (char c in text)
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
                    {
                        throw new ArgumentException(
                            "Text contains characters that cannot be resolved by this SourceSpriteFont.", "text");
                    }

                    value = characterIndexMap[spriteFont.DefaultCharacter.Value];
                }

                Vector3 vector3 = kerning[value];
                if (flag)
                {
                    zero.X += Math.Abs(vector3.X);
                    flag = false;
                }
                else
                {
                    zero.X += spriteFont.Spacing + vector3.X;
                }

                IntRect rectangle = croppingData[value];
                IntRect rectangle2 = glyphData[value];
                float num5 = vector.X + (zero.X + (float)rectangle.X) * num;
                float num6 = vector.Y + (zero.Y + (float)rectangle.Y) * num2;
                if (effects != SourceSpriteEffects.None)
                {
                    num5 += (float)rectangle2.Width * num3;
                    num6 += (float)rectangle2.Height * num4;
                }

                float num7 = (float)Math.Sign(rectangle2.Width) *
                    Math.Max(Math.Abs(rectangle2.Width), machineEpsilonFloat) / (float)textureValue.Width;
                float num8 = (float)Math.Sign(rectangle2.Height) *
                    Math.Max(Math.Abs(rectangle2.Height), machineEpsilonFloat) / (float)textureValue.Height;
                PushSprite(textureValue, (float)rectangle2.X / (float)textureValue.Width,
                    (float)rectangle2.Y / (float)textureValue.Height, num7, num8, position.X, position.Y,
                    (float)rectangle2.Width * scale.X, (float)rectangle2.Height * scale.Y, color,
                    num5 / num7 / (float)textureValue.Width, num6 / num8 / (float)textureValue.Height,
                    (float)Math.Sin(rotation), (float)Math.Cos(rotation), layerDepth, (byte)effects);
                zero.X += vector3.Y + vector3.Z;
            }
        }
    }
}
