using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;

namespace Celeste.Simulation.Presentation.Effects.Trails.Lifecycle
{
    public interface ISourceTrailConstructionEnvironment
    {
        ISourceTrailConstruction TrailConstruction { get; }
    }
}
