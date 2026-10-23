using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Physics.Collision
{
    public struct PixelCollision
    {
        public static readonly PixelCollision Empty = default;

        public Vector2 Direction, Moved, TargetPosition;
        public ISourceEntityCollider Hit;
        public ISourceEntityCollider Pusher;

        public PixelCollision(Vector2 direction, Vector2 moved, Vector2 target, ISourceEntityCollider hit = null,
            ISourceEntityCollider pusher = null)
        {
            Direction = direction;
            Moved = moved;
            TargetPosition = target;
            Hit = hit;
            Pusher = pusher;
        }
    }
}
