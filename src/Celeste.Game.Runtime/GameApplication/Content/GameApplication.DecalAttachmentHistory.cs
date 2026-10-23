using Celeste.Everest.Content.Extensions.Decals;
using Celeste.Everest.Modules.Core;
using Celeste.Simulation.Presentation.Decals.Entities;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceDecalAttachmentHistoryEnvironment
    {
        private EverestDecalAttachmentHistory sourceDecalAttachmentHistory;

        public ISourceDecalAttachmentHistory DecalAttachmentHistory => sourceDecalAttachmentHistory ??=
            new(() => (SourceCoreModuleSession)ActualCoreModule._Session);
    }
}
