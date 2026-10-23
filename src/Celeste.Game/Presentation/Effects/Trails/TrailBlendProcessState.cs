using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Trails;
using Celeste.Game.Presentation.Lighting;

namespace Celeste.Game.Presentation.Effects.Trails
{
    public sealed class TrailBlendProcessState : ISourceTrailBlendResources
    {
        private readonly ISourceEngineContext engine;

        public SourceBlendState MaxBlendState = new SourceBlendState
        {
            ColorSourceBlend = SourceBlendFactor.DestinationAlpha,
            AlphaSourceBlend = SourceBlendFactor.DestinationAlpha
        };

        public TrailBlendProcessState(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public SourceBlendState OccludeBlendState =>
            ((IOriginalLightingRendererEnvironment)engine).LightingRendererProcess.OccludeBlendState;

        SourceBlendState ISourceTrailBlendResources.MaxBlendState => MaxBlendState;
    }
}
