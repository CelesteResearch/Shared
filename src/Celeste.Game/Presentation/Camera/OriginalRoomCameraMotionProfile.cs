using Celeste.Simulation.Gameplay.Camera;

namespace Celeste.Game.Presentation.Camera
{
    public static class OriginalRoomCameraMotionProfile
    {
        public static readonly CameraMotionProfile Values = new(
            320, 180, 160, 90,
            48, 64, 32, .2f,
            .01f, 8,
            new(5, 10,
                18, 19, 20,
                0x0283F800u)); // 11..17, 23, 25.

        public static RoomCameraPlayer CreatePlayer()
        {
            return new(
                new(-4, -11, 8, 11), Values.States);
        }
    }
}
