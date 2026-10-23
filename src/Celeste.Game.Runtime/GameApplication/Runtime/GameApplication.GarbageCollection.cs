using System;
using Celeste.Core.Framework.GarbageCollection;
using Celeste.Everest.Runtime.Levels.GarbageCollection;
using Celeste.Game.Execution.Engine.GarbageCollection;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceGarbageCollectionEnvironment
    {
        private readonly ISourceGarbageCollectionPolicy sourceGarbageCollectionPolicy;
        public ISourceGarbageCollectionPolicy GarbageCollectionPolicy => sourceGarbageCollectionPolicy;

        public EverestLevelGarbageCollectionProcess InstalledLevelGarbageCollection
            => sourceGarbageCollectionPolicy as EverestLevelGarbageCollectionProcess
               ?? throw new InvalidOperationException(
                   "The original profile has no installed Level garbage collection process.");

        private ISourceGarbageCollectionPolicy CreateSourceGarbageCollectionPolicy(
            ISourceGarbageCollectionDevice garbageCollection)
            => SourceProfile == GameProfile.InstalledEverest
                ? new EverestLevelGarbageCollectionProcess(this, () => QueuedTasks, garbageCollection)
                : new OriginalGarbageCollectionPolicy(garbageCollection ?? SystemGarbageCollectionDevice.Instance);
    }
}
