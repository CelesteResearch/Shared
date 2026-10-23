using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Actors
{
    public sealed class CassetteActor
    {
        public readonly PixelActor Body;
        public readonly global::Celeste.Simulation.Gameplay.Actors.CassetteActorKind Kind;
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
        public Func<global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform, bool> IsRiding;
        public Action<Vector2> Moved;
        public Action<PixelCollision, global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform> Squish;

        public CassetteActor(PixelActor body, global::Celeste.Simulation.Gameplay.Actors.CassetteActorKind kind)
        {
            Body = body;
            Kind = kind;
        }

        public global::Celeste.Core.Geometry.Bounds Bounds => Body.BoundsAt(Body.Position);

        internal void MoveExact(int amount, bool vertical,
            global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null)
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
            int sign = Math.Sign(amount);
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
