using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.Movement
{
    public sealed class SolidPlatformMover
    {
        // Celeste.Solid shares its rider set across instances, including nested moves.
        public readonly CollisionPlatform Platform;
        public readonly PlatformCollisionWorld World;
        public Vector2 Remainder;
        public Vector2 ExactPosition => Platform.Position + Remainder;
        public float DeltaTime = 1f / 60;
        public Action<Vector2> MoveStaticMovers;

        public Action<CollisionPlatform, Vector2, Vector2>
            BreakDashBlock;

        // Predicate: Input.MoveX.Value == Sign(amount) && Sign(player.Speed.X) == Sign(amount).

        public SolidPlatformMover(CollisionPlatform platform,
            PlatformCollisionWorld world)
        {
            Platform = platform;
            World = world;
        }

        public void MoveH(float amount)
        {
            Move(amount, false, false, false);
        }

        public void MoveV(float amount)
        {
            Move(amount, true, false, false);
        }

        public void MoveH(float amount, float liftSpeed)
        {
            Move(amount, false, false, false, liftOverride: liftSpeed);
        }

        public void MoveV(float amount, float liftSpeed)
        {
            Move(amount, true, false, false, liftOverride: liftSpeed);
        }

        // Installed Platform.MoveToX/Y subtract Position and movementCounter
        // separately in double precision, then store the movement amount as Single.
        public void MoveToX(float x)
        {
            MoveH((float)((double)x - Platform.Position.X - Remainder.X));
        }

        public void MoveToY(float y)
        {
            MoveV((float)((double)y - Platform.Position.Y - Remainder.Y));
        }

        public void MoveToX(float x, float liftSpeed)
        {
            MoveH((float)((double)x - Platform.Position.X - Remainder.X), liftSpeed);
        }

        public void MoveToY(float y, float liftSpeed)
        {
            MoveV((float)((double)y - Platform.Position.Y - Remainder.Y), liftSpeed);
        }

        public void MoveTowardsX(float x, float amount)
        {
            MoveToX(ScalarMath.Approach(ExactPosition.X, x, amount));
        }

        public void MoveTowardsY(float y, float amount)
        {
            MoveToY(ScalarMath.Approach(ExactPosition.Y, y, amount));
        }

        public void MoveTo(Vector2 position, Vector2 liftSpeed)
        {
            MoveToX(position.X, liftSpeed.X);
            MoveToY(position.Y, liftSpeed.Y);
        }

        public void MoveTo(Vector2 position)
        {
            MoveToX(position.X);
            MoveToY(position.Y);
        }

        // Preserve an unrounded target through the original Platform.MoveTo
        // subtractions; callers choose any earlier Single storage boundary.
        public void MoveTo(double x, double y)
        {
            MoveH((float)(x - Platform.Position.X - Remainder.X));
            MoveV((float)(y - Platform.Position.Y - Remainder.Y));
        }

        public void MoveToNaive(Vector2 position)
        {
            MoveHNaive((float)((double)position.X - Platform.Position.X - Remainder.X));
            MoveVNaive((float)((double)position.Y - Platform.Position.Y - Remainder.Y));
        }

        public void MoveToNaive(double x, double y)
        {
            MoveHNaive((float)(x - Platform.Position.X - Remainder.X));
            MoveVNaive((float)(y - Platform.Position.Y - Remainder.Y));
        }

        public void MoveHNaive(float amount)
        {
            MoveNaive(amount, false);
        }

        public void MoveVNaive(float amount)
        {
            MoveNaive(amount, true);
        }

        private void MoveNaive(float amount, bool vertical)
        {
            var lift = Platform.LiftSpeed;
            var speed = DeltaTime == 0 ? 0 : amount / DeltaTime;
            if (vertical)
            {
                lift.Y = speed;
                Remainder.Y += amount;
            }
            else
            {
                lift.X = speed;
                Remainder.X += amount;
            }

            Platform.LiftSpeed = lift;
            var move = (int)Math.Round(vertical ? Remainder.Y : Remainder.X);
            if (move == 0) return;
            var position = Platform.Position;
            if (vertical)
            {
                Remainder.Y -= move;
                position.Y += move;
            }
            else
            {
                Remainder.X -= move;
                position.X += move;
            }

            Platform.Position = position;
            var delta = (vertical ? Vector2.UnitY : Vector2.UnitX) * move;
            MoveStaticMovers?.Invoke(delta);
            if (Platform.SourceEntityOwner == null) Platform.MoveStaticAttachments(delta);
        }

        public bool MoveVCollideSolids(float amount, bool thruDashBlocks,
            Action<Vector2, Vector2, CollisionPlatform>
                onCollide = null)
        {
            return Move(amount, true, true, thruDashBlocks, onCollide);
        }

        public bool MoveHCollideSolids(float amount, bool thruDashBlocks,
            Action<Vector2, Vector2, CollisionPlatform>
                onCollide = null)
        {
            return Move(amount, false, true, thruDashBlocks, onCollide);
        }

        public bool MoveHCollideSolidsAndBounds(IntRect bounds, float amount,
            bool thruDashBlocks,
            Action<Vector2, Vector2, CollisionPlatform>
                onCollide = null)
        {
            return Move(amount, false, true, thruDashBlocks, onCollide, roomBounds: bounds);
        }

        public bool MoveVCollideSolidsAndBounds(IntRect bounds, float amount,
            bool thruDashBlocks,
            Action<Vector2, Vector2, CollisionPlatform>
                onCollide = null, bool checkBottom = true)
        {
            return Move(amount, true, true, thruDashBlocks, onCollide, roomBounds: bounds, checkBottom: checkBottom);
        }

        private bool Move(float amount, bool vertical, bool collide, bool thruDashBlocks,
            Action<Vector2, Vector2, CollisionPlatform>
                onCollide = null, float? liftOverride = null,
            IntRect? roomBounds = null, bool checkBottom = true)
        {
            var axis = vertical ? Vector2.UnitY : Vector2.UnitX;
            var lift = Platform.LiftSpeed;
            var speed = liftOverride ?? (DeltaTime == 0 ? 0 : amount / DeltaTime);
            if (vertical) lift.Y = speed;
            else lift.X = speed;
            Platform.LiftSpeed = lift;
            Remainder += axis * amount;
            var move = (int)Math.Round(vertical ? Remainder.Y : Remainder.X);
            if (move == 0) return false;
            Remainder -= axis * move;
            if (!collide)
            {
                MoveExact(move, vertical);
                return false;
            }

            var hitBounds = false;
            if (roomBounds.HasValue)
            {
                var room = roomBounds.Value;
                var box = Platform.BoundingBox;
                float from = vertical ? box.Y : box.X, to = vertical ? box.Bottom : box.Right;
                int min = vertical ? room.Y : room.X, max = vertical ? room.Y + room.Height + 32 : room.X + room.Width;
                if (from + move < min)
                {
                    move = min - (int)from;
                    hitBounds = true;
                }
                else if ((!vertical || checkBottom) && to + move > max)
                {
                    move = max - (int)to;
                    hitBounds = true;
                }
            }

            var start = Platform.Position;
            int sign = Math.Sign(move), moved = 0;
            CollisionPlatform hit = null;
            try
            {
                while (move != 0)
                {
                    var nextPosition = Platform.Position + axis * sign;
                    var bounds = Platform.BoundingBox;
                    if (thruDashBlocks)
                    {
                        // Tracker.GetEntities<DashBlock>() is traversed on every attempted
                        // pixel. Keep the live platform order, including pending removals,
                        // without materializing an array before Break callbacks.
                        var platforms = World.Platforms;
                        for (var i = 0; i < platforms.Count;)
                        {
                            var block = platforms[i];
                            if (block.Source?.Name == "dashBlock" && CollidesAt(block, nextPosition))
                                BreakDashBlock?.Invoke(block,
                                    new(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2),
                                    axis * sign);
                            // A callback may synchronously remove this collision adapter.
                            // In that case the next live member now occupies this slot.
                            if (i < platforms.Count && ReferenceEquals(platforms[i], block)) i++;
                        }
                    }

                    hit = null;
                    var candidates = World.Platforms;
                    for (var i = 0; i < candidates.Count; i++)
                        if (!candidates[i].IsJumpThru && CollidesAt(candidates[i], nextPosition))
                        {
                            hit = candidates[i];
                            break;
                        }

                    if (hit == null && vertical && move > 0)
                        for (var i = 0; i < candidates.Count; i++)
                            if (candidates[i].IsJumpThru && CollidesAt(candidates[i], nextPosition) &&
                                !CollidesAt(candidates[i], Platform.Position))
                            {
                                hit = candidates[i];
                                break;
                            }

                    if (hit != null) break;
                    moved += sign;
                    move -= sign;
                    Platform.Position = nextPosition;
                }
            }
            finally
            {
                Platform.Position = start;
            }

            // Even a zero-distance impact invokes the original Solid.MoveExact actor pass.
            MoveExact(moved, vertical);
            if (hit != null) onCollide?.Invoke(axis * sign, axis * moved, hit);
            return hit != null || hitBounds;
        }

        public void MoveVExact(int amount)
        {
            MoveExact(amount, true);
        }

        public void MoveHExact(int amount)
        {
            MoveExact(amount, false);
        }

        private bool CollidesAt(CollisionPlatform other,
            Vector2 position)
        {
            if (ReferenceEquals(other, Platform)) return false;
            // Solid.CollideFirst uses the complete moving collider, not its enclosing
            // rectangle: separated ColliderList regions must retain their gaps.
            foreach (var region in Platform.Regions)
                if (other.Intersects(region.At(position)))
                    return true;
            return false;
        }

        private void MoveExact(int amount, bool vertical)
        {
            var actual =
                (SourcePlatformEntityState)Platform
                    .SourceEntityOwner;
            if (vertical) actual.MoveVExact(amount);
            else actual.MoveHExact(amount);
        }
    }
}
