using Celeste.Core.Display;
using System;
using System.Numerics;

namespace Celeste.Physics.Collision.Shapes
{
    // Local Monocle Collider geometry. Shape values are mutable because TAS Lua
    // may write fields on PlayerCollider.Collider, rather than replace the field.
    // No Unity types or host collision callbacks belong in this model.
    public abstract class ColliderGeometry
    {
        public Vector2 Position;
        public global::Celeste.Physics.Collision.ISourceEntityCollider Entity { get; private set; }

        // Monocle.Collider.Added/Removed are the Entity.Collider setter's calls.
        public virtual void Added(global::Celeste.Physics.Collision.ISourceEntityCollider entity) => Entity = entity;

        public virtual void Removed() => Entity = null;

        // Direct writes to the original Collider.Entity backing field do not
        // run Added/Removed or attach this shape as the target Entity.Collider.
        public void SetRawEntity(global::Celeste.Physics.Collision.ISourceEntityCollider entity) => Entity = entity;
        public abstract float Width { get; set; }
        public abstract float Height { get; set; }
        public abstract float Left { get; set; }
        public abstract float Right { get; set; }
        public abstract float Top { get; set; }
        public abstract float Bottom { get; set; }

        public float CenterX
        {
            get => Left + Width / 2f;
            set => Left = value - Width / 2f;
        }

        public float CenterY
        {
            get => Top + Height / 2f;
            set => Top = value - Height / 2f;
        }

        public Vector2 TopLeft
        {
            get => new Vector2(Left, Top);
            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }

        public Vector2 TopCenter
        {
            get => new Vector2(CenterX, Top);
            set
            {
                CenterX = value.X;
                Top = value.Y;
            }
        }

        public Vector2 TopRight
        {
            get => new Vector2(Right, Top);
            set
            {
                Right = value.X;
                Top = value.Y;
            }
        }

        public Vector2 CenterLeft
        {
            get => new Vector2(Left, CenterY);
            set
            {
                Left = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 Center
        {
            get => new Vector2(CenterX, CenterY);
            set
            {
                CenterX = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 Size => new Vector2(Width, Height);
        public Vector2 HalfSize => Size * 0.5f;

        public Vector2 CenterRight
        {
            get => new Vector2(Right, CenterY);
            set
            {
                Right = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 BottomLeft
        {
            get => new Vector2(Left, Bottom);
            set
            {
                Left = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 BottomCenter
        {
            get => new Vector2(CenterX, Bottom);
            set
            {
                CenterX = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 BottomRight
        {
            get => new Vector2(Right, Bottom);
            set
            {
                Right = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 AbsolutePosition => Entity != null ? Entity.Position + Position : Position;
        public float AbsoluteX => Entity != null ? Entity.Position.X + Position.X : Position.X;
        public float AbsoluteY => Entity != null ? Entity.Position.Y + Position.Y : Position.Y;
        public float AbsoluteLeft => Entity != null ? Left + Entity.Position.X : Left;
        public float AbsoluteRight => Entity != null ? Right + Entity.Position.X : Right;
        public float AbsoluteTop => Entity != null ? Top + Entity.Position.Y : Top;

        public float AbsoluteBottom => Entity != null ? Bottom + Entity.Position.Y : Bottom;

        // Monocle.Collider.Bounds is an integer rectangle; truncate each source
        // value independently, including negative coordinates (not Floor).
        public global::Celeste.Core.Geometry.IntRect Bounds => new global::Celeste.Core.Geometry.IntRect(
            (int)AbsoluteLeft, (int)AbsoluteTop, (int)Width, (int)Height);

        public virtual bool Collide(ColliderGeometry collider)
        {
            if (collider is HitboxColliderGeometry hitbox) return Collide(hitbox);
            if (collider is GridColliderGeometry grid) return Collide(grid);
            if (collider is ColliderListGeometry list) return Collide(list);
            if (collider is CircleColliderGeometry circle) return Collide(circle);
            throw new Exception("Collisions against the collider type are not implemented!");
        }

        public virtual bool Collide(HitboxColliderGeometry hitbox)
            => throw new Exception("Collisions against the collider type are not implemented!");

        public virtual bool Collide(CircleColliderGeometry circle)
            => throw new Exception("Collisions against the collider type are not implemented!");

        public virtual bool Collide(GridColliderGeometry grid)
            => throw new Exception("Collisions against the collider type are not implemented!");

        public virtual bool Collide(ColliderListGeometry list) => list.Collide(this);
        public abstract bool Collide(Vector2 point);
        public abstract bool Collide(global::Celeste.Core.Geometry.IntRect rectangle);

        public virtual bool Collide(global::Celeste.Core.Geometry.Bounds rectangle)
            => Collide(new global::Celeste.Core.Geometry.IntRect((int)rectangle.X, (int)rectangle.Y,
                (int)rectangle.Width, (int)rectangle.Height));

        public abstract bool Collide(Vector2 from, Vector2 to);
        public abstract bool CollideHitbox(global::Celeste.Core.Geometry.Bounds absoluteHitbox);
        public abstract ColliderGeometry Clone();

        public abstract void Render(object camera, global::Celeste.Core.Display.PackedColor color,
            global::Celeste.Core.Rendering.ISourceRenderContext context);

        public abstract bool Overlaps(global::Celeste.Core.Geometry.Bounds otherBounds, Vector2 entityPosition);
    }
}
