using System;
using Celeste.Core.Components;

namespace Celeste.Scene.Components.Events
{
    public sealed class SourceEntityRemovedListener : SourceComponentState
    {
        public Action OnEntityRemoved;

        public SourceEntityRemovedListener(Action onEntityRemoved) : base(false, false)
        {
            OnEntityRemoved = onEntityRemoved;
        }

        public override void EntityRemoved(object scene)
        {
            base.EntityRemoved(scene);
            OnEntityRemoved?.Invoke();
        }
    }
}
