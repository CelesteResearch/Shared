using Celeste.Graphics.Rendering.Textures;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering.Effects;
using System;
using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Rendering.Batches
{
    public partial class SourceSpriteBatch
    {
        public void Draw(SourceTexture2DResource texture, Vector2 position, uint color)
        {
            CheckBegin("Draw");
            PushSprite(texture, 0f, 0f, 1f, 1f, position.X, position.Y, texture.Width, texture.Height, color, 0f, 0f,
                0f,
                1f, 0f, 0);
        }

        public void Draw(SourceTexture2DResource texture, Vector2 position, IntRect? sourceRectangle, uint color)
        {
            float sourceX;
            float sourceY;
            float sourceW;
            float sourceH;
            float destinationW;
            float destinationH;
            if (sourceRectangle.HasValue)
            {
                sourceX = (float)sourceRectangle.Value.X / (float)texture.Width;
                sourceY = (float)sourceRectangle.Value.Y / (float)texture.Height;
                sourceW = (float)sourceRectangle.Value.Width / (float)texture.Width;
                sourceH = (float)sourceRectangle.Value.Height / (float)texture.Height;
                destinationW = sourceRectangle.Value.Width;
                destinationH = sourceRectangle.Value.Height;
            }
            else
            {
                sourceX = 0f;
                sourceY = 0f;
                sourceW = 1f;
                sourceH = 1f;
                destinationW = texture.Width;
                destinationH = texture.Height;
            }

            CheckBegin("Draw");
            PushSprite(texture, sourceX, sourceY, sourceW, sourceH, position.X, position.Y, destinationW, destinationH,
                color, 0f, 0f, 0f, 1f, 0f, 0);
        }

        public void Draw(SourceTexture2DResource texture, Vector2 position, IntRect? sourceRectangle, uint color,
            float rotation, Vector2 origin, float scale, SourceSpriteEffects effects, float layerDepth)
        {
            CheckBegin("Draw");
            float num = scale;
            float num2 = scale;
            float sourceX;
            float sourceY;
            float num3;
            float num4;
            if (sourceRectangle.HasValue)
            {
                var rectangle = sourceRectangle.Value;
                if (rectangle.X == 0 && rectangle.Y == 0 &&
                    rectangle.Width > 0 && rectangle.Height > 0 &&
                    rectangle.Width == texture.Width && rectangle.Height == texture.Height)
                {
                    sourceX = 0f;
                    sourceY = 0f;
                    num3 = 1f;
                    num4 = 1f;
                }
                else
                {
                    sourceX = (float)rectangle.X / (float)texture.Width;
                    sourceY = (float)rectangle.Y / (float)texture.Height;
                    num3 = (float)Math.Sign(rectangle.Width) *
                        Math.Max(Math.Abs(rectangle.Width), machineEpsilonFloat) / (float)texture.Width;
                    num4 = (float)Math.Sign(rectangle.Height) *
                        Math.Max(Math.Abs(rectangle.Height), machineEpsilonFloat) / (float)texture.Height;
                }

                num *= (float)rectangle.Width;
                num2 *= (float)rectangle.Height;
            }
            else
            {
                sourceX = 0f;
                sourceY = 0f;
                num3 = 1f;
                num4 = 1f;
                num *= (float)texture.Width;
                num2 *= (float)texture.Height;
            }

            PushSprite(texture, sourceX, sourceY, num3, num4, position.X, position.Y, num, num2, color,
                origin.X / num3 / (float)texture.Width, origin.Y / num4 / (float)texture.Height,
                rotation == 0f ? rotation : (float)Math.Sin(rotation),
                rotation == 0f ? 1f : (float)Math.Cos(rotation), layerDepth,
                (byte)(effects & (SourceSpriteEffects.FlipHorizontally | SourceSpriteEffects.FlipVertically)));
        }

        public void Draw(SourceTexture2DResource texture, Vector2 position, IntRect? sourceRectangle, uint color,
            float rotation, Vector2 origin, Vector2 scale, SourceSpriteEffects effects, float layerDepth)
        {
            CheckBegin("Draw");
            float sourceX;
            float sourceY;
            float num;
            float num2;
            if (sourceRectangle.HasValue)
            {
                var rectangle = sourceRectangle.Value;
                if (rectangle.X == 0 && rectangle.Y == 0 &&
                    rectangle.Width > 0 && rectangle.Height > 0 &&
                    rectangle.Width == texture.Width && rectangle.Height == texture.Height)
                {
                    sourceX = 0f;
                    sourceY = 0f;
                    num = 1f;
                    num2 = 1f;
                }
                else
                {
                    sourceX = (float)rectangle.X / (float)texture.Width;
                    sourceY = (float)rectangle.Y / (float)texture.Height;
                    num = (float)Math.Sign(rectangle.Width) *
                        Math.Max(Math.Abs(rectangle.Width), machineEpsilonFloat) / (float)texture.Width;
                    num2 = (float)Math.Sign(rectangle.Height) *
                        Math.Max(Math.Abs(rectangle.Height), machineEpsilonFloat) / (float)texture.Height;
                }

                scale.X *= rectangle.Width;
                scale.Y *= rectangle.Height;
            }
            else
            {
                sourceX = 0f;
                sourceY = 0f;
                num = 1f;
                num2 = 1f;
                scale.X *= texture.Width;
                scale.Y *= texture.Height;
            }

            PushSprite(texture, sourceX, sourceY, num, num2, position.X, position.Y, scale.X, scale.Y, color,
                origin.X / num / (float)texture.Width, origin.Y / num2 / (float)texture.Height,
                rotation == 0f ? rotation : (float)Math.Sin(rotation),
                rotation == 0f ? 1f : (float)Math.Cos(rotation), layerDepth,
                (byte)(effects & (SourceSpriteEffects.FlipHorizontally | SourceSpriteEffects.FlipVertically)));
        }

        public void Draw(SourceTexture2DResource texture, IntRect destinationRectangle, uint color)
        {
            CheckBegin("Draw");
            PushSprite(texture, 0f, 0f, 1f, 1f, destinationRectangle.X, destinationRectangle.Y,
                destinationRectangle.Width,
                destinationRectangle.Height, color, 0f, 0f, 0f, 1f, 0f, 0);
        }

        public void Draw(SourceTexture2DResource texture, IntRect destinationRectangle, IntRect? sourceRectangle,
            uint color)
        {
            CheckBegin("Draw");
            float sourceX;
            float sourceY;
            float sourceW;
            float sourceH;
            if (sourceRectangle.HasValue)
            {
                sourceX = (float)sourceRectangle.Value.X / (float)texture.Width;
                sourceY = (float)sourceRectangle.Value.Y / (float)texture.Height;
                sourceW = (float)sourceRectangle.Value.Width / (float)texture.Width;
                sourceH = (float)sourceRectangle.Value.Height / (float)texture.Height;
            }
            else
            {
                sourceX = 0f;
                sourceY = 0f;
                sourceW = 1f;
                sourceH = 1f;
            }

            PushSprite(texture, sourceX, sourceY, sourceW, sourceH, destinationRectangle.X, destinationRectangle.Y,
                destinationRectangle.Width, destinationRectangle.Height, color, 0f, 0f, 0f, 1f, 0f, 0);
        }

        public void Draw(SourceTexture2DResource texture, IntRect destinationRectangle, IntRect? sourceRectangle,
            uint color, float rotation, Vector2 origin, SourceSpriteEffects effects, float layerDepth)
        {
            CheckBegin("Draw");
            float sourceX;
            float sourceY;
            float num;
            float num2;
            if (sourceRectangle.HasValue)
            {
                sourceX = (float)sourceRectangle.Value.X / (float)texture.Width;
                sourceY = (float)sourceRectangle.Value.Y / (float)texture.Height;
                num = (float)Math.Sign(sourceRectangle.Value.Width) *
                    Math.Max(Math.Abs(sourceRectangle.Value.Width), machineEpsilonFloat) / (float)texture.Width;
                num2 = (float)Math.Sign(sourceRectangle.Value.Height) *
                    Math.Max(Math.Abs(sourceRectangle.Value.Height), machineEpsilonFloat) / (float)texture.Height;
            }
            else
            {
                sourceX = 0f;
                sourceY = 0f;
                num = 1f;
                num2 = 1f;
            }

            PushSprite(texture, sourceX, sourceY, num, num2, destinationRectangle.X, destinationRectangle.Y,
                destinationRectangle.Width, destinationRectangle.Height, color, origin.X / num / (float)texture.Width,
                origin.Y / num2 / (float)texture.Height, rotation == 0f ? rotation : (float)Math.Sin(rotation),
                rotation == 0f ? 1f : (float)Math.Cos(rotation),
                layerDepth,
                (byte)(effects & (SourceSpriteEffects.FlipHorizontally | SourceSpriteEffects.FlipVertically)));
        }


        private static readonly float machineEpsilonFloat = GetMachineEpsilonFloat();

        private static float GetMachineEpsilonFloat()
        {
            float value = 1f;
            float sum;
            do
            {
                value *= .5f;
                sum = 1f + value;
            } while (sum > 1f);

            return value;
        }

        private void CheckBegin(string method)
        {
            if (!beginCalled)
                throw new InvalidOperationException(method +
                                                    " was called, but Begin has not yet been called. Begin must be called successfully before you can call " +
                                                    method + ".");
        }
    }
}
