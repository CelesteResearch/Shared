using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Camera
{
    public sealed class RoomCamera
    {
        private readonly ISourcePlayerCameraScene scene;
        public IntRect Bounds => scene.Bounds;

        public Vector2 Position
        {
            get => scene.Camera.Position;
            set => scene.Camera.Position = value;
        }

        public Vector2 Offset
        {
            get => scene.CameraOffset;
            set => scene.CameraOffset = value;
        }

        // Monocle.Camera floors its translation when building the render matrix.
        public Bounds ViewBounds => new(
            (float)Math.Floor(Position.X), (float)Math.Floor(Position.Y), Motion.ViewWidth, Motion.ViewHeight);

        public float UpwardMaxY
        {
            get => scene.CameraUpwardMaxY;
            set => scene.CameraUpwardMaxY = value;
        }

        public RoomCameraLockMode LockMode
        {
            get => scene.CameraLockMode;
            set => scene.CameraLockMode = value;
        }

        public readonly Func<string, bool> GetFlag;
        public readonly CameraMotionProfile Motion;

        public RoomCamera(ISourcePlayerCameraScene scene, CameraMotionProfile motion, Func<string, bool> getFlag)
        {
            this.scene = scene ?? throw new ArgumentNullException(nameof(scene));
            Motion = motion;
            GetFlag = getFlag ?? throw new ArgumentNullException(nameof(getFlag));
        }

        public Vector2 Target(ISourceCameraPlayer player)
        {
            var target = new Vector2(player.Position.X - Motion.CenterX, player.Position.Y - Motion.CenterY);
            if (player.State != Motion.States.NoOffsetAndSnap) target += Offset;
            if (player.State == Motion.States.LookAhead)
            {
                target += new Vector2(Motion.LookAheadScale * player.Speed.X, Motion.LookAheadScale * player.Speed.Y);
            }
            else if (player.State == Motion.States.DirectionBias)
            {
                target.X += Motion.DirectionBias * Math.Sign(player.Speed.X);
                target.Y += Motion.DirectionBias * Math.Sign(player.Speed.Y);
            }
            else if (player.State == Motion.States.RiseBias)
            {
                target.Y -= Motion.RiseBias;
            }
            else if (player.State == Motion.States.NoOffsetAndSnap)
            {
                target.Y += Motion.NoOffsetRise;
            }

            if (((ISourceVectorEnvironment)scene.EngineContext).VectorArithmetic
                .Length(player.CameraAnchorLerp) > 0)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (player.CameraAnchorIgnoreX && !player.CameraAnchorIgnoreY)
                {
                    target.Y = Lerp(target.Y, player.CameraAnchor.Y, player.CameraAnchorLerp.Y);
                }
                else if (!player.CameraAnchorIgnoreX && player.CameraAnchorIgnoreY)
                {
                    target.X = Lerp(target.X, player.CameraAnchor.X, player.CameraAnchorLerp.X);
                }
                else if (player.CameraAnchorLerp.X == player.CameraAnchorLerp.Y)
                {
                    target = Vector2Interpolation.Lerp(target, player.CameraAnchor,
                        player.CameraAnchorLerp.X,
                        ((ISourceScalarEnvironment)scene.EngineContext)
                        .ScalarArithmetic);
                }
                else
                {
                    target.X = Lerp(target.X, player.CameraAnchor.X, player.CameraAnchorLerp.X);
                    target.Y = Lerp(target.Y, player.CameraAnchor.Y, player.CameraAnchorLerp.Y);
                }
            }

            if (player.EnforceLevelBounds)
                target = new(Clamp(target.X, Bounds.X, Bounds.Right - Motion.ViewWidth),
                    Clamp(target.Y, Bounds.Y, Bounds.Bottom - Motion.ViewHeight));
            if (LockMode != RoomCameraLockMode.None)
            {
                var lockers = scene.SourceScene.Components.GetTrackedComponents("Celeste.CameraLocker");
                var locker = lockers.Count == 0 ? null : (RoomCameraLocker)lockers[0];
                if (LockMode != RoomCameraLockMode.BoostSequence)
                {
                    target.X = Max(target.X, Position.X);
                    if (locker != null)
                        target.X = Min(target.X,
                            Max(Bounds.X,
                                ((ISourceEntityPosition)locker.Entity).Position.X -
                                locker.MaxXOffset));
                }

                if (LockMode == RoomCameraLockMode.FinalBoss)
                {
                    target.Y = Max(target.Y, Position.Y);
                    if (locker != null)
                        target.Y = Min(target.Y,
                            Max(Bounds.Y,
                                ((ISourceEntityPosition)locker.Entity).Position.Y -
                                locker.MaxYOffset));
                }
                else if (LockMode == RoomCameraLockMode.BoostSequence)
                {
                    UpwardMaxY = Min(Position.Y + Motion.ViewHeight, UpwardMaxY);
                    target.Y = Min(target.Y, UpwardMaxY);
                    if (locker != null)
                        target.Y = Max(target.Y,
                            Min(Bounds.Bottom - Motion.ViewHeight,
                                ((ISourceEntityPosition)locker.Entity).Position.Y -
                                locker.MaxYOffset));
                }
            }

            foreach (var entry in scene.SourceScene.Entities.GetTrackedEntities("Celeste.Killbox"))
            {
                var box = (ISourceEntityCollider)entry;
                if (box.Collidable && player.Collider.AbsoluteTop < box.Collider.AbsoluteBottom &&
                    player.Collider.AbsoluteRight > box.Collider.AbsoluteLeft &&
                    player.Collider.AbsoluteLeft < box.Collider.AbsoluteRight)
                    target.Y = Min(target.Y, box.Collider.AbsoluteTop - Motion.ViewHeight);
            }

            return target;
        }

        [MethodImpl(MethodImplOptions
            .NoInlining)]
        public float GetFollowFactor(ISourceCameraPlayer player)
        {
            return player.State == Motion.States.FastFollow ? Motion.FastFollowFactor : 1;
        }

        public void Follow(ISourceCameraPlayer player, float deltaTime)
        {
            if (!Motion.States.InControl(player.State) && !player.ForceCameraUpdate) return;
            if (player.State == Motion.States.NoOffsetAndSnap)
            {
                Position = player.CameraTarget;
            }
            else
            {
                Vector2 from = Position, target = player.CameraTarget;
                var factor = GetFollowFactor(player);
                Position = Vector2Interpolation.Lerp(from, target,
                    1 - (float)Math.Pow(Motion.FollowDamping / factor, deltaTime),
                    ((ISourceScalarEnvironment)scene.EngineContext).ScalarArithmetic);
            }
        }

        public Vector2 GetFullCameraTargetAt(ISourceCameraPlayer player, Vector2 at)
        {
            return scene.GetFullCameraTargetAt((RoomPlayerSession)player, at);
        }

        public void InitializeAt(ISourceCameraPlayer player)
        {
            var mode = LockMode;
            LockMode = RoomCameraLockMode.None;
            Position = GetFullCameraTargetAt(player, player.Position);
            LockMode = mode;
            UpwardMaxY = Position.Y + Motion.ViewHeight;
        }

        private float Lerp(float from, float to, float amount)
        {
            return ((ISourceScalarEnvironment)scene.EngineContext).ScalarArithmetic.Lerp(
                from, to, amount);
        }

        private float Min(float first, float second)
        {
            return ((ISourceExtremaEnvironment)scene.EngineContext)
                .ExtremaArithmetic.Min(first, second);
        }

        private float Max(float first, float second)
        {
            return ((ISourceExtremaEnvironment)scene.EngineContext)
                .ExtremaArithmetic.Max(first, second);
        }

        private static float Clamp(float value, float min, float max)
        {
            value = value > max ? max : value;
            return value < min ? min : value;
        }
    }
}
