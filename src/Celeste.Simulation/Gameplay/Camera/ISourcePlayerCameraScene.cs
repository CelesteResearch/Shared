using Celeste.Core.Geometry;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Simulation.Gameplay.Camera
{
    public interface ISourcePlayerCameraScene : ISourceScene, global::Celeste.Core.Scheduling.ISourceEngineContextScene
    {
        CameraState Camera { get; }
        RoomCamera PlayerCamera { get; }
        RoomCameraLockMode CameraLockMode { get; set; }
        System.Numerics.Vector2 CameraOffset { get; set; }
        float CameraUpwardMaxY { get; set; }
        IntRect Bounds { get; }
        System.Numerics.Vector2 GetFullCameraTargetAt(RoomPlayerSession player, System.Numerics.Vector2 at);
    }
}
