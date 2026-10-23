using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Runtime.Startup;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        private readonly ISourceEngineContext sourceEngine;
        public readonly List<SourceEverestModule> Modules = [];
        public readonly EverestModuleEventsProcess Events = new();
        private readonly ConcurrentDictionary<Assembly, ConcurrentDictionary<object, Action>> modDetours = new();
        private readonly ConcurrentDictionary<object, Assembly> detourOwners = new();
        private List<string> detourLog = [];
        private SourceModInitializationBatch modInitBatch;
        private byte[] installationHash;

        private EverestStartupRuntimeProcess Runtime =>
            ((IEverestStartupRuntimeEnvironment)sourceEngine).EverestRuntime;

        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)sourceEngine).Logger;
        private IEverestModuleLifecycleEnvironment Lifecycle => (IEverestModuleLifecycleEnvironment)sourceEngine;
        private EverestAssetReloadProcess AssetReload => Lifecycle.AssetReload;

        public SourceEverestModulesProcess(ISourceEngineContext engine)
        {
            sourceEngine = engine;
        }

        public SourceModInitializationBatch BeginInitializationBatch()
        {
            return new(this);
        }
    }
}
