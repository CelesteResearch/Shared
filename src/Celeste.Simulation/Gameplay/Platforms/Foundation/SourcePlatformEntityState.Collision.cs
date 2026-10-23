using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Geometry;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Walls.Breakable;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public abstract partial class SourcePlatformEntityState
    {
        public bool MoveHCollideSolids(float moveH, bool thruDashBlocks,
            Action<Vector2, Vector2, ISourcePlatformEntity> onCollide = null)
        {
            if (SourceWorld.EngineContext.DeltaTime == 0f)
            {
                var lift = LiftSpeed;
                lift.X = 0f;
                LiftSpeed = lift;
            }
            else
            {
                var lift = LiftSpeed;
                lift.X = moveH / SourceWorld.EngineContext.DeltaTime;
                LiftSpeed = lift;
            }

            var counter = MovementCounter;
            counter.X += moveH;
            MovementCounter = counter;
            var num = (int)Math.Round(MovementCounter.X);
            if (num != 0)
            {
                counter = MovementCounter;
                counter.X -= num;
                MovementCounter = counter;
                return MoveHExactCollideSolids(num, thruDashBlocks, onCollide);
            }

            return false;
        }

        public bool MoveVCollideSolids(float moveV, bool thruDashBlocks,
            Action<Vector2, Vector2, ISourcePlatformEntity> onCollide = null)
        {
            if (SourceWorld.EngineContext.DeltaTime == 0f)
            {
                var lift = LiftSpeed;
                lift.Y = 0f;
                LiftSpeed = lift;
            }
            else
            {
                var lift = LiftSpeed;
                lift.Y = moveV / SourceWorld.EngineContext.DeltaTime;
                LiftSpeed = lift;
            }

            var counter = MovementCounter;
            counter.Y += moveV;
            MovementCounter = counter;
            var num = (int)Math.Round(MovementCounter.Y);
            if (num != 0)
            {
                counter = MovementCounter;
                counter.Y -= num;
                MovementCounter = counter;
                return MoveVExactCollideSolids(num, thruDashBlocks, onCollide);
            }

            return false;
        }

        public bool MoveHCollideSolidsAndBounds(ISourceSceneBounds level, float moveH, bool thruDashBlocks,
            Action<Vector2, Vector2, ISourcePlatformEntity> onCollide = null)
        {
            if (SourceWorld.EngineContext.DeltaTime == 0f)
            {
                var lift = LiftSpeed;
                lift.X = 0f;
                LiftSpeed = lift;
            }
            else
            {
                var lift = LiftSpeed;
                lift.X = moveH / SourceWorld.EngineContext.DeltaTime;
                LiftSpeed = lift;
            }

            var counter = MovementCounter;
            counter.X += moveH;
            MovementCounter = counter;
            var num = (int)Math.Round(MovementCounter.X);
            if (num != 0)
            {
                counter = MovementCounter;
                counter.X -= num;
                MovementCounter = counter;
                bool flag;
                if (Left + num < level.Bounds.Left)
                {
                    flag = true;
                    num = level.Bounds.Left - (int)Left;
                }
                else if (Right + num > level.Bounds.Right)
                {
                    flag = true;
                    num = level.Bounds.Right - (int)Right;
                }
                else
                {
                    flag = false;
                }

                return MoveHExactCollideSolids(num, thruDashBlocks, onCollide) || flag;
            }

            return false;
        }

        public bool MoveVCollideSolidsAndBounds(ISourceSceneBounds level, float moveV, bool thruDashBlocks,
            Action<Vector2, Vector2, ISourcePlatformEntity> onCollide = null, bool checkBottom = true)
        {
            if (SourceWorld.EngineContext.DeltaTime == 0f)
            {
                var lift = LiftSpeed;
                lift.Y = 0f;
                LiftSpeed = lift;
            }
            else
            {
                var lift = LiftSpeed;
                lift.Y = moveV / SourceWorld.EngineContext.DeltaTime;
                LiftSpeed = lift;
            }

            var counter = MovementCounter;
            counter.Y += moveV;
            MovementCounter = counter;
            var num = (int)Math.Round(MovementCounter.Y);
            if (num != 0)
            {
                counter = MovementCounter;
                counter.Y -= num;
                MovementCounter = counter;
                var num2 = level.Bounds.Bottom + 32;
                bool flag;
                if (Top + num < level.Bounds.Top)
                {
                    flag = true;
                    num = level.Bounds.Top - (int)Top;
                }
                else if (checkBottom && Bottom + num > num2)
                {
                    flag = true;
                    num = num2 - (int)Bottom;
                }
                else
                {
                    flag = false;
                }

                return MoveVExactCollideSolids(num, thruDashBlocks, onCollide) || flag;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool MoveHExactCollideSolids(int moveH, bool thruDashBlocks,
            Action<Vector2, Vector2, ISourcePlatformEntity> onCollide = null)
        {
            var x = X;
            var num = Math.Sign(moveH);
            var num2 = 0;
            ISourcePlatformEntity solid = null;
            while (moveH != 0)
            {
                if (thruDashBlocks)
                    foreach (var value in
                             ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.DashBlock"))
                    {
                        var entity = (ISourceEntityCollider)value;
                        if (SourceEntityCollision.CheckAt(this, entity,
                                SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitX, num))))
                        {
                            ((IBreakableWallEntity)value).Break(Center,
                                SourceVector2Math.Multiply(Vector2.UnitX, num),
                                true, true);
                            SourceWorld.CollisionEffects.AfterBreakingWall(this);
                        }
                    }

                solid = SourceTrackedEntityCollision.FirstAt<SourceSolidEntityState>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", this,
                    SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitX, num)));
                if (solid != null) break;

                num2 += num;
                moveH -= num;
                X += num;
            }

            X = x;
            MoveHExact(num2);
            if (solid != null)
                onCollide?.Invoke(SourceVector2Math.Multiply(Vector2.UnitX, num),
                    SourceVector2Math.Multiply(Vector2.UnitX, num2), solid);

            return solid != null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool MoveVExactCollideSolids(int moveV, bool thruDashBlocks,
            Action<Vector2, Vector2, ISourcePlatformEntity> onCollide = null)
        {
            var y = Y;
            var num = Math.Sign(moveV);
            var num2 = 0;
            SourcePlatformEntityState platform = null;
            while (moveV != 0)
            {
                if (thruDashBlocks)
                    foreach (var value in
                             ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities("Celeste.DashBlock"))
                    {
                        var entity = (ISourceEntityCollider)value;
                        if (SourceEntityCollision.CheckAt(this, entity,
                                SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitY, num))))
                        {
                            ((IBreakableWallEntity)value).Break(Center,
                                SourceVector2Math.Multiply(Vector2.UnitY, num),
                                true, true);
                            SourceWorld.CollisionEffects.AfterBreakingWall(this);
                        }
                    }

                platform = SourceTrackedEntityCollision.FirstAt<SourceSolidEntityState>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", this,
                    SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitY, num)));
                if (platform != null) break;

                if (moveV > 0)
                {
                    platform =
                        SourceTrackedEntityCollision
                            .FirstOutsideAt<SourceJumpThruEntityState, SourcePlatformEntityState>(
                                ((ISourceScene)Scene).SourceScene.Entities, "Celeste.JumpThru", this,
                                SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitY, num)));
                    if (platform != null) break;
                }

                num2 += num;
                moveV -= num;
                Y += num;
            }

            Y = y;
            MoveVExact(num2);
            if (platform != null)
                onCollide?.Invoke(SourceVector2Math.Multiply(Vector2.UnitY, num),
                    SourceVector2Math.Multiply(Vector2.UnitY, num2), platform);

            return platform != null;
        }
    }
}
