using Celeste.Core.Rendering.States;

namespace Celeste.Graphics.Rendering.Trails
{
    public interface ISourceTrailBlendResources
    {
        SourceBlendState OccludeBlendState { get; }
        SourceBlendState MaxBlendState { get; }
    }
}
