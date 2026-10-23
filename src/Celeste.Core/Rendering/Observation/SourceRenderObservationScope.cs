namespace Celeste.Core.Rendering.Observation
{
    public readonly struct SourceRenderObservationScope
    {
        public readonly int EntityIndex;
        public readonly int ComponentIndex;
        public readonly int ComponentKind;
        public readonly SourceRenderEntityPresentation Owner;
        public readonly SourceRenderPhase RenderPhase;
        public bool HasDepth => Owner.HasDepth;
        public double ActualDepth => Owner.ActualDepth;
        public bool HasSourceId => Owner.HasSourceId;
        public string Room => Owner.Room;
        public global::Celeste.Core.Maps.MapEntityId SourceId => Owner.SourceId;

        public SourceRenderObservationScope(int entityIndex, int componentIndex, int componentKind,
            SourceRenderEntityPresentation owner = default)
            : this(entityIndex, componentIndex, componentKind, owner, new SourceRenderPhase(in owner))
        {
        }

        public SourceRenderObservationScope(int entityIndex, int componentIndex, int componentKind,
            SourceRenderEntityPresentation owner, in SourceRenderPhase renderPhase)
        {
            EntityIndex = entityIndex;
            ComponentIndex = componentIndex;
            ComponentKind = componentKind;
            Owner = owner;
            RenderPhase = renderPhase;
        }
    }
}
