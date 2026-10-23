using System.Numerics;
using Celeste.Core.Framework.Timing;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Riding;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public partial class SourceSolidEntityState : SourcePlatformEntityState
    {
        public Vector2 Speed;

        public bool AllowStaticMovers
        {
            get => Platform.AllowStaticMovers;
            set => Platform.AllowStaticMovers = value;
        }

        public bool EnableAssistModeChecks
        {
            get => Platform.EnableAssistModeChecks;
            set => Platform.EnableAssistModeChecks = value;
        }

        public bool DisableLightsInside
        {
            get => Platform.DisableLightsInside;
            set => Platform.DisableLightsInside = value;
        }

        public bool StopPlayerRunIntoAnimation
        {
            get => Platform.StopPlayerRunIntoAnimation;
            set => Platform.StopPlayerRunIntoAnimation = value;
        }

        public bool SquishEvenInAssistMode
        {
            get => Platform.SquishEvenInAssistMode;
            set => Platform.SquishEvenInAssistMode = value;
        }

        public SourceSolidEntityState(Vector2 position, float width, float height, bool safe, ISourceSolidWorld world)
            : base(position, safe, world)
        {
            Collider = new HitboxColliderGeometry(width, height);
        }

        public override void Awake(object scene)
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long started = 0;
            var measuring = diagnostics?.BeginLoadPlatformAttachment(out started) ?? false;
            try
            {
                base.Awake(scene);
                if (!AllowStaticMovers) return;
                var attachmentCheckOrder = SourceWorld.AttachmentCheckOrder;
                var collidable = Collidable;
                Collidable = true;
                foreach (var component in ((ISourceScene)scene).SourceScene.Components.GetTrackedComponents(
                             "Celeste.StaticMover"))
                {
                    var mover = (SourceStaticMoverState)component;
                    if (attachmentCheckOrder == StaticMoverAttachmentCheckOrder.OwnerFirst
                            ? mover.Platform == null && mover.IsRiding(this)
                            : mover.IsRiding(this) && mover.Platform == null)
                    {
                        staticMovers.Add(mover);
                        mover.Platform = this;
                        if (mover.OnAttach != null) mover.OnAttach(this);
                    }
                }

                Collidable = collidable;
            }
            finally
            {
                if (measuring) diagnostics.EndLoadPlatformAttachment(started);
            }
        }

        public bool HasRider()
        {
            foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(SourceActorEntityState).FullName))

                if (((ISourceActorRiding)entity).IsRiding(this))
                    return true;

            return false;
        }

        public RoomPlayerSession GetPlayerRider()
        {
            foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(RoomPlayerSession).FullName))

            {
                var player = (RoomPlayerSession)entity;
                if (player.IsRiding(this)) return player;
            }

            return null;
        }

        public bool HasPlayerRider()
        {
            return GetPlayerRider() != null;
        }

        public bool HasPlayerOnTop()
        {
            return GetPlayerOnTop() != null;
        }

        public RoomPlayerSession GetPlayerOnTop()
        {
            var tracked =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                    typeof(RoomPlayerSession).FullName);

            var previous = Position;
            Position -= Vector2.UnitY;
            foreach (var entity in tracked)
            {
                var player = (RoomPlayerSession)entity;
                if (SourceEntityCollision.Check(this, player))
                {
                    Position = previous;
                    return player;
                }
            }

            Position = previous;
            return null;
        }

        public bool HasPlayerClimbing()
        {
            return GetPlayerClimbing() != null;
        }

        public RoomPlayerSession GetPlayerClimbing()
        {
            foreach (var entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(RoomPlayerSession).FullName))

            {
                var player = (RoomPlayerSession)entity;
                if (player.Machine.State == 1)
                {
                    if (player.Data.Facing == -1 && CheckPlayerAt(player, Position + Vector2.UnitX)) return player;
                    if (player.Data.Facing == 1 && CheckPlayerAt(player, Position - Vector2.UnitX)) return player;
                }
            }

            return null;
        }

        private bool CheckPlayerAt(RoomPlayerSession player, Vector2 at)
        {
            var previous = Position;
            Position = at;
            var result = SourceEntityCollision.Check(this, player);
            Position = previous;
            return result;
        }

        public override void Update()
        {
            base.Update();
            MoveH(Speed.X * SourceWorld.EngineContext.DeltaTime);
            MoveV(Speed.Y * SourceWorld.EngineContext.DeltaTime);
            SourceWorld.SolidAssistPolicy.AfterMovement(this);
        }
    }
}
