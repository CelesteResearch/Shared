using System;
using Celeste.Core.Framework.GarbageCollection;
using Celeste.Everest.Runtime.Levels.GarbageCollection;
using Celeste.Game.Execution.Engine.GarbageCollection;
using Celeste.Game.Profiles;
using JetBrains.Annotations;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceGarbageCollectionEnvironment
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly ISourceGarbageCollectionPolicy sourceGarbageCollectionPolicy;

        public ISourceGarbageCollectionPolicy GarbageCollectionPolicy => sourceGarbageCollectionPolicy;

        public EverestLevelGarbageCollectionProcess InstalledLevelGarbageCollection
            => sourceGarbageCollectionPolicy as EverestLevelGarbageCollectionProcess
               ?? throw new InvalidOperationException(
                   "The original profile has no installed Level garbage collection process.");

        private ISourceGarbageCollectionPolicy CreateSourceGarbageCollectionPolicy(
            ISourceGarbageCollectionDevice garbageCollection)
        {
            return SourceProfile == GameProfile.InstalledEverest
                ? new EverestLevelGarbageCollectionProcess(this, () => QueuedTasks, garbageCollection)
                : new OriginalGarbageCollectionPolicy(garbageCollection ?? SystemGarbageCollectionDevice.Instance);
        }
    }
}
