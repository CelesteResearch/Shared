using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public interface IBloomCutout
    {
        bool Visible { get; }
        float Alpha { get; }
        IntRect DrawBounds { get; }
    }
}
