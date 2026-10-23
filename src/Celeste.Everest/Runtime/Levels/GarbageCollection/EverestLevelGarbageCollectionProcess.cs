using System;
using Celeste.Core.Framework.GarbageCollection;
using Celeste.Core.Threading;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Tasks.Queuing;

namespace Celeste.Everest.Runtime.Levels.GarbageCollection
{
    public sealed class EverestLevelGarbageCollectionProcess : ISourceGarbageCollectionPolicy,
        ISourceTypeInitializationFactory<object>
    {
        private readonly IEverestCoreSettingsEnvironment settings;
        private readonly Func<QueuedTaskScheduler> queuedTasks;
        private readonly Action collectBackground;
        private readonly Action collectOnReload;
        private readonly Action collectOnSceneTransition;
        private readonly SourceTypeInitialization<object> collectionLock;

        public EverestLevelGarbageCollectionProcess(IEverestCoreSettingsEnvironment actualSettings,
            Func<QueuedTaskScheduler> actualQueuedTasks, ISourceGarbageCollectionDevice actualGarbageCollection = null)
        {
            settings = actualSettings ?? throw new ArgumentNullException(nameof(actualSettings));
            queuedTasks = actualQueuedTasks ?? throw new ArgumentNullException(nameof(actualQueuedTasks));
            var device = actualGarbageCollection ?? SystemGarbageCollectionDevice.Instance;
            collectBackground = device.CollectBackground;
            collectOnReload = device.CollectOnReload;
            collectOnSceneTransition = device.CollectOnSceneTransition;
            collectionLock = new SourceTypeInitialization<object>("Celeste.Level", this);
        }

        public bool ShouldSkipCollection => false;

        public void CollectOnTransition() => Collect();

        public void CollectOnReload() => collectOnReload();

        public void CollectOnSceneTransition() => collectOnSceneTransition();

        public void Collect()
        {
            if (!settings.CurrentCoreSettings.MultithreadedGC == true)
            {
                GC.Collect();
                return;
            }

            queuedTasks().Do(collectionLock.Value,
                collectBackground);
        }

        object ISourceTypeInitializationFactory<object>.Allocate()
            => Tuple.Create(new object(), "Level Transition GC.Collect");

        void ISourceTypeInitializationFactory<object>.Initialize(object instance)
        {
            // The source field initializer is fully executed by Allocate.
        }
    }
}
