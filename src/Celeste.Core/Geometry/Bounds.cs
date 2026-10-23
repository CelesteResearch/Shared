using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Core.Geometry
{
    public readonly struct Bounds
    {
        public readonly float X, Y, Width, Height;
        private readonly float right, bottom;
        public float Right => right;
        public float Bottom => bottom;

        public Bounds(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            right = x + width;
            bottom = y + height;
        }

        public Bounds(float x, float y, float width, float height, float right, float bottom)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            this.right = right;
            this.bottom = bottom;
        }

        // Collider.AbsoluteRight/Bottom add Entity.Position AFTER evaluating the
        // local edge. Reconstructing it as absolute-left + width loses that order.
        public global::Celeste.Core.Geometry.Bounds At(Vector2 entityPosition) =>
            new global::Celeste.Core.Geometry.Bounds(X + entityPosition.X, Y + entityPosition.Y,
                Width, Height, right + entityPosition.X, bottom + entityPosition.Y);

        public static global::Celeste.Core.Geometry.Bounds FromEdges(float left, float top, float right, float bottom)
            => new global::Celeste.Core.Geometry.Bounds(left, top, right - left, bottom - top, right, bottom);

        public bool Intersects(global::Celeste.Core.Geometry.Bounds other) =>
            Right > other.X && Bottom > other.Y && X < other.Right && Y < other.Bottom;

        // Hitbox.Collide(point) goes through RectToPoint(AbsoluteLeft, AbsoluteTop,
        // Width, Height), deliberately unlike Hitbox-vs-Hitbox absolute edges.
        public bool Contains(Vector2 point) =>
            point.X >= X && point.Y >= Y && point.X < X + Width && point.Y < Y + Height;
    }
}
