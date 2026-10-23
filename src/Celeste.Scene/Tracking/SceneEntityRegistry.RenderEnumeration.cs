namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        internal SceneEntityRenderEnumerable CommittedRenderEntities => new(entities);
    }
}
