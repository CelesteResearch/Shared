using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Game.Entities.Triggers.Camera;
using Celeste.Game.Presentation.Camera;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Camera;

namespace Celeste.Game.Execution.Levels
{
    public partial class OriginalLevelSceneRoot : ISourcePlayerCameraScene
    {
        private RoomCamera sourcePlayerCamera;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public RoomCamera PlayerCamera => sourcePlayerCamera;

        private void InitializeSourcePlayerCamera()
        {
            sourcePlayerCamera =
                new(this, OriginalRoomCameraMotionProfile.Values, name => Session.GetFlag(name));
        }

        CameraState ISourcePlayerCameraScene.Camera => Camera;
        IntRect ISourcePlayerCameraScene.Bounds => Bounds;

        RoomCameraLockMode ISourcePlayerCameraScene.CameraLockMode
        {
            get => CameraLockMode;
            set => CameraLockMode = value;
        }

        Vector2 ISourcePlayerCameraScene.CameraOffset
        {
            get => CameraOffset;
            set => CameraOffset = value;
        }

        float ISourcePlayerCameraScene.CameraUpwardMaxY
        {
            get => CameraUpwardMaxY;
            set => CameraUpwardMaxY = value;
        }

        public Vector2 GetFullCameraTargetAt(RoomPlayerSession player, Vector2 at)
        {
            var position = player.Position;
            player.Position = at;
            foreach (var entity in ((ISourceScene)this).SourceScene.Entities.GetTrackedEntities("Celeste.Trigger"))
                if (entity is OriginalCameraTargetTriggerState target && SourceEntityCollision.Check(player, target))
                    target.OnStay(player);
                else if (entity is OriginalCameraOffsetTriggerState offset &&
                         SourceEntityCollision.Check(player, offset))
                    offset.OnEnter(player);

            var cameraTarget = player.CameraTarget;
            player.Position = position;
            return cameraTarget;
        }
    }
}
