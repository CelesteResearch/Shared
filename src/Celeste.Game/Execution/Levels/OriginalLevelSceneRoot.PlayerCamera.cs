using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Scene.Tracking;
using Celeste.Physics.Collision;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Game.Presentation.Camera;
using Celeste.Game.Entities.Triggers.Camera;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Game.Execution.Levels
{
    public partial class OriginalLevelSceneRoot : ISourcePlayerCameraScene
    {
        private RoomCamera sourcePlayerCamera;
        public RoomCamera PlayerCamera => sourcePlayerCamera;

        private void InitializeSourcePlayerCamera()
            => sourcePlayerCamera =
                new RoomCamera(this, OriginalRoomCameraMotionProfile.Values, name => Session.GetFlag(name));

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
            Vector2 position = player.Position;
            player.Position = at;
            foreach (var entity in ((ISourceScene)this).SourceScene.Entities.GetTrackedEntities("Celeste.Trigger"))
            {
                if (entity is OriginalCameraTargetTriggerState target && SourceEntityCollision.Check(player, target))
                    target.OnStay(player);
                else if (entity is OriginalCameraOffsetTriggerState offset &&
                         SourceEntityCollision.Check(player, offset))
                    offset.OnEnter(player);
            }

            Vector2 cameraTarget = player.CameraTarget;
            player.Position = position;
            return cameraTarget;
        }
    }
}
