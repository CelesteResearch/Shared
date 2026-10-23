using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;

namespace Celeste.Physics.Collision.Shapes
{
    // Local Monocle Collider geometry. Shape values are mutable because TAS Lua
    // may write fields on PlayerCollider.Collider, rather than replace the field.
    // No Unity types or host collision callbacks belong in this model.
    public abstract class ColliderGeometry
    {
        public Vector2 Position;
        public ISourceEntityCollider Entity { get; private set; }

        // Monocle.Collider.Added/Removed are the Entity.Collider setter's calls.
        public virtual void Added(ISourceEntityCollider entity)
        {
            Entity = entity;
        }

        public virtual void Removed()
        {
            Entity = null;
        }

        // Direct writes to the original Collider.Entity backing field do not
        // run Added/Removed or attach this shape as the target Entity.Collider.
        public void SetRawEntity(ISourceEntityCollider entity)
        {
            Entity = entity;
        }

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
            get => new(Left, Top);
            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }

        public Vector2 TopCenter
        {
            get => new(CenterX, Top);
            set
            {
                CenterX = value.X;
                Top = value.Y;
            }
        }

        public Vector2 TopRight
        {
            get => new(Right, Top);
            set
            {
                Right = value.X;
                Top = value.Y;
            }
        }

        public Vector2 CenterLeft
        {
            get => new(Left, CenterY);
            set
            {
                Left = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 Center
        {
            get => new(CenterX, CenterY);
            set
            {
                CenterX = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 Size => new(Width, Height);
        public Vector2 HalfSize => Size * 0.5f;

        public Vector2 CenterRight
        {
            get => new(Right, CenterY);
            set
            {
                Right = value.X;
                CenterY = value.Y;
            }
        }

        public Vector2 BottomLeft
        {
            get => new(Left, Bottom);
            set
            {
                Left = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 BottomCenter
        {
            get => new(CenterX, Bottom);
            set
            {
                CenterX = value.X;
                Bottom = value.Y;
            }
        }

        public Vector2 BottomRight
        {
            get => new(Right, Bottom);
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
        public IntRect Bounds => new(
            (int)AbsoluteLeft, (int)AbsoluteTop, (int)Width, (int)Height);

        public virtual bool Collide(ColliderGeometry collider)
        {
            if (collider is HitboxColliderGeometry hitbox) return Collide(hitbox);
            if (collider is GridColliderGeometry grid) return Collide(grid);
            if (collider is ColliderListGeometry list) return Collide(list);
            if (collider is CircleColliderGeometry circle) return Collide(circle);
            throw new("Collisions against the collider type are not implemented!");
        }

        public virtual bool Collide(HitboxColliderGeometry hitbox)
        {
            throw new("Collisions against the collider type are not implemented!");
        }

        public virtual bool Collide(CircleColliderGeometry circle)
        {
            throw new("Collisions against the collider type are not implemented!");
        }

        public virtual bool Collide(GridColliderGeometry grid)
        {
            throw new("Collisions against the collider type are not implemented!");
        }

        public virtual bool Collide(ColliderListGeometry list)
        {
            return list.Collide(this);
        }

        public abstract bool Collide(Vector2 point);
        public abstract bool Collide(IntRect rectangle);

        public virtual bool Collide(Bounds rectangle)
        {
            return Collide(new IntRect((int)rectangle.X, (int)rectangle.Y,
                (int)rectangle.Width, (int)rectangle.Height));
        }

        public abstract bool Collide(Vector2 from, Vector2 to);
        public abstract bool CollideHitbox(Bounds absoluteHitbox);
        public abstract ColliderGeometry Clone();

        public abstract void Render(object camera, PackedColor color,
            ISourceRenderContext context);

        public abstract bool Overlaps(Bounds otherBounds, Vector2 entityPosition);
    }
}
