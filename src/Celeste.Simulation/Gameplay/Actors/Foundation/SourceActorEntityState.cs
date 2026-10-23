using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Riding;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Actors.Foundation
{
    public class SourceActorEntityState : SceneEntityState, ISourcePlatformActor, ISourceActorCollisionWorldProvider,
        ISourceActorTargetMotionProvider
    {
        public PixelActor Body { get; }
        public ISourceEngineContext ActorEngineContext => engine;
        private readonly ISourceEngineContext engine;
        private readonly IPlatformTargetMotionPolicy targetMotionPolicy;
        public global::Celeste.Physics.Collision.SourceCollisionHandler SquishCallback;
        global::Celeste.Physics.Collision.SourceCollisionHandler ISourcePlatformActor.SquishCallback => SquishCallback;
        public bool TreatNaive { get; set; }
        public bool AllowPushing { get; set; } = true;

        public bool IgnoreJumpThrus
        {
            get => Body.IgnoreJumpThrus;
            set => Body.IgnoreJumpThrus = value;
        }

        public float LiftSpeedGraceTime
        {
            get => Body.LiftSpeedGraceTime;
            set => Body.LiftSpeedGraceTime = value;
        }

        public Vector2 LiftSpeed
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => Body.LiftSpeed;
            set => Body.LiftSpeed = value;
        }

        float ISourceActorTargetMotionProvider.GetTargetMovement(float target, float position, float remainder)
            => targetMotionPolicy.GetMovement(target, position, remainder);

        public Vector2 ExactPosition => Body.ExactPosition;
        public Vector2 PositionRemainder => Body.PositionRemainder;

        public override Vector2 Position
        {
            get => Body.Position;
            set => Body.Position = value;
        }

        public ICollisionWorld CollisionWorld => ((ISourcePlatformCollisionScene)Scene).PlatformWorld;

        public SourceActorEntityState(PixelActor body, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy targetMotionPolicy)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Body = body;
            this.engine = engine;
            this.targetMotionPolicy = targetMotionPolicy;
            Body.SourceColliderOwner = this;
            LiftSpeedGraceTime = .16f;
            SquishCallback = OnSquish;
        }

        protected virtual void OnSquish(PixelCollision data)
        {
            if (!TrySquishWiggle(data)) RemoveSelf();
        }

        protected bool TrySquishWiggle(PixelCollision data, int wiggleX = 3, int wiggleY = 3)
            => SourceActorSquish.TryWiggle(Body, data, wiggleX, wiggleY);

        public virtual bool IsRiding(ISourceEntityCollider solid) => CheckAt(solid, Position + Vector2.UnitY);

        public virtual bool IsRiding(ISourceJumpThruCollider jumpThru)
            => !IgnoreJumpThrus && !SourceEntityCollision.Check(this, jumpThru)
                                && CheckAt(jumpThru, Position + Vector2.UnitY);

        private bool CheckAt(ISourceEntityCollider other, Vector2 at)
        {
            Vector2 previous = Position;
            Position = at;
            bool result = SourceEntityCollision.Check(this, other);
            Position = previous;
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool OnGround(int downCheck = 1)
            => Body.CollideSolidAt(Position + new Vector2(0, downCheck)) ||
               (!IgnoreJumpThrus && Body.CollideJumpThruOutside(Position + new Vector2(0, downCheck)));

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool OnGround(Vector2 at, int downCheck = 1)
        {
            Vector2 from = Position;
            Position = at;
            bool result = OnGround(downCheck);
            Position = from;
            return result;
        }

        public void ZeroRemainderX() => Body.ZeroRemainderX();
        public void ZeroRemainderY() => Body.ZeroRemainderY();
        public void ResetLiftSpeed() => Body.ResetLiftSpeed();

        public override void Update()
        {
            base.Update();
            Body.FinishComponentUpdate(engine.DeltaTime);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool MoveH(float amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null,
            ISourceEntityCollider pusher = null)
        {
            Body.Remainder.X += amount;
            int move = (int)Math.Round(Body.Remainder.X, MidpointRounding.ToEven);
            if (move == 0) return false;
            Body.Remainder.X -= move;
            return MoveHExact(move, onCollide, pusher);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool MoveV(float amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null,
            ISourceEntityCollider pusher = null)
        {
            Body.Remainder.Y += amount;
            int move = (int)Math.Round(Body.Remainder.Y, MidpointRounding.ToEven);
            if (move == 0) return false;
            Body.Remainder.Y -= move;
            return MoveVExact(move, onCollide, pusher);
        }

        public bool MoveHExact(int amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null,
            ISourceEntityCollider pusher = null)
            => Body.MoveHExact(amount, onCollide, pusher);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool MoveVExact(int amount, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null,
            ISourceEntityCollider pusher = null)
            => Body.MoveVExact(amount, onCollide, pusher);

        bool ISourcePlatformActor.MoveHExact(int amount) => MoveHExact(amount);
        bool ISourcePlatformActor.MoveVExact(int amount) => MoveVExact(amount);

        public void MoveToX(float target, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null)
            => MoveH(targetMotionPolicy.GetMovement(target, Position.X, Body.Remainder.X), onCollide);

        public void MoveToY(float target, global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null)
            => MoveV(targetMotionPolicy.GetMovement(target, Position.Y, Body.Remainder.Y), onCollide);

        public void MoveTowardsX(float target, float maximumMove,
            global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null)
            => MoveToX(
                ScalarMath.Approach(ExactPosition.X, target, maximumMove,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic),
                onCollide);

        public void MoveTowardsY(float target, float maximumMove,
            global::Celeste.Physics.Collision.SourceCollisionHandler onCollide = null)
            => MoveToY(
                ScalarMath.Approach(ExactPosition.Y, target, maximumMove,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic),
                onCollide);

        public void NaiveMove(Vector2 amount)
        {
            Body.Remainder += amount;
            int x = (int)Math.Round(Body.Remainder.X, MidpointRounding.ToEven);
            int y = (int)Math.Round(Body.Remainder.Y, MidpointRounding.ToEven);
            Position += new Vector2(x, y);
            Body.Remainder -= new Vector2(x, y);
        }
    }
}
