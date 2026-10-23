using System;

namespace Celeste.Scene.Components
{
    // Complete overrides choose the exact original base point, including no base.
    public interface ISceneComponentRemovedLifecycle
    {
        void Removed(Action baseRemoved);
        void EntityRemoved(object scene, Action baseEntityRemoved);
    }
}
