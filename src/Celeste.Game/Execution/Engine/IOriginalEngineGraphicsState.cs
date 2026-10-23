using Celeste.Core.Rendering;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Game.Execution.Engine
{
    public interface IOriginalEngineGraphicsState : ISourceGraphicsContext
    {
        int ViewPadding { get; set; }
        CameraViewport Viewport { get; }
        new object HudTarget { get; set; }
        object WipeTarget { get; set; }
    }
}
