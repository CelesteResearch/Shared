using Celeste.Core.Components;

namespace Celeste.Simulation.Gameplay.Camera
{
    public sealed class RoomCameraLocker : SourceComponentState
    {
        public const float UpwardMaxYOffset = 180f;
        public RoomCameraLockMode LockMode;
        public float MaxXOffset;
        public float MaxYOffset;

        public RoomCameraLocker(RoomCameraLockMode lockMode, float maxXOffset, float maxYOffset)
            : base(lockMode == RoomCameraLockMode.BoostSequence, false)
        {
            LockMode = lockMode;
            MaxXOffset = maxXOffset;
            MaxYOffset = maxYOffset;
        }

        public override void EntityAdded(object scene)
        {
            base.EntityAdded(scene);
            ((ISourcePlayerCameraScene)Scene).CameraLockMode = LockMode;
        }
    }
}
