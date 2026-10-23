using Celeste.Core.Maps;

namespace Celeste.Core.Rendering.Observation
{
    public readonly struct SourceRenderObservationScope(
        int entityIndex,
        int componentIndex,
        int componentKind,
        SourceRenderEntityPresentation owner,
        in SourceRenderPhase renderPhase)
    {
        public readonly int EntityIndex = entityIndex;
        public readonly int ComponentIndex = componentIndex;
        public readonly int ComponentKind = componentKind;
        public readonly SourceRenderEntityPresentation Owner = owner;
        public readonly SourceRenderPhase RenderPhase = renderPhase;
        public bool HasDepth => Owner.HasDepth;
        public double ActualDepth => Owner.ActualDepth;
        public bool HasSourceId => Owner.HasSourceId;
        public string Room => Owner.Room;
        public MapEntityId SourceId => Owner.SourceId;

        public SourceRenderObservationScope(int entityIndex, int componentIndex, int componentKind,
            SourceRenderEntityPresentation owner = default) : this(entityIndex, componentIndex, componentKind, owner,
            new(in owner))
        {
        }
    }
}
