using System;
using Celeste.Core.Framework.GarbageCollection;

namespace Celeste.Game.Execution.Engine.GarbageCollection
{
    public sealed class OriginalGarbageCollectionPolicy : ISourceGarbageCollectionPolicy
    {
        private readonly ISourceGarbageCollectionDevice device;

        public OriginalGarbageCollectionPolicy(ISourceGarbageCollectionDevice device)
        {
            this.device = device ?? throw new ArgumentNullException(nameof(device));
        }

        public bool ShouldSkipCollection => false;

        public void CollectOnTransition()
        {
            device.CollectOnRoomTransition();
        }

        public void CollectOnReload()
        {
            device.CollectOnReload();
        }

        public void CollectOnSceneTransition()
        {
            device.CollectOnSceneTransition();
        }
    }
}
