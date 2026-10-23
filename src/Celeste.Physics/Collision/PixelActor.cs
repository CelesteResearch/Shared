using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Physics.Collision
{
    // Actor.MoveH/MoveV/MoveHExact/MoveVExact: subpixel accumulation with banker's rounding,
    // horizontal movement before vertical movement, strict overlap, one-way platforms on descent.
    public class PixelActor
    {
        public Vector2 Position;
        public Vector2 Remainder;
        private global::Celeste.Core.Geometry.Bounds standaloneHitbox;
        public ISourceEntityCollider SourceColliderOwner;

        public global::Celeste.Core.Geometry.Bounds Hitbox
        {
            get
            {
                if (SourceColliderOwner == null) return standaloneHitbox;
                var shape = SourceColliderOwner.Collider;
                return shape == null
                    ? default
                    : new global::Celeste.Core.Geometry.Bounds(shape.Left, shape.Top, shape.Width, shape.Height,
                        shape.Right, shape.Bottom);
            }
            set
            {
                if (SourceColliderOwner != null)
                    throw new InvalidOperationException(
                        "Set the actual entity Collider rather than a copied actor rectangle.");
                standaloneHitbox = value;
            }
        }

        public bool IgnoreJumpThrus;
        public float LiftSpeedGraceTime;
        private Vector2 currentLiftSpeed, lastLiftSpeed;

        private float liftSpeedTimer;

        // Exact live Actor fields for external watch/debug adapters. Exposing the
        // stored values avoids reconstructing grace state from the LiftSpeed getter.
        public Vector2 CurrentLiftSpeed => currentLiftSpeed;
        public Vector2 LastLiftSpeed => lastLiftSpeed;
        public float LiftSpeedTimer => liftSpeedTimer;

        public Vector2 LiftSpeed
        {
            get => currentLiftSpeed == Vector2.Zero ? lastLiftSpeed : currentLiftSpeed;
            set
            {
                currentLiftSpeed = value;
                if (value != Vector2.Zero && LiftSpeedGraceTime > 0f)
                {
                    lastLiftSpeed = value;
                    liftSpeedTimer = LiftSpeedGraceTime;
                }
            }
        }

        // Actor.Update performs this after updating its components, including the state machine.
        public void FinishComponentUpdate(float deltaTime)
        {
            LiftSpeed = Vector2.Zero;
            if (liftSpeedTimer > 0f)
            {
                liftSpeedTimer -= deltaTime;
                if (liftSpeedTimer <= 0f) lastLiftSpeed = Vector2.Zero;
            }
        }

        public void ResetLiftSpeed()
        {
            currentLiftSpeed = lastLiftSpeed = Vector2.Zero;
            liftSpeedTimer = 0f;
        }

        private readonly ICollisionWorld standaloneWorld;

        public ICollisionWorld World => SourceColliderOwner is ISourceActorCollisionWorldProvider source
            ? source.CollisionWorld
            : standaloneWorld;

        public Vector2 ExactPosition => Position + Remainder;

        // Actor.cs:30 / :156-164. The sub-pixel part is a separate quantity, never folded into Position.
        public Vector2 PositionRemainder => Remainder;
        public void ZeroRemainderX() => Remainder.X = 0;
        public void ZeroRemainderY() => Remainder.Y = 0;

        public global::Celeste.Core.Geometry.Bounds BoundsAt(Vector2 position)
        {
            if (SourceColliderOwner == null) return standaloneHitbox.At(position);
            var shape = SourceColliderOwner.Collider;
            if (shape == null) return new global::Celeste.Core.Geometry.Bounds(position.X, position.Y, 0, 0);
            var origin = ReferenceEquals(shape.Entity, SourceColliderOwner)
                ? position
                : shape.Entity?.Position ?? Vector2.Zero;
            return new global::Celeste.Core.Geometry.Bounds(shape.Left + origin.X, shape.Top + origin.Y,
                shape.Width, shape.Height, shape.Right + origin.X, shape.Bottom + origin.Y);
        }

        public PixelActor(ICollisionWorld world, Vector2 position,
            global::Celeste.Core.Geometry.Bounds hitbox = default, float liftSpeedGraceTime = 0)
        {
            Hitbox = hitbox;
            LiftSpeedGraceTime = liftSpeedGraceTime;
            standaloneWorld = world;
            Position = position;
        }

        // Actor.NaiveMove (Original/Celeste/Actor.cs:305-312):
        //     movementCounter += amount;
        //     int num = (int)Math.Round(movementCounter.X); int num2 = (int)Math.Round(movementCounter.Y);
        //     Position += new Vector2(num, num2); movementCounter -= new Vector2(num, num2);
        // Position therefore only ever moves by WHOLE pixels and stays integral; the fraction is carried
        // in Remainder and surfaces only through ExactPosition. That split is load-bearing for collision,
        // not cosmetic: Monocle builds collider rectangles by truncating to int
        // (Original/Monocle/Collider.cs:253 `new Rectangle((int)AbsoluteLeft, ...)`), and (int) truncates
        // toward zero, so a fractional Position puts the collider on a different pixel than the original -
        // -39.6 truncates to -39 where -40 stays -40, a whole pixel of displacement on the negative side,
        // which is exactly where CS06_Campfire's NaiveMove drives the player. The port previously did a
        // raw fractional Position write here (RoomPresentation.NpcVariants.cs:1367), losing that.
        // Rounding is part of the contract: the original's single-argument Math.Round is banker's rounding
        // (MidpointRounding.ToEven), so .5 ties go to even, matching MoveH/MoveV below.
        private ISourceActorCollisionWorld SourceWorld => World as ISourceActorCollisionWorld
                                                          ?? throw new InvalidOperationException(
                                                              "An actual source Actor requires shape-aware scene collision queries.");

        public bool CollideSolidAt(Vector2 at) => SolidAt(at, out _);

        public bool CollideJumpThruAt(Vector2 at)
        {
            if (SourceColliderOwner != null) return SourceWorld.FirstJumpThruAt(this, at) != null;
            return World.JumpThruAt(BoundsAt(at));
        }

        public bool CollideJumpThruOutside(Vector2 at) => JumpThruOutside(at, out _);

        private bool SolidAt(Vector2 at, out PixelPlatform hit)
        {
            if (SourceColliderOwner != null)
            {
                hit = SourceWorld.FirstSolidAt(this, at);
                return hit != null;
            }

            var bounds = BoundsAt(at);
            if (World is IDetailedCollisionWorld detailed)
            {
                hit = detailed.FirstSolidAt(bounds);
                return hit != null;
            }

            hit = null;
            return World.SolidAt(bounds);
        }

        private bool JumpThruOutside(Vector2 at, out PixelPlatform hit)
        {
            if (SourceColliderOwner != null)
            {
                hit = SourceWorld.FirstJumpThruOutside(this, at);
                return hit != null;
            }

            var bounds = BoundsAt(at);
            var previous = BoundsAt(Position);
            if (World is IDetailedCollisionWorld detailed)
            {
                hit = detailed.FirstJumpThruOutside(bounds, previous);
                return hit != null;
            }

            hit = null;
            return World.JumpThruAt(bounds, previous);
        }

        // Installed Celeste/Everest Actor.MoveToX/Y preserves the two subtractions
        // in double precision, then rounds the movement amount once to float.
        // Subtracting the float ExactPosition first loses low bits during transitions.
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool MoveHExact(int amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null,
            ISourceEntityCollider pusher = null)
        {
            var target = Position + new Vector2(amount, 0);
            int sign = Math.Sign(amount), moved = 0;
            while (amount != 0)
            {
                if (SolidAt(Position + new Vector2(sign, 0), out var hit))
                {
                    Remainder.X = 0;
                    onCollide?.Invoke(new PixelCollision(new Vector2(sign, 0), new Vector2(moved, 0), target,
                        hit.SourceEntityOwner, pusher));
                    return true;
                }

                Position.X += sign;
                moved += sign;
                amount -= sign;
            }

            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool MoveVExact(int amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null,
            ISourceEntityCollider pusher = null)
        {
            var target = Position + new Vector2(0, amount);
            int sign = Math.Sign(amount), moved = 0;
            while (amount != 0)
            {
                Vector2 next = Position + new Vector2(0, sign);
                if (SolidAt(next, out var hit) ||
                    (sign > 0 && !IgnoreJumpThrus && JumpThruOutside(next, out hit)))
                {
                    Remainder.Y = 0;
                    onCollide?.Invoke(new PixelCollision(new Vector2(0, sign), new Vector2(0, moved), target,
                        hit.SourceEntityOwner, pusher));
                    return true;
                }

                Position.Y += sign;
                moved += sign;
                amount -= sign;
            }

            return false;
        }
    }
}
