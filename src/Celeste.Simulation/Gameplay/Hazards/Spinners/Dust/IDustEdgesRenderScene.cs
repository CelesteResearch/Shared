using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
// Required references to the same actual Level fields, not a render algorithm.
    public interface IDustEdgesRenderScene
    {
        CameraState Camera { get; }
        VirtualRenderTarget DustTempA { get; }
        VirtualRenderTarget ResortDust { get; }
        SourceEffect DustEffect { get; }
        int DustAreaId { get; }
        bool UseSafeDustTextures { get; }
    }
}
