using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Scene.Entities;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Movement;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public abstract partial class SourcePlatformEntityState : SceneEntityState, ISourcePlatformEntity,
        Celeste.Physics.Collision.ISourcePixelPlatformEntity<CollisionPlatform>
    {
        protected readonly ISourceSolidWorld SourceWorld;
        public CollisionPlatform Platform { get; }
        public SolidPlatformMover Mover { get; }
        protected readonly List<SourceStaticMoverState> staticMovers = new List<SourceStaticMoverState>();
        public IReadOnlyList<SourceStaticMoverState> StaticMovers => staticMovers;

        internal void AttachStaticMover(SourceStaticMoverState mover)
        {
            staticMovers.Add(mover);
            mover.Platform = this;
        }

        private static readonly int[] shakeVectorOffsets = { -1, -1, 0, 1, 1 };
        private Vector2 shakeAmount;
        private bool shaking;
        private float shakeTimer;
        public Vector2 Shake => shakeAmount;
        protected ref Vector2 SourceShakeAmount => ref shakeAmount;

        public Vector2 MovementCounter
        {
            get => Mover.Remainder;
            set => Mover.Remainder = value;
        }

        public Vector2 LiftSpeed
        {
            get => Platform.LiftSpeed;
            set => Platform.LiftSpeed = value;
        }

        public bool Safe
        {
            get => Platform.Safe;
            set => Platform.Safe = value;
        }

        public bool BlockWaterfalls
        {
            get => Platform.BlockWaterfalls;
            set => Platform.BlockWaterfalls = value;
        }

        public Func<RoomPlayerSession, Vector2,
                Celeste.Simulation.Gameplay.Player.Collision.Surfaces.DashCollisionResult>
            OnDashCollide;

        public Action<Vector2> OnCollide;
        public int SurfaceSoundIndex = 8;
        public int SurfaceSoundPriority;
        public Vector2 ExactPosition => Position + Mover.Remainder;

        protected SourcePlatformEntityState(Vector2 position, bool safe, ISourceSolidWorld world)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)world.EngineContext)
                .EntitySourceDataRegistration, position)
        {
            SourceWorld = world;
            Platform = world.Platform;
            Mover = world.Mover;
            Position = position;
            Safe = safe;
            Depth = -9000;
            Platform.SourceEntityOwner = this;
            Mover.MoveStaticMovers = MoveStaticMovers;
        }

        public void ClearRemainder() => Mover.Remainder = Vector2.Zero;

        public override void Update()
        {
            Mover.DeltaTime = SourceWorld.EngineContext.DeltaTime;
            base.Update();
            LiftSpeed = Vector2.Zero;
            if (!shaking) return;
            var clock = ((ISourceScene)Scene).SourceScene.Clock;
            if (clock.OnInterval(.04f, SourceWorld.EngineContext))
            {
                Vector2 previous = shakeAmount;
                shakeAmount = new Vector2(shakeVectorOffsets[SourceWorld.GameplayRandom.Next(5)],
                    shakeVectorOffsets[SourceWorld.GameplayRandom.Next(5)]);
                OnShake(shakeAmount - previous);
            }

            if (shakeTimer > 0f)
            {
                shakeTimer -= SourceWorld.EngineContext.DeltaTime;
                if (shakeTimer <= 0f)
                {
                    shaking = false;
                    StopShaking();
                }
            }
        }

        public void StartShaking(float time = 0f)
        {
            shaking = true;
            shakeTimer = time;
        }

        public void StopShaking()
        {
            shaking = false;
            if (shakeAmount != Vector2.Zero)
            {
                OnShake(-shakeAmount);
                shakeAmount = Vector2.Zero;
            }
        }

        public virtual void OnShake(Vector2 amount) => ShakeStaticMovers(amount);

        public virtual void OnStaticMoverTrigger(SourceStaticMoverState mover)
        {
        }

        public void ShakeStaticMovers(Vector2 amount)
        {
            foreach (var mover in staticMovers) mover.Shake(amount);
        }

        public void MoveStaticMovers(Vector2 amount)
        {
            foreach (var mover in staticMovers) mover.MoveWithLiftSpeed(amount, LiftSpeed);
        }

        public void DestroyStaticMovers()
        {
            foreach (var mover in staticMovers) mover.Destroy();
            staticMovers.Clear();
        }

        public void DisableStaticMovers()
        {
            foreach (var mover in staticMovers) mover.Disable();
        }

        public void EnableStaticMovers()
        {
            foreach (var mover in staticMovers) mover.Enable();
        }

        public virtual int GetLandSoundIndex(Celeste.Physics.Collision.ISourceEntityCollider entity) =>
            SurfaceSoundIndex;

        public virtual int GetWallSoundIndex(Celeste.Physics.Collision.ISourceEntityCollider player, int side) =>
            SurfaceSoundIndex;

        public virtual int GetStepSoundIndex(Celeste.Physics.Collision.ISourceEntityCollider entity) =>
            SurfaceSoundIndex;

        public HitboxColliderGeometry Hitbox => Collider as HitboxColliderGeometry;
        public abstract void MoveHExact(int amount);
        public abstract void MoveVExact(int amount);

        public void MoveToX(float x) =>
            MoveH(SourceWorld.TargetMotionPolicy.GetMovement(x, Position.X, Mover.Remainder.X));

        public void MoveToX(float x, float liftSpeed) =>
            MoveH(SourceWorld.TargetMotionPolicy.GetMovement(x, Position.X, Mover.Remainder.X), liftSpeed);

        public void MoveToY(float y) =>
            MoveV(SourceWorld.TargetMotionPolicy.GetMovement(y, Position.Y, Mover.Remainder.Y));

        public void MoveToY(float y, float liftSpeed) =>
            MoveV(SourceWorld.TargetMotionPolicy.GetMovement(y, Position.Y, Mover.Remainder.Y), liftSpeed);

        public void MoveTo(Vector2 position)
        {
            MoveToX(position.X);
            MoveToY(position.Y);
        }

        public void MoveTo(Vector2 position, Vector2 liftSpeed)
        {
            MoveToX(position.X, liftSpeed.X);
            MoveToY(position.Y, liftSpeed.Y);
        }

        public void MoveTowardsX(float x, float amount) => MoveToX(Celeste.Core.Mathematics.ScalarMath.Approach(
            ExactPosition.X, x, amount,
            ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)SourceWorld.EngineContext)
            .ExtremaArithmetic));

        public void MoveTowardsY(float y, float amount) => MoveToY(Celeste.Core.Mathematics.ScalarMath.Approach(
            ExactPosition.Y, y, amount,
            ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)SourceWorld.EngineContext)
            .ExtremaArithmetic));

        public void MoveToNaive(Vector2 position)
        {
            MoveToXNaive(position.X);
            MoveToYNaive(position.Y);
        }

        public void MoveToXNaive(float x) =>
            MoveHNaive(SourceWorld.TargetMotionPolicy.GetMovement(x, Position.X, Mover.Remainder.X));

        public void MoveToYNaive(float y) =>
            MoveVNaive(SourceWorld.TargetMotionPolicy.GetMovement(y, Position.Y, Mover.Remainder.Y));

        public void MoveHNaive(float amount)
        {
            Mover.DeltaTime = SourceWorld.EngineContext.DeltaTime;
            Mover.MoveHNaive(amount);
        }

        public void MoveVNaive(float amount)
        {
            Mover.DeltaTime = SourceWorld.EngineContext.DeltaTime;
            Mover.MoveVNaive(amount);
        }

        public void MoveH(float amount)
        {
            var lift = LiftSpeed;
            lift.X = SourceWorld.EngineContext.DeltaTime == 0f ? 0f : amount / SourceWorld.EngineContext.DeltaTime;
            LiftSpeed = lift;
            var remainder = Mover.Remainder;
            remainder.X += amount;
            int move = (int)Math.Round(remainder.X);
            if (move != 0)
            {
                remainder.X -= move;
                Mover.Remainder = remainder;
                MoveHExact(move);
            }
            else Mover.Remainder = remainder;
        }

        public void MoveV(float amount)
        {
            var lift = LiftSpeed;
            lift.Y = SourceWorld.EngineContext.DeltaTime == 0f ? 0f : amount / SourceWorld.EngineContext.DeltaTime;
            LiftSpeed = lift;
            var remainder = Mover.Remainder;
            remainder.Y += amount;
            int move = (int)Math.Round(remainder.Y);
            if (move != 0)
            {
                remainder.Y -= move;
                Mover.Remainder = remainder;
                MoveVExact(move);
            }
            else Mover.Remainder = remainder;
        }

        public void MoveH(float amount, float liftSpeed)
        {
            var lift = LiftSpeed;
            lift.X = liftSpeed;
            LiftSpeed = lift;
            var remainder = Mover.Remainder;
            remainder.X += amount;
            int move = (int)Math.Round(remainder.X);
            if (move != 0)
            {
                remainder.X -= move;
                Mover.Remainder = remainder;
                MoveHExact(move);
            }
            else Mover.Remainder = remainder;
        }

        public void MoveV(float amount, float liftSpeed)
        {
            var lift = LiftSpeed;
            lift.Y = liftSpeed;
            LiftSpeed = lift;
            var remainder = Mover.Remainder;
            remainder.Y += amount;
            int move = (int)Math.Round(remainder.Y);
            if (move != 0)
            {
                remainder.Y -= move;
                Mover.Remainder = remainder;
                MoveVExact(move);
            }
            else Mover.Remainder = remainder;
        }
    }
}
