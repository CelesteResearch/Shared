using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Processing;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Content.Extensions.Entities.Registry;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Types.Maps;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Updating;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Tracking.Initialization;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        private readonly ISourceEngineContext sourceEngine;
        public readonly List<SourceEverestModule> Modules = new();
        public readonly EverestModuleEventsProcess Events = new();
        private readonly ConcurrentDictionary<Assembly, ConcurrentDictionary<object, Action>> modDetours = new();
        private readonly ConcurrentDictionary<object, Assembly> detourOwners = new();
        private List<string> detourLog = new();
        private SourceModInitializationBatch modInitBatch;
        private byte[] installationHash;

        private EverestStartupRuntimeProcess Runtime =>
            ((IEverestStartupRuntimeEnvironment)sourceEngine).EverestRuntime;

        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)sourceEngine).Logger;
        private IEverestModuleLifecycleEnvironment Lifecycle => (IEverestModuleLifecycleEnvironment)sourceEngine;
        private EverestAssetReloadProcess AssetReload => Lifecycle.AssetReload;
        public SourceEverestModulesProcess(ISourceEngineContext engine) => sourceEngine = engine;
        public SourceModInitializationBatch BeginInitializationBatch() => new(this);
    }
}
