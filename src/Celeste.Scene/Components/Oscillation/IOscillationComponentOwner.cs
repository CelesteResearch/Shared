namespace Celeste.Scene.Components.Oscillation
{
    // For existing ordered ComponentList implementations outside SceneComponentTracker.
    public interface IOscillationComponentOwner
    {
        void RemoveOscillationComponent(WigglerComponent component);
    }
}
