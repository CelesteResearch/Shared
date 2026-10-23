using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Camera
{
    public interface ISourcePlayerCameraScene : ISourceScene, ISourceEngineContextScene
    {
        CameraState Camera { get; }
        RoomCamera PlayerCamera { get; }
        RoomCameraLockMode CameraLockMode { get; set; }
        Vector2 CameraOffset { get; set; }
        float CameraUpwardMaxY { get; set; }
        IntRect Bounds { get; }
        Vector2 GetFullCameraTargetAt(RoomPlayerSession player, Vector2 at);
    }
}
