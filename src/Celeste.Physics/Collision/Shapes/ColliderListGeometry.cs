using System;
using System.Linq;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Bounds = Celeste.Core.Geometry.Bounds;

namespace Celeste.Physics.Collision.Shapes
{
    public class ColliderListGeometry : ColliderGeometry
    {
        public ColliderGeometry[] colliders { get; private set; }

        public override float Width
        {
            get => Right - Left;
            set => throw new NotImplementedException();
        }

        public override float Height
        {
            get => Bottom - Top;
            set => throw new NotImplementedException();
        }

        public override float Left
        {
            get
            {
                var left = colliders[0].Left;
                for (var i = 1; i < colliders.Length; i++)
                    if (colliders[i].Left < left)
                        left = colliders[i].Left;

                return left;
            }
            set
            {
                var num = value - Left;
                var array = colliders;
                for (var i = 0; i < array.Length; i++)
                {
                    _ = array[i];
                    Position.X += num;
                }
            }
        }

        public override float Right
        {
            get
            {
                var right = colliders[0].Right;
                for (var i = 1; i < colliders.Length; i++)
                    if (colliders[i].Right > right)
                        right = colliders[i].Right;

                return right;
            }
            set
            {
                var num = value - Right;
                var array = colliders;
                for (var i = 0; i < array.Length; i++)
                {
                    _ = array[i];
                    Position.X += num;
                }
            }
        }

        public override float Top
        {
            get
            {
                var top = colliders[0].Top;
                for (var i = 1; i < colliders.Length; i++)
                    if (colliders[i].Top < top)
                        top = colliders[i].Top;

                return top;
            }
            set
            {
                var num = value - Top;
                var array = colliders;
                for (var i = 0; i < array.Length; i++)
                {
                    _ = array[i];
                    Position.Y += num;
                }
            }
        }

        public override float Bottom
        {
            get
            {
                var bottom = colliders[0].Bottom;
                for (var i = 1; i < colliders.Length; i++)
                    if (colliders[i].Bottom > bottom)
                        bottom = colliders[i].Bottom;

                return bottom;
            }
            set
            {
                var num = value - Bottom;
                var array = colliders;
                for (var i = 0; i < array.Length; i++)
                {
                    _ = array[i];
                    Position.Y += num;
                }
            }
        }

        public ColliderListGeometry(params ColliderGeometry[] colliders)
        {
            this.colliders = colliders;
        }

        public void Add(params ColliderGeometry[] toAdd)
        {
            var array = new ColliderGeometry[colliders.Length + toAdd.Length];
            for (var i = 0; i < colliders.Length; i++) array[i] = colliders[i];

            for (var j = 0; j < toAdd.Length; j++)
            {
                array[j + colliders.Length] = toAdd[j];
                toAdd[j].Added(Entity);
            }

            colliders = array;
        }

        public void Remove(params ColliderGeometry[] toRemove)
        {
            var array = new ColliderGeometry[colliders.Length - toRemove.Length];
            var num = 0;
            var array2 = colliders;
            foreach (var collider in array2)
                if (!toRemove.Contains(collider))
                {
                    array[num] = collider;
                    num++;
                }

            colliders = array;
        }

        public override void Added(ISourceEntityCollider entity)
        {
            base.Added(entity);
            var array = colliders;
            for (var i = 0; i < array.Length; i++) array[i].Added(entity);
        }

        public override void Removed()
        {
            base.Removed();
            var array = colliders;
            for (var i = 0; i < array.Length; i++) array[i].Removed();
        }

        public override ColliderGeometry Clone()
        {
            var array = new ColliderGeometry[colliders.Length];
            for (var i = 0; i < colliders.Length; i++) array[i] = colliders[i].Clone();

            return new ColliderListGeometry(array);
        }

        public override void Render(object camera, PackedColor color,
            ISourceRenderContext context)
        {
            var array = colliders;
            for (var i = 0; i < array.Length; i++)
                array[i].Render(camera, color, context);
        }

        public override bool Overlaps(Bounds rectangle, Vector2 entityPosition)
        {
            foreach (var collider in colliders)
                if (collider.Overlaps(rectangle, entityPosition))
                    return true;
            return false;
        }

        public override bool CollideHitbox(Bounds absoluteHitbox)
        {
            foreach (var collider in colliders)
                if (collider.CollideHitbox(absoluteHitbox))
                    return true;
            return false;
        }

        public override bool Collide(Vector2 point)
        {
            var array = colliders;
            for (var i = 0; i < array.Length; i++)
                if (array[i].Collide(point))
                    return true;

            return false;
        }

        public override bool Collide(IntRect rect)
        {
            var array = colliders;
            for (var i = 0; i < array.Length; i++)
                if (array[i].Collide(rect))
                    return true;

            return false;
        }

        public override bool Collide(Vector2 from, Vector2 to)
        {
            var array = colliders;
            for (var i = 0; i < array.Length; i++)
                if (array[i].Collide(from, to))
                    return true;

            return false;
        }

        public override bool Collide(HitboxColliderGeometry hitbox)
        {
            var array = colliders;
            for (var i = 0; i < array.Length; i++)
                if (array[i].Collide(hitbox))
                    return true;

            return false;
        }

        public override bool Collide(GridColliderGeometry grid)
        {
            var array = colliders;
            for (var i = 0; i < array.Length; i++)
                if (array[i].Collide(grid))
                    return true;

            return false;
        }

        public override bool Collide(CircleColliderGeometry circle)
        {
            var array = colliders;
            for (var i = 0; i < array.Length; i++)
                if (array[i].Collide(circle))
                    return true;

            return false;
        }

        public override bool Collide(ColliderListGeometry list)
        {
            var array = colliders;
            for (var i = 0; i < array.Length; i++)
                if (array[i].Collide(list))
                    return true;

            return false;
        }
    }
}
