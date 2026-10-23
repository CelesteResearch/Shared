using System.Collections.Generic;
using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Riding;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public partial class SourceSolidEntityState
    {
        private static readonly HashSet<ISourcePlatformActor> riders = new HashSet<ISourcePlatformActor>();

        public static global::Celeste.Simulation.Gameplay.Platforms.Movement.SourceSolidRiderScope
            CaptureMovementRiders()
            => global::Celeste.Simulation.Gameplay.Platforms.Movement.SourceSolidRiderScope.Capture(riders);

        public void GetRiders()
        {
            foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName))
            {
                var actor = (ISourcePlatformActor)entity;
                if (actor.IsRiding(this)) riders.Add(actor);
            }
        }

        public override void MoveHExact(int move)
        {
            GetRiders();
            float right = Right;
            float left = Left;
            RoomPlayerSession player =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (player != null && SourceWorld.CollisionEffects.ShouldMovePlayerUp(player, move)
                               && !riders.Contains(player) &&
                               CheckActorAt(player, Position + Vector2.UnitX * move - Vector2.UnitY))
            {
                player.MoveV(1f);
            }

            var position = Position;
            position.X += move;
            Position = position;
            MoveStaticMovers(Vector2.UnitX * move);
            if (Collidable)
            {
                foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                             typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState)
                                 .FullName))
                {
                    var actor = (ISourcePlatformActor)entity;
                    if (!actor.AllowPushing) continue;
                    bool collidable = actor.Collidable;
                    actor.Collidable = true;
                    if (!actor.TreatNaive && CheckActorAt(actor, Position))
                    {
                        PushActorH(actor, move, left, right);
                    }
                    else if (riders.Contains(actor))
                    {
                        Collidable = false;
                        if (actor.TreatNaive) actor.NaiveMove(Vector2.UnitX * move);
                        else actor.MoveHExact(move);
                        actor.LiftSpeed = LiftSpeed;
                        Collidable = true;
                    }

                    actor.Collidable = collidable;
                }
            }

            riders.Clear();
        }

        public override void MoveVExact(int move)
        {
            GetRiders();
            float bottom = Bottom;
            float top = Top;
            var position = Position;
            position.Y += move;
            Position = position;
            MoveStaticMovers(Vector2.UnitY * move);
            if (Collidable)
            {
                foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                             typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState)
                                 .FullName))
                {
                    var actor = (ISourcePlatformActor)entity;
                    if (!actor.AllowPushing) continue;
                    bool collidable = actor.Collidable;
                    actor.Collidable = true;
                    if (!actor.TreatNaive && CheckActorAt(actor, Position))
                    {
                        PushActorV(actor, move, top, bottom);
                    }
                    else if (riders.Contains(actor))
                    {
                        Collidable = false;
                        if (actor.TreatNaive) actor.NaiveMove(Vector2.UnitY * move);
                        else actor.MoveVExact(move);
                        actor.LiftSpeed = LiftSpeed;
                        Collidable = true;
                    }

                    actor.Collidable = collidable;
                }
            }

            riders.Clear();
        }

        protected virtual void PushActorH(ISourcePlatformActor actor, int move, float left, float right)
        {
            int moveH = move <= 0 ? move - (int)(actor.Right - left) : move - (int)(actor.Left - right);
            Collidable = false;
            actor.MoveHExact(moveH, actor.SquishCallback, this);
            actor.LiftSpeed = LiftSpeed;
            Collidable = true;
        }

        protected virtual void PushActorV(ISourcePlatformActor actor, int move, float top, float bottom)
        {
            int moveV = move <= 0 ? move - (int)(actor.Bottom - top) : move - (int)(actor.Top - bottom);
            Collidable = false;
            actor.MoveVExact(moveV, actor.SquishCallback, this);
            actor.LiftSpeed = LiftSpeed;
            Collidable = true;
        }

        private bool CheckActorAt(ISourceEntityCollider actor, Vector2 at)
        {
            Vector2 previous = Position;
            Position = at;
            bool result = SourceEntityCollision.Check(this, actor);
            Position = previous;
            return result;
        }
    }
}
