using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;

namespace Celeste.Simulation.Presentation.Effects.Trails.Lifecycle
{
    public interface ISourceTrailConstruction
    {
        TrailManagerState Create(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine);
    }
}
