using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Presentation.Effects.Trails.Lifecycle
{
    public interface ISourceTrailConstruction
    {
        TrailManagerState Create(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine);
    }
}
