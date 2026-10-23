using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Core.Rendering.Cameras
{
    public interface ISourceCommandsCamera
    {
        IntRect Viewport { get; }
        Vector2 ScreenToCamera(Vector2 position);
        Vector2 CameraToScreen(Vector2 position);
    }
}
