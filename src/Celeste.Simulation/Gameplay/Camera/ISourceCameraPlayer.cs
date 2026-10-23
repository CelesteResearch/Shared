using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Camera
{
    public interface ISourceCameraPlayer : ISourceEntityCollider
    {
        new Vector2 Position { get; set; }
        Vector2 Speed { get; }
        Vector2 CameraTarget { get; }
        int State { get; }
        IntRect Bounds { get; }
        bool EnforceLevelBounds { get; set; }
        bool ForceCameraUpdate { get; set; }
        Vector2 CameraAnchor { get; set; }
        Vector2 CameraAnchorLerp { get; set; }
        bool CameraAnchorIgnoreX { get; set; }
        bool CameraAnchorIgnoreY { get; set; }
    }
}
