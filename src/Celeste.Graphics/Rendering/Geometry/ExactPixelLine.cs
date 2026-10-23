using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Rendering.Geometry
{
    public static class ExactPixelLine
    {
        // netstandard2.1 lacks MathF.BitIncrement/BitDecrement. Preserve the binary32 successor.
        private static float BitIncrement(float value) => AdjacentFloat(value, true);
        private static float BitDecrement(float value) => AdjacentFloat(value, false);

        private static float AdjacentFloat(float value, bool increment)
        {
            if (float.IsNaN(value) || value == (increment ? float.PositiveInfinity : float.NegativeInfinity))
                return value;
            if (value == 0f) return increment ? float.Epsilon : -float.Epsilon;
            int bits = BitConverter.SingleToInt32Bits(value);
            bits += (value > 0f) == increment ? 1 : -1;
            return BitConverter.Int32BitsToSingle(bits);
        }

        public static void DrawExactLine(Vector2 from, Vector2 to, PackedColor color, IPixelRectangleOutput output)
        {
            // The line endings can touch the right / bottom side of the collider without colliding,
            // because Collide.GetSector uses >= instead of > for those
            int minX = (int)MathF.Floor(Math.Min(from.X, to.X));
            int minY = (int)MathF.Floor(Math.Min(from.Y, to.Y));
            output.Rectangle(MathF.Floor(from.X), MathF.Floor(from.Y), 1f, 1f, color);
            output.Rectangle(MathF.Floor(to.X), MathF.Floor(to.Y), 1f, 1f, color);

            // Straight lines
            if ((int)Math.Floor(from.X) == (int)Math.Floor(to.X))
            {
                int top = Math.Max(minY, (int)MathF.Floor(BitDecrement(Math.Min(from.Y, to.Y))));
                int bottom = Math.Max(minY, (int)MathF.Ceiling(BitIncrement(Math.Max(from.Y, to.Y))));
                output.Rectangle(MathF.Floor(Math.Min(from.X, to.X)), top, 1, bottom - top, color);
                return;
            }

            if ((int)Math.Floor(from.Y) == (int)Math.Floor(to.Y))
            {
                int left = Math.Max(minX, (int)MathF.Floor(BitDecrement(Math.Min(from.X, to.X))));
                int right = Math.Max(minX, (int)MathF.Ceiling(BitIncrement(Math.Max(from.X, to.X))));
                output.Rectangle(left, MathF.Floor(Math.Min(from.Y, to.Y)), right - left, 1, color);
                return;
            }

            float dx = to.X - from.X;
            float dy = to.Y - from.Y;

            bool horizontal = Math.Abs(dx) >= Math.Abs(dy);
            float step = Math.Min(Math.Abs(dx), Math.Abs(dy));
            dx /= step;
            dy /= step;

            // Starting / Ending point might not be integer coordinates
            float startDist = horizontal
                ? Math.Sign(dy) * 0.5f + 0.5f - ScalarMath.Mod(from.Y, 1.0f)
                : Math.Sign(dx) * 0.5f + 0.5f - ScalarMath.Mod(from.X, 1.0f);
            float endDist = horizontal
                ? Math.Sign(dy) * 0.5f + 0.5f - ScalarMath.Mod(1.0f - to.Y, 1.0f)
                : Math.Sign(dx) * 0.5f + 0.5f - ScalarMath.Mod(1.0f - to.X, 1.0f);

            startDist = ScalarMath.Mod(Math.Abs(startDist), 1.0f);
            endDist = ScalarMath.Mod(Math.Abs(endDist), 1.0f);

            float startX = from.X + startDist * dx;
            float startY = from.Y + startDist * dy;
            float endX = to.X - endDist * dx;
            float endY = to.Y - endDist * dy;

            DrawSegment(from.X, from.Y, startX, startY);
            DrawSegment(to.X, to.Y, endX, endY);

            int steps = (int)Math.Min(MathF.Round(Math.Abs(endX - startX)), MathF.Round(Math.Abs(endY - startY)));
            for (int i = 0; i < steps; i++)
            {
                DrawSegment(
                    startX + i * dx,
                    startY + i * dy,
                    startX + (i + 1) * dx,
                    startY + (i + 1) * dy);
            }

            void DrawSegment(float ax, float ay, float bx, float by)
            {
                if (horizontal)
                {
                    int left = Math.Max(minX, (int)MathF.Floor(BitDecrement(Math.Min(ax, bx))));
                    int right = Math.Max(minX, (int)MathF.Ceiling(BitIncrement(Math.Max(ax, bx))));
                    output.Rectangle(left, MathF.Floor(Math.Min(ay, by)), right - left, 1, color);
                }
                else
                {
                    int top = Math.Max(minY, (int)MathF.Floor(BitDecrement(Math.Min(ay, by))));
                    int bottom = Math.Max(minY, (int)MathF.Ceiling(BitIncrement(Math.Max(ay, by))));
                    output.Rectangle(MathF.Floor(Math.Min(ax, bx)), top, 1, bottom - top, color);
                }
            }
        }
    }
}
