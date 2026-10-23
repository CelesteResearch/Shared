using Celeste.Core.Display;
using System;
using System.Numerics;
using Bounds = Celeste.Core.Geometry.Bounds;

namespace Celeste.Physics.Collision.Shapes
{
    public sealed class CircleColliderGeometry : ColliderGeometry
    {
        public float Radius;
        public global::Celeste.Core.Mathematics.ISourceVectorArithmetic Arithmetic { get; }

        public CircleColliderGeometry(global::Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic, float radius,
            float x = 0, float y = 0)
        {
            Arithmetic = arithmetic;
            Radius = radius;
            Position = new Vector2(x, y);
        }

        public override float Width
        {
            get => Radius * 2f;
            set => Radius = value / 2f;
        }

        public override float Height
        {
            get => Radius * 2f;
            set => Radius = value / 2f;
        }

        public override float Left
        {
            get => Position.X - Radius;
            set => Position.X = value + Radius;
        }

        public override float Right
        {
            get => Position.X + Radius;
            set => Position.X = value - Radius;
        }

        public override float Top
        {
            get => Position.Y - Radius;
            set => Position.Y = value + Radius;
        }

        public override float Bottom
        {
            get => Position.Y + Radius;
            set => Position.Y = value - Radius;
        }

        public override bool Collide(HitboxColliderGeometry hitbox) => hitbox.Collide(this);

        public override bool Collide(CircleColliderGeometry circle)
            => Arithmetic.DistanceSquared(AbsolutePosition, circle.AbsolutePosition) <
               (Radius + circle.Radius) * (Radius + circle.Radius);

        public override ColliderGeometry Clone()
        {
            return new CircleColliderGeometry(Arithmetic, Radius, Position.X, Position.Y);
        }

        public override bool Collide(Vector2 point)
        {
            return SourceCollisionMath.CircleToPoint(base.AbsolutePosition, Radius, point, Arithmetic);
        }

        public override bool Collide(global::Celeste.Core.Geometry.IntRect rect)
        {
            return SourceCollisionMath.RectToCircle(rect, base.AbsolutePosition, Radius, Arithmetic);
        }

        public override bool Collide(Vector2 from, Vector2 to)
        {
            return SourceCollisionMath.CircleToLine(base.AbsolutePosition, Radius, from, to, Arithmetic);
        }

        public override bool Collide(GridColliderGeometry grid)
        {
            return grid.Collide(this);
        }

        public override bool Collide(ColliderListGeometry list)
        {
            return list.Collide(this);
        }

        public override bool CollideHitbox(Bounds absoluteHitbox)
            => SourceCollisionMath.RectToCircle(absoluteHitbox.X, absoluteHitbox.Y,
                absoluteHitbox.Width, absoluteHitbox.Height, AbsolutePosition, Radius, Arithmetic);

        public override void Render(object camera, global::Celeste.Core.Display.PackedColor color,
            global::Celeste.Core.Rendering.ISourceRenderContext context)
            => global::Celeste.Graphics.Rendering.SourcePrimitiveDrawing.Circle(context, Entity,
                AbsolutePosition, Radius, color, 4, Arithmetic);

        public override bool Overlaps(global::Celeste.Core.Geometry.Bounds otherBounds, Vector2 entityPosition)
            => SourceCollisionMath.RectToCircle(otherBounds, entityPosition + Position, Radius, Arithmetic);
    }
}
