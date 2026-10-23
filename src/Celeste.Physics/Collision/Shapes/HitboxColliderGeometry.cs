using Celeste.Core.Display;
using System;
using System.Numerics;
using Bounds = Celeste.Core.Geometry.Bounds;

namespace Celeste.Physics.Collision.Shapes
{
    public sealed class HitboxColliderGeometry : ColliderGeometry
    {
        public float HitboxWidth, HitboxHeight;

        public HitboxColliderGeometry(float width, float height, float x = 0, float y = 0)
        {
            HitboxWidth = width;
            HitboxHeight = height;
            Position = new Vector2(x, y);
        }

        public override float Width
        {
            get => HitboxWidth;
            set => HitboxWidth = value;
        }

        public override float Height
        {
            get => HitboxHeight;
            set => HitboxHeight = value;
        }

        public global::Celeste.Core.Geometry.Bounds LocalBounds =>
            new global::Celeste.Core.Geometry.Bounds(Position.X, Position.Y, HitboxWidth, HitboxHeight);

        public override float Left
        {
            get => Position.X;
            set => Position.X = value;
        }

        public override float Right
        {
            get => Position.X + Width;
            set => Position.X = value - Width;
        }

        public override float Top
        {
            get => Position.Y;
            set => Position.Y = value;
        }

        public override float Bottom
        {
            get => Position.Y + Height;
            set => Position.Y = value - Height;
        }

        public override bool Collide(HitboxColliderGeometry hitbox)
        {
            if (AbsoluteLeft < hitbox.AbsoluteRight && AbsoluteRight > hitbox.AbsoluteLeft &&
                AbsoluteBottom > hitbox.AbsoluteTop)
                return AbsoluteTop < hitbox.AbsoluteBottom;
            return false;
        }

        public override bool Collide(CircleColliderGeometry circle)
        {
            return SourceCollisionMath.RectToCircle(AbsoluteLeft, AbsoluteTop, Width, Height,
                circle.AbsolutePosition, circle.Radius, circle.Arithmetic);
        }

        public override ColliderGeometry Clone()
        {
            return new HitboxColliderGeometry(HitboxWidth, HitboxHeight, Position.X, Position.Y);
        }

        public override bool Collide(Vector2 point)
        {
            return SourceCollisionMath.RectToPoint(base.AbsoluteLeft, base.AbsoluteTop, Width, Height, point);
        }

        public override bool Collide(global::Celeste.Core.Geometry.IntRect rect)
        {
            if (base.AbsoluteRight > (float)rect.Left && base.AbsoluteBottom > (float)rect.Top &&
                base.AbsoluteLeft < (float)rect.Right)
            {
                return base.AbsoluteTop < (float)rect.Bottom;
            }

            return false;
        }

        public override bool Collide(Vector2 from, Vector2 to)
        {
            return SourceCollisionMath.RectToLine(base.AbsoluteLeft, base.AbsoluteTop, Width, Height, from, to);
        }

        public override bool Collide(GridColliderGeometry grid)
        {
            return grid.Collide(base.Bounds);
        }

        public override bool Collide(ColliderListGeometry list)
        {
            return list.Collide(this);
        }

        public override bool CollideHitbox(Bounds absoluteHitbox)
            => AbsoluteLeft < absoluteHitbox.Right && AbsoluteRight > absoluteHitbox.X &&
               AbsoluteBottom > absoluteHitbox.Y && AbsoluteTop < absoluteHitbox.Bottom;

        public override void Render(object camera, global::Celeste.Core.Display.PackedColor color,
            global::Celeste.Core.Rendering.ISourceRenderContext context)
            => global::Celeste.Graphics.Rendering.SourcePrimitiveDrawing.HollowRect(context, Entity,
                AbsoluteX, AbsoluteY, Width, Height, color);

        public override bool Overlaps(global::Celeste.Core.Geometry.Bounds otherBounds, Vector2 entityPosition)
            => LocalBounds.At(entityPosition).Intersects(otherBounds);
    }
}
