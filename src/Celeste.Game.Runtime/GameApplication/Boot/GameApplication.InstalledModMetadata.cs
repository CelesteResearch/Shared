using System;
using Celeste.Everest.Modules.Metadata;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestInstalledModMetadataEnvironment
    {
        private EverestInstalledModMetadataProcess sourceInstalledModMetadata;

        public EverestInstalledModMetadataProcess InstalledModMetadata => sourceInstalledModMetadata ??
                                                                          throw new InvalidOperationException(
                                                                              "The actual installed mod metadata process is not constructed.");

        public void ConstructSourceInstalledModMetadata()
        {
            if (sourceInstalledModMetadata != null)
                throw new InvalidOperationException(
                    "The actual installed mod metadata process is already constructed.");
            sourceInstalledModMetadata = new EverestInstalledModMetadataProcess(this);
        }
    }
}
