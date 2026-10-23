using Celeste.Core.Geometry;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public interface IBloomCutout
    {
        bool Visible { get; }
        float Alpha { get; }
        IntRect DrawBounds { get; }
    }
}
