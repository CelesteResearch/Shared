using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.Collision;

namespace Celeste.Simulation.Gameplay.Actors
{
    public sealed class CassetteActor
    {
        public readonly PixelActor Body;
        public readonly CassetteActorKind Kind;
        private bool collidable = true;
        public Action<bool> CollidableChanged;

        public bool Collidable
        {
            get => collidable;
            set
            {
                collidable = value;
                CollidableChanged?.Invoke(value);
            }
        }

        public bool AllowPushing = true, TreatNaive, HasCollider = true;
        public Func<CollisionPlatform, bool> IsRiding;
        public Action<Vector2> Moved;
        public Action<PixelCollision, CollisionPlatform> Squish;

        public CassetteActor(PixelActor body, CassetteActorKind kind)
        {
            Body = body;
            Kind = kind;
        }

        public Bounds Bounds => Body.BoundsAt(Body.Position);

        internal void MoveExact(int amount, bool vertical,
            SourceCollisionHandler onCollide = null)
        {
            if (HasCollider)
            {
                if (vertical) Body.MoveVExact(amount, onCollide);
                else Body.MoveHExact(amount, onCollide);
                Moved?.Invoke(Body.Position);
                return;
            }

            // Actor with Collider=null still executes the pixel loop, but every
            // CollideFirst query is false. Keep the original float add grouping.
            var sign = Math.Sign(amount);
            while (amount != 0)
            {
                if (vertical) Body.Position.Y += sign;
                else Body.Position.X += sign;
                amount -= sign;
            }

            Moved?.Invoke(Body.Position);
        }
    }
}
