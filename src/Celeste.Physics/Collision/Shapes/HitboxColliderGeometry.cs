using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
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
            Position = new(x, y);
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

        public Bounds LocalBounds => new(Position.X, Position.Y, HitboxWidth, HitboxHeight);

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
            return SourceCollisionMath.RectToPoint(AbsoluteLeft, AbsoluteTop, Width, Height, point);
        }

        public override bool Collide(IntRect rect)
        {
            if (AbsoluteRight > rect.Left && AbsoluteBottom > rect.Top &&
                AbsoluteLeft < rect.Right)
                return AbsoluteTop < rect.Bottom;

            return false;
        }

        public override bool Collide(Vector2 from, Vector2 to)
        {
            return SourceCollisionMath.RectToLine(AbsoluteLeft, AbsoluteTop, Width, Height, from, to);
        }

        public override bool Collide(GridColliderGeometry grid)
        {
            return grid.Collide(Bounds);
        }

        public override bool Collide(ColliderListGeometry list)
        {
            return list.Collide(this);
        }

        public override bool CollideHitbox(Bounds absoluteHitbox)
        {
            return AbsoluteLeft < absoluteHitbox.Right && AbsoluteRight > absoluteHitbox.X &&
                   AbsoluteBottom > absoluteHitbox.Y && AbsoluteTop < absoluteHitbox.Bottom;
        }

        public override void Render(object camera, PackedColor color,
            ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.HollowRect(context, Entity,
                AbsoluteX, AbsoluteY, Width, Height, color);
        }

        public override bool Overlaps(Bounds otherBounds, Vector2 entityPosition)
        {
            return LocalBounds.At(entityPosition).Intersects(otherBounds);
        }
    }
}
