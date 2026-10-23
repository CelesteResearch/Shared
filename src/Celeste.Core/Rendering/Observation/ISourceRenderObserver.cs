namespace Celeste.Core.Rendering.Observation
{
    public interface ISourceRenderObserver
    {
        SourceRenderObservationScope EnterEntity(int entityIndex, in SourceRenderEntityPresentation owner);
        SourceRenderObservationScope EnterNestedEntity(int entityIndex, in SourceRenderEntityPresentation owner);
        SourceRenderObservationScope EnterComponent(object component, int componentIndex);
        void Exit(in SourceRenderObservationScope previous);
    }
}
