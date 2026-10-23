using System;

namespace Celeste.Core.Framework.GarbageCollection
{
    public sealed class SystemGarbageCollectionDevice : ISourceGarbageCollectionDevice
    {
        public static SystemGarbageCollectionDevice Instance { get; } = new();

        private SystemGarbageCollectionDevice()
        {
        }

        public void CollectBackground()
        {
            GC.Collect(1, GCCollectionMode.Forced, false);
        }

        public void CollectOnRoomTransition()
        {
            GC.Collect();
        }

        public void CollectOnReload()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void CollectOnSceneTransition()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
