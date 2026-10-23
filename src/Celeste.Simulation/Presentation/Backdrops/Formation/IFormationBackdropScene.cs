using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Simulation.Presentation.Backdrops.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.Formation
{
    public interface IFormationBackdropScene
    {
        BackdropRendererPresentation Foreground { get; }
        CameraState Camera { get; }
    }
}
