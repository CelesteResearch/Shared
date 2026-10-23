namespace Celeste.Scene.Tracking
{
    // Scene.Remove fills its EntityList queue; it does not execute Removed now.
    public interface ISceneEntityRemovalScene
    {
        bool RemoveEntity(object identity);
    }
}
