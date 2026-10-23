using System;
using Celeste.Core.Components;
using Celeste.Everest.Runtime.Levels.Loading.Entities;
using Celeste.Game.Entities.Metadata;
using Celeste.Game.Profiles;
using Celeste.Scene.Scheduling;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceEntityQueueEnvironment,
        ISourceEntityAddMetadataEnvironment, ISourceEntityListProcessEnvironment
    {
        private ISourceEntityQueuePolicy sourceEntityQueuePolicy;
        private ISourceEntityAddMetadata sourceEntityAddMetadata;
        private SourceEntityListProcessState sourceEntityListProcess;

        public ISourceEntityQueuePolicy EntityQueuePolicy => sourceEntityQueuePolicy ??
                                                             throw new InvalidOperationException(
                                                                 "The selected source EntityList queue policy is not constructed.");

        public ISourceEntityAddMetadata EntityAddMetadata => sourceEntityAddMetadata ??
                                                             throw new InvalidOperationException(
                                                                 "The selected source EntityList metadata policy is not constructed.");

        public SourceEntityListProcessState EntityListProcess => sourceEntityListProcess ??
                                                                 throw new InvalidOperationException(
                                                                     "The source EntityList process is not constructed.");

        internal void ConstructSourceSceneEntityListRoles()
        {
            if (sourceEntityListProcess != null)
                throw new InvalidOperationException("The source EntityList process is already constructed.");
            sourceEntityQueuePolicy = SourceProfile == GameProfile.Original
                ? new OriginalSourceEntityQueuePolicy()
                : new InstalledSourceEntityQueuePolicy();
            sourceEntityAddMetadata = SourceProfile == GameProfile.Original
                ? new OriginalEntityAddMetadata()
                : new EverestEntityAddMetadata(this);
            sourceEntityListProcess = new(BitTags);
        }
    }
}
