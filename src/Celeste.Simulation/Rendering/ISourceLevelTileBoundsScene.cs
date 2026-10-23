using Celeste.Core.Geometry;

namespace Celeste.Simulation.Rendering
{
    public interface ISourceLevelTileBoundsScene
    {
        IntRect TileBounds { get; }
    }
}
