using System;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Diagnostics.CriticalErrors;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Content.Extensions.Decals;
using Celeste.Graphics.Content;

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
            sourceCriticalErrors = new EverestCriticalErrorHandlerProcess(this,
                ((IEverestLoggerProcessEnvironment)this).Logger,
                ((ISourceSceneCatalogEnvironment)this).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)this).PlainScenePolicy, SaveContext);
        }

        public void ConstructSourceAssetReload()
        {
            if (sourceAssetReload != null)
                throw new InvalidOperationException("The actual asset reload process is already constructed.");
            var synchronization = new EverestAssetReloadSynchronization();
            var process = new EverestAssetReloadProcess(this, MainThreadProcess,
                ProcessTiming, ((IEverestLoggerProcessEnvironment)this).Logger,
                new EverestAssetReloadEvents(), CriticalErrors,
                ((ISourceSceneCatalogEnvironment)this).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)this).PlainScenePolicy, synchronization);
            sourceReloadSynchronization = synchronization;
            sourceAssetReload = process;
        }

        public void ConstructSourceDecalRegistry()
        {
            if (sourceDecalRegistry != null)
                throw new InvalidOperationException("The actual decal registry is already constructed.");
            sourceDecalRegistry = new EverestDecalRegistry(this, SourceContentRegistry,
                (ISourceGameGraphicsEnvironment)this, ((IEverestLoggerProcessEnvironment)this).Logger,
                new EverestDecalFeatureContext(this), AssetReload);
        }
    }
}
