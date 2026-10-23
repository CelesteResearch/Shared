using System;

namespace Celeste.Scene.Components
{
    // Optional component EntityAdded override. Call baseEntityAdded at its original
    // base point to publish this component to Tracker, then preserve custom order.
    public interface ISceneComponentEntityAddedLifecycle
    {
        void EntityAdded(object scene, Action baseEntityAdded);
    }
}
