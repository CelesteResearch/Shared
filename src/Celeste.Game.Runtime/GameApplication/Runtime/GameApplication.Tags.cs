using System;
using Celeste.Everest.Runtime.Startup;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tagging;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceBitTagEnvironment, IOriginalGameTagsEnvironment,
        IEverestGameTagsEnvironment,
        ISourceGlobalFrozenExecutionTagsEnvironment, ISourcePersistentTransitionExecutionTagsEnvironment
    {
        private SourceBitTagProcessState sourceBitTags;
        private OriginalGameTags sourceOriginalTags;
        private EverestGameTags sourceEverestTags;

        public SourceBitTagProcessState BitTags => sourceBitTags ??
                                                   throw new InvalidOperationException(
                                                       "The actual BitTag process is not constructed.");

        public OriginalGameTags Tags => sourceOriginalTags ??
                                        throw new InvalidOperationException(
                                            "The actual original Tags holder is not constructed.");

        public EverestGameTags EverestTags => sourceEverestTags ??
                                              throw new InvalidOperationException(
                                                  "The actual installed Tags holder is not constructed.");

        ISourceGlobalFrozenExecutionTags ISourceGlobalFrozenExecutionTagsEnvironment.GlobalFrozenExecutionTags => Tags;

        ISourcePersistentTransitionExecutionTags ISourcePersistentTransitionExecutionTagsEnvironment.
            PersistentTransitionExecutionTags => Tags;

        public void ConstructSourceTagProcess()
        {
            if (sourceBitTags != null)
                throw new InvalidOperationException("The actual BitTag process is already constructed.");
            sourceBitTags = new();
            sourceOriginalTags = new();
            if (SourceProfile == GameProfile.InstalledEverest) sourceEverestTags = new();
        }
    }
}
