using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Everest.Presentation.Effects.Trails
{
    public sealed class EverestTrailConstruction : ISourceTrailConstruction
    {
        public TrailManagerState Create(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine)
        {
            return new EverestTrailManagerState(engine, renderEngine);
        }
    }
}
