namespace Celeste.Simulation
{
    // The actual tracker component behind a model adapter, never an identity token.
    public interface INpcSceneComponentAdapter
    {
        object SceneComponent { get; }
    }
}
