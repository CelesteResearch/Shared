using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Geometry;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering
{
    public static class SourcePrimitiveDrawing
    {
        public static void Point(ISourceRenderContext context, object actualEntity,
            Vector2 position, PackedColor color)
            => Point((ISourceDrawScope)context, position, color);

        public static void Point(ISourceDrawScope scope, Vector2 position, PackedColor color)
        {
            var draw = scope.Draw;
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                position, draw.Pixel.ClipRect, color.PackedValue, 0f, Vector2.Zero,
                Vector2.One, SourceSpriteEffects.None, 0f);
        }

        public static void Rect(ISourceRenderContext context, object actualEntity,
            float x, float y, float width, float height, PackedColor color)
            => Rect((ISourceDrawScope)context, x, y, width, height, color);

        public static void Rect(ISourceRenderContext context, object actualEntity,
            Vector2 position, float width, float height, PackedColor color)
            => Rect((ISourceDrawScope)context, position.X, position.Y, width, height, color);

        public static void Rect(ISourceDrawScope scope,
            float x, float y, float width, float height, PackedColor color)
        {
            var draw = scope.Draw;
            draw.Rectangle.X = (int)x;
            draw.Rectangle.Y = (int)y;
            draw.Rectangle.Width = (int)width;
            draw.Rectangle.Height = (int)height;
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                draw.Rectangle, draw.Pixel.ClipRect, color.PackedValue);
        }

        public static void Rect(ISourceDrawScope scope, IntRect rectangle, PackedColor color)
        {
            var draw = scope.Draw;
            draw.Rectangle = rectangle;
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                rectangle, draw.Pixel.ClipRect, color.PackedValue);
        }

        public static void HollowRect(ISourceRenderContext context, object actualEntity,
            float x, float y, float width, float height, PackedColor color)
            => HollowRect((ISourceDrawScope)context, x, y, width, height, color);

        public static void HollowRect(ISourceDrawScope scope,
            float x, float y, float width, float height, PackedColor color)
            => scope.Draw.HollowRect(x, y, width, height, color);

        public static void Line(ISourceRenderContext context, object actualEntity,
            Vector2 start, Vector2 end, PackedColor color, ISourceVectorArithmetic arithmetic)
            => Line((ISourceDrawScope)context, start, end, color, arithmetic);

        public static void Line(ISourceDrawScope scope,
            Vector2 start, Vector2 end, PackedColor color, ISourceVectorArithmetic arithmetic)
        {
            var angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
            LineAngle(scope, start, angle, arithmetic.Distance(start, end), color);
        }

        public static void Line(ISourceDrawScope scope,
            float x1, float y1, float x2, float y2, PackedColor color, ISourceVectorArithmetic arithmetic)
            => Line(scope, new Vector2(x1, y1), new Vector2(x2, y2), color, arithmetic);

        public static void Line(ISourceDrawScope scope,
            Vector2 start, Vector2 end, PackedColor color, float thickness, ISourceVectorArithmetic arithmetic)
        {
            var angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
            LineAngle(scope, start, angle, arithmetic.Distance(start, end), color, thickness);
        }

        public static void LineAngle(ISourceDrawScope scope,
            Vector2 start, float angle, float length, PackedColor color)
        {
            var draw = scope.Draw;
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                start, draw.Pixel.ClipRect, color.PackedValue, angle, Vector2.Zero,
                new Vector2(length, 1f), SourceSpriteEffects.None, 0f);
        }

        public static void LineAngle(ISourceDrawScope scope,
            Vector2 start, float angle, float length, PackedColor color, float thickness)
        {
            var draw = scope.Draw;
            draw.SpriteBatch.Draw((SourceTexture2DResource)draw.Pixel.Texture.TextureSafe,
                start, draw.Pixel.ClipRect, color.PackedValue, angle, new Vector2(0f, .5f),
                new Vector2(length, thickness), SourceSpriteEffects.None, 0f);
        }

        public static void HollowRect(ISourceRenderContext context, object actualEntity,
            Vector2 position, float width, float height, PackedColor color)
            => HollowRect((ISourceDrawScope)context, position.X, position.Y, width, height, color);

        public static void HollowRect(ISourceRenderContext context, object actualEntity,
            IntRect rectangle, PackedColor color)
            => HollowRect((ISourceDrawScope)context, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height,
                color);

        public static void Line(ISourceRenderContext context, object actualEntity,
            Vector2 start, Vector2 end, PackedColor color, float thickness, ISourceVectorArithmetic arithmetic)
            => Line((ISourceDrawScope)context, start, end, color, thickness, arithmetic);

        public static void LineAngle(ISourceRenderContext context, object actualEntity,
            Vector2 start, float angle, float length, PackedColor color)
            => LineAngle((ISourceDrawScope)context, start, angle, length, color);

        public static void LineAngle(ISourceRenderContext context, object actualEntity,
            Vector2 start, float angle, float length, PackedColor color, float thickness)
            => LineAngle((ISourceDrawScope)context, start, angle, length, color, thickness);

        public static void Circle(ISourceDrawScope scope, Vector2 position, float radius,
            PackedColor color, int resolution, ISourceVectorArithmetic arithmetic)
        {
            Vector2 vector = Vector2.UnitX * radius;
            Vector2 vector2 = Vector2Geometry.Perpendicular(vector);
            for (int i = 1; i <= resolution; i++)
            {
                Vector2 vector3 =
                    Vector2Geometry.AngleToVector((float)i * ((float)Math.PI / 2f) / (float)resolution, radius);
                Vector2 vector4 = Vector2Geometry.Perpendicular(vector3);
                Line(scope, position + vector, position + vector3, color, arithmetic);
                Line(scope, position - vector, position - vector3, color, arithmetic);
                Line(scope, position + vector2, position + vector4, color, arithmetic);
                Line(scope, position - vector2, position - vector4, color, arithmetic);
                vector = vector3;
                vector2 = vector4;
            }
        }

        public static void Circle(ISourceDrawScope scope, float x, float y, float radius,
            PackedColor color, int resolution, ISourceVectorArithmetic arithmetic)
            => Circle(scope, new Vector2(x, y), radius, color, resolution, arithmetic);

        public static void Circle(ISourceRenderContext context, object actualEntity,
            Vector2 position, float radius, PackedColor color, int resolution, ISourceVectorArithmetic arithmetic)
            => Circle((ISourceDrawScope)context, position, radius, color, resolution, arithmetic);

        public static void Circle(ISourceDrawScope scope, Vector2 position, float radius,
            PackedColor color, float thickness, int resolution, ISourceVectorArithmetic arithmetic)
        {
            Vector2 vector = Vector2.UnitX * radius;
            Vector2 vector2 = Vector2Geometry.Perpendicular(vector);
            for (int i = 1; i <= resolution; i++)
            {
                Vector2 vector3 =
                    Vector2Geometry.AngleToVector((float)i * ((float)Math.PI / 2f) / (float)resolution, radius);
                Vector2 vector4 = Vector2Geometry.Perpendicular(vector3);
                Line(scope, position + vector, position + vector3, color, thickness, arithmetic);
                Line(scope, position - vector, position - vector3, color, thickness, arithmetic);
                Line(scope, position + vector2, position + vector4, color, thickness, arithmetic);
                Line(scope, position - vector2, position - vector4, color, thickness, arithmetic);
                vector = vector3;
                vector2 = vector4;
            }
        }

        public static void Circle(ISourceDrawScope scope, float x, float y, float radius,
            PackedColor color, float thickness, int resolution, ISourceVectorArithmetic arithmetic)
            => Circle(scope, new Vector2(x, y), radius, color, thickness, resolution, arithmetic);

        public static void Circle(ISourceRenderContext context, object actualEntity,
            Vector2 position, float radius, PackedColor color, float thickness, int resolution,
            ISourceVectorArithmetic arithmetic)
            => Circle((ISourceDrawScope)context, position, radius, color, thickness, resolution, arithmetic);
    }
}
