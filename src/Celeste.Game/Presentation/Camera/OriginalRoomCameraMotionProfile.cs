using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Camera;

namespace Celeste.Game.Presentation.Camera
{
    public static class OriginalRoomCameraMotionProfile
    {
        public static readonly CameraMotionProfile Values = new CameraMotionProfile(
            viewWidth: 320, viewHeight: 180, centerX: 160, centerY: 90,
            directionBias: 48, riseBias: 64, noOffsetRise: 32, lookAheadScale: .2f,
            followDamping: .01f, fastFollowFactor: 8,
            states: new CameraPlayerStateRoles(directionBias: 5, riseBias: 10,
                noOffsetAndSnap: 18, lookAhead: 19, fastFollow: 20,
                uncontrolledMask: 0x0283F800u)); // 11..17, 23, 25.

        public static global::Celeste.Simulation.Gameplay.Camera.RoomCameraPlayer CreatePlayer() =>
            new global::Celeste.Simulation.Gameplay.Camera.RoomCameraPlayer(
                new global::Celeste.Core.Geometry.Bounds(-4, -11, 8, 11), Values.States);
    }
}
