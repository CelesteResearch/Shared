using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Simulation.Gameplay.Actors;
using Celeste.Simulation.Gameplay.Actors.Tracking;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    // JumpThru carries actors before moving itself, unlike Solid. In particular
    // Fall(0) leaves Collidable true, so its descending tile must still carry.
    public sealed class BridgeJumpThruMover
    {
        public readonly CollisionPlatform Platform;
        public Func<IEnumerable<CassetteActor>> Actors;
        public Action<Vector2> MoveStaticMovers;
        public Vector2 Remainder;
        public float DeltaTime = 1f / 60;

        public BridgeJumpThruMover(CollisionPlatform platform)
        {
            Platform = platform;
            if (!platform.IsJumpThru) throw new ArgumentException("JumpThru platform required", nameof(platform));
        }

        public Vector2 ExactPosition => Platform.Position + Remainder;

        // JumpThru inherits the installed Platform target/remainder boundaries.
        public void MoveToX(float x)
        {
            MoveH((float)((double)x - Platform.Position.X - Remainder.X));
        }

        public void MoveToY(float y)
        {
            MoveV((float)((double)y - Platform.Position.Y - Remainder.Y));
        }

        public void MoveTo(Vector2 at)
        {
            MoveToX(at.X);
            MoveToY(at.Y);
        }

        public void MoveTowardsX(float x, float amount)
        {
            MoveToX(ScalarMath.Approach(ExactPosition.X, x, amount));
        }

        public void MoveTowardsY(float y, float amount)
        {
            MoveToY(ScalarMath.Approach(ExactPosition.Y, y, amount));
        }

        public void MoveH(float amount)
        {
            var lift = Platform.LiftSpeed;
            lift.X = DeltaTime == 0 ? 0 : amount / DeltaTime;
            Platform.LiftSpeed = lift;
            Remainder.X += amount;
            var move = (int)Math.Round(Remainder.X);
            if (move == 0) return;
            Remainder.X -= move;
            MoveHExact(move);
        }

        public void MoveV(float amount)
        {
            var lift = Platform.LiftSpeed;
            lift.Y = DeltaTime == 0 ? 0 : amount / DeltaTime;
            Platform.LiftSpeed = lift;
            Remainder.Y += amount;
            var move = (int)Math.Round(Remainder.Y);
            if (move == 0) return;
            Remainder.Y -= move;
            MoveVExact(move);
        }

        private bool Riding(CassetteActor actor)
        {
            return actor.IsRiding?.Invoke(Platform) ?? (actor.HasCollider &&
                                                        !actor.Body.IgnoreJumpThrus &&
                                                        !Platform.Intersects(actor.Bounds) &&
                                                        Platform.Intersects(
                                                            actor.Body.BoundsAt(actor.Body.Position + Vector2.UnitY)));
        }

        private static void Naive(CassetteActor actor, Vector2 amount)
        {
            actor.Body.Remainder += amount;
            var move = new Vector2((int)Math.Round(actor.Body.Remainder.X), (int)Math.Round(actor.Body.Remainder.Y));
            actor.Body.Position += move;
            actor.Body.Remainder -= move;
        }

        public void MoveVExact(int move)
        {
            if (Platform.Collidable && Actors != null)
                foreach (var actor in new ActorIteration(Actors()))
                    if (Riding(actor))
                    {
                        Carry(actor, move);
                    }
                    else if (move < 0 && actor.HasCollider && !actor.TreatNaive && actor.Collidable)
                    {
                        var start = Platform.Position;
                        bool hit;
                        try
                        {
                            Platform.Position = start + Vector2.UnitY * move;
                            hit = Platform.Intersects(actor.Bounds);
                        }
                        finally
                        {
                            Platform.Position = start;
                        }

                        if (hit && !Platform.Intersects(actor.Bounds))
                            Carry(actor, (int)(Platform.BoundingBox.Y + move - actor.Bounds.Bottom));
                    }

            Platform.Position += Vector2.UnitY * move;
            MoveStaticMovers?.Invoke(Vector2.UnitY * move);
            Platform.MoveStaticAttachments(Vector2.UnitY * move);
        }

        private void Carry(CassetteActor actor, int move)
        {
            Platform.Collidable = false;
            try
            {
                if (actor.TreatNaive) Naive(actor, Vector2.UnitY * move);
                else actor.MoveExact(move, true);
                actor.Body.LiftSpeed = Platform.LiftSpeed;
            }
            finally
            {
                Platform.Collidable = true;
            }
        }

        public void MoveHExact(int move)
        {
            if (Platform.Collidable && Actors != null)
                foreach (var actor in new ActorIteration(Actors()))
                    if (Riding(actor))
                    {
                        if (actor.TreatNaive) Naive(actor, Vector2.UnitX * move);
                        else actor.MoveExact(move, false);
                    }

            Platform.Position += Vector2.UnitX * move;
            MoveStaticMovers?.Invoke(Vector2.UnitX * move);
            Platform.MoveStaticAttachments(Vector2.UnitX * move);
        }
    }
}
