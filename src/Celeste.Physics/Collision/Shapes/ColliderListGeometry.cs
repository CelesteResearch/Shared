using Celeste.Core.Display;
using System;
using System.Linq;
using System.Numerics;
using Celeste.Core.Collections;
using Bounds = Celeste.Core.Geometry.Bounds;

namespace Celeste.Physics.Collision.Shapes
{
    public class ColliderListGeometry : ColliderGeometry
    {
        public ColliderGeometry[] colliders { get; private set; }

        public override float Width
        {
            get { return Right - Left; }
            set { throw new NotImplementedException(); }
        }

        public override float Height
        {
            get { return Bottom - Top; }
            set { throw new NotImplementedException(); }
        }

        public override float Left
        {
            get
            {
                float left = colliders[0].Left;
                for (int i = 1; i < colliders.Length; i++)
                {
                    if (colliders[i].Left < left)
                    {
                        left = colliders[i].Left;
                    }
                }

                return left;
            }
            set
            {
                float num = value - Left;
                ColliderGeometry[] array = colliders;
                for (int i = 0; i < array.Length; i++)
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
                float right = colliders[0].Right;
                for (int i = 1; i < colliders.Length; i++)
                {
                    if (colliders[i].Right > right)
                    {
                        right = colliders[i].Right;
                    }
                }

                return right;
            }
            set
            {
                float num = value - Right;
                ColliderGeometry[] array = colliders;
                for (int i = 0; i < array.Length; i++)
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
                float top = colliders[0].Top;
                for (int i = 1; i < colliders.Length; i++)
                {
                    if (colliders[i].Top < top)
                    {
                        top = colliders[i].Top;
                    }
                }

                return top;
            }
            set
            {
                float num = value - Top;
                ColliderGeometry[] array = colliders;
                for (int i = 0; i < array.Length; i++)
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
                float bottom = colliders[0].Bottom;
                for (int i = 1; i < colliders.Length; i++)
                {
                    if (colliders[i].Bottom > bottom)
                    {
                        bottom = colliders[i].Bottom;
                    }
                }

                return bottom;
            }
            set
            {
                float num = value - Bottom;
                ColliderGeometry[] array = colliders;
                for (int i = 0; i < array.Length; i++)
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
            ColliderGeometry[] array = new ColliderGeometry[colliders.Length + toAdd.Length];
            for (int i = 0; i < colliders.Length; i++)
            {
                array[i] = colliders[i];
            }

            for (int j = 0; j < toAdd.Length; j++)
            {
                array[j + colliders.Length] = toAdd[j];
                toAdd[j].Added(base.Entity);
            }

            colliders = array;
        }

        public void Remove(params ColliderGeometry[] toRemove)
        {
            ColliderGeometry[] array = new ColliderGeometry[colliders.Length - toRemove.Length];
            int num = 0;
            ColliderGeometry[] array2 = colliders;
            foreach (ColliderGeometry collider in array2)
            {
                if (!toRemove.Contains(collider))
                {
                    array[num] = collider;
                    num++;
                }
            }

            colliders = array;
        }

        public override void Added(global::Celeste.Physics.Collision.ISourceEntityCollider entity)
        {
            base.Added(entity);
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Added(entity);
            }
        }

        public override void Removed()
        {
            base.Removed();
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Removed();
            }
        }

        public override ColliderGeometry Clone()
        {
            ColliderGeometry[] array = new ColliderGeometry[colliders.Length];
            for (int i = 0; i < colliders.Length; i++)
            {
                array[i] = colliders[i].Clone();
            }

            return new ColliderListGeometry(array);
        }

        public override void Render(object camera, global::Celeste.Core.Display.PackedColor color,
            global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
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
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Collide(point))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Collide(global::Celeste.Core.Geometry.IntRect rect)
        {
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Collide(rect))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Collide(Vector2 from, Vector2 to)
        {
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Collide(from, to))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Collide(HitboxColliderGeometry hitbox)
        {
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Collide(hitbox))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Collide(GridColliderGeometry grid)
        {
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Collide(grid))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Collide(CircleColliderGeometry circle)
        {
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Collide(circle))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool Collide(ColliderListGeometry list)
        {
            ColliderGeometry[] array = colliders;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Collide(list))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
