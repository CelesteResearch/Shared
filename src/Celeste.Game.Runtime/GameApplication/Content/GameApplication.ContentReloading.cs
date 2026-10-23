using System;
using Celeste.Everest.Content.Extensions.Decals;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Diagnostics.CriticalErrors;
using Celeste.Game.Execution.Areas;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestDecalRegistryEnvironment,
        IEverestAssetReloadEnvironment, ISourceAreaReloadLockEnvironment
    {
        private EverestCriticalErrorHandlerProcess sourceCriticalErrors;
        private EverestAssetReloadProcess sourceAssetReload;
        private EverestDecalRegistry sourceDecalRegistry;
        private EverestAssetReloadSynchronization sourceReloadSynchronization;

        public EverestCriticalErrorHandlerProcess CriticalErrors => sourceCriticalErrors ??
                                                                    throw new InvalidOperationException(
                                                                        "The actual critical error process is not constructed.");

        public EverestAssetReloadProcess AssetReload => sourceAssetReload ??
                                                        throw new InvalidOperationException(
                                                            "The actual asset reload process is not constructed.");

        public EverestDecalRegistry DecalRegistry => sourceDecalRegistry ??
                                                     throw new InvalidOperationException(
                                                         "The actual decal registry is not constructed.");

        object ISourceAreaReloadLockEnvironment.AreaReloadLock =>
            (sourceReloadSynchronization ??
             throw new InvalidOperationException("The actual asset reload synchronization is not constructed."))
            .AreaReloadLock;

        public void ConstructSourceCriticalErrors()
        {
            if (sourceCriticalErrors != null)
                throw new InvalidOperationException("The actual critical error process is already constructed.");
            sourceCriticalErrors = new(this,
                Logger,
                SceneCatalog,
                PlainScenePolicy, SaveContext);
        }

        public void ConstructSourceAssetReload()
        {
            if (sourceAssetReload != null)
                throw new InvalidOperationException("The actual asset reload process is already constructed.");
            var synchronization = new EverestAssetReloadSynchronization();
            var process = new EverestAssetReloadProcess(this, MainThreadProcess,
                ProcessTiming, Logger,
                new(), CriticalErrors,
                SceneCatalog,
                PlainScenePolicy, synchronization);
            sourceReloadSynchronization = synchronization;
            sourceAssetReload = process;
        }

        public void ConstructSourceDecalRegistry()
        {
            if (sourceDecalRegistry != null)
                throw new InvalidOperationException("The actual decal registry is already constructed.");
            sourceDecalRegistry = new(this, SourceContentRegistry,
                this, Logger,
                new(this), AssetReload);
        }
    }
}
