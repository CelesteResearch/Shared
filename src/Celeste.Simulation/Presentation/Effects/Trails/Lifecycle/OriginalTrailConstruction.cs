using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Presentation.Effects.Trails.Lifecycle
{
    public sealed class OriginalTrailConstruction : ISourceTrailConstruction
    {
        public TrailManagerState Create(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine)
        {
            return new(engine, renderEngine);
        }
    }
}
