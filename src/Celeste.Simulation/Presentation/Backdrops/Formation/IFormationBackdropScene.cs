using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Simulation.Presentation.Backdrops.Formation
{
    public interface IFormationBackdropScene
    {
        BackdropRendererPresentation Foreground { get; }
        CameraState Camera { get; }
    }
}
