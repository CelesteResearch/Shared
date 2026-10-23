using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Riding;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public class SourceJumpThruEntityState : SourcePlatformEntityState, ISourceJumpThruEntity
    {
        public SourceJumpThruEntityState(Vector2 position, int width, bool safe, ISourceSolidWorld world)
            : base(position, safe, world)
        {
            Collider = new HitboxColliderGeometry(width, 5f);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            foreach (var component in ((ISourceScene)scene).SourceScene.Components.GetTrackedComponents(
                         "Celeste.StaticMover"))
            {
                var mover = (SourceStaticMoverState)component;
                if (mover.IsRiding(this) && mover.Platform == null)
                {
                    staticMovers.Add(mover);
                    mover.Platform = this;
                    if (mover.OnAttach != null) mover.OnAttach(this);
                }
            }
        }

        public bool HasRider()
        {
            foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName))
                if (((ISourceActorRiding)entity).IsRiding(this))
                    return true;
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool HasPlayerRider()
        {
            foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(global::Celeste.Simulation.RoomPlayerSession).FullName))
                if (((RoomPlayerSession)entity).IsRiding(this))
                    return true;
            return false;
        }

        public RoomPlayerSession GetPlayerRider()
        {
            foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(global::Celeste.Simulation.RoomPlayerSession).FullName))
            {
                var player = (RoomPlayerSession)entity;
                if (player.IsRiding(this)) return player;
            }

            return null;
        }

        public override void MoveHExact(int move) => MoveHExactCore(move, false);

        protected void MoveHExactWithLiftSpeed(int move) => MoveHExactCore(move, true);

        private void MoveHExactCore(int move, bool transferLiftSpeed)
        {
            if (Collidable)
            {
                foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                             typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState)
                                 .FullName))
                {
                    var actor = (ISourcePlatformActor)entity;
                    if (actor.IsRiding(this))
                    {
                        if (transferLiftSpeed) Collidable = false;
                        if (actor.TreatNaive) actor.NaiveMove(Vector2.UnitX * move);
                        else actor.MoveHExact(move);
                        if (transferLiftSpeed)
                        {
                            actor.LiftSpeed = LiftSpeed;
                            Collidable = true;
                        }
                    }
                }
            }

            X += move;
            MoveStaticMovers(Vector2.UnitX * move);
        }

        public override void MoveVExact(int move)
        {
            if (Collidable)
            {
                if (move < 0)
                {
                    foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                                 typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState)
                                     .FullName))
                    {
                        var actor = (ISourcePlatformActor)entity;
                        if (actor.IsRiding(this))
                        {
                            Collidable = false;
                            if (actor.TreatNaive) actor.NaiveMove(Vector2.UnitY * move);
                            else actor.MoveVExact(move);
                            actor.LiftSpeed = LiftSpeed;
                            Collidable = true;
                        }
                        else if (!actor.TreatNaive && CheckActorAt(actor, Position + Vector2.UnitY * move)
                                                   && !SourceEntityCollision.Check(this, actor))
                        {
                            Collidable = false;
                            actor.MoveVExact((int)(Top + (float)move - actor.Bottom));
                            actor.LiftSpeed = LiftSpeed;
                            Collidable = true;
                        }
                    }
                }
                else
                {
                    foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                                 typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState)
                                     .FullName))
                    {
                        var actor = (ISourcePlatformActor)entity;
                        if (actor.IsRiding(this))
                        {
                            Collidable = false;
                            if (actor.TreatNaive) actor.NaiveMove(Vector2.UnitY * move);
                            else actor.MoveVExact(move);
                            actor.LiftSpeed = LiftSpeed;
                            Collidable = true;
                        }
                    }
                }
            }

            Y += move;
            MoveStaticMovers(Vector2.UnitY * move);
        }

        private bool CheckActorAt(ISourceEntityCollider actor, Vector2 at)
        {
            return SourceEntityCollision.CheckAt(this, actor, at);
        }
    }
}
