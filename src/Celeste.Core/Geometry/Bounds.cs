using System.Numerics;

namespace Celeste.Core.Geometry
{
    public readonly struct Bounds
    {
        public readonly float X, Y, Width, Height;
        public float Right { get; }
        public float Bottom { get; }

        public Bounds(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Right = x + width;
            Bottom = y + height;
        }

        // ReSharper disable once ConvertToPrimaryConstructor
        public Bounds(float x, float y, float width, float height, float right, float bottom)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Right = right;
            Bottom = bottom;
        }

        // Collider.AbsoluteRight/Bottom add Entity.Position AFTER evaluating the
        // local edge. Reconstructing it as absolute-left + width loses that order.
        public Bounds At(Vector2 entityPosition)
        {
            return new(X + entityPosition.X, Y + entityPosition.Y, Width, Height, Right + entityPosition.X,
                Bottom + entityPosition.Y);
        }

        public static Bounds FromEdges(float left, float top, float right, float bottom)
        {
            return new(left, top, right - left, bottom - top, right, bottom);
        }

        public bool Intersects(Bounds other)
        {
            return Right > other.X && Bottom > other.Y && X < other.Right && Y < other.Bottom;
        }

        // Hitbox.Collide(point) goes through RectToPoint(AbsoluteLeft, AbsoluteTop,
        // Width, Height), deliberately unlike Hitbox-vs-Hitbox absolute edges.
        public bool Contains(Vector2 point)
        {
            return point.X >= X && point.Y >= Y && point.X < X + Width && point.Y < Y + Height;
        }
    }
}
