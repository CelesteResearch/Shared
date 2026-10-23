namespace Celeste.Scene.Components
{
    public interface ISceneComponentLifecycle
    {
        void Added(object ownerIdentity, SceneComponentTracker tracker);
        void Removed();
        void EntityRemoved();
        void SceneEnd();
    }
}
