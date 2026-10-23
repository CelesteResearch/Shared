using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;

namespace Celeste.Simulation.Presentation.Effects.Trails.Lifecycle
{
    public sealed class OriginalTrailConstruction : ISourceTrailConstruction
    {
        public TrailManagerState Create(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine) =>
            new TrailManagerState(engine, renderEngine);
    }
}
