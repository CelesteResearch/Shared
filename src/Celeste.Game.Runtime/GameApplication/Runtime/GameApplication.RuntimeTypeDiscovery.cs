using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Components;
using Celeste.Core.Reflection;
using Celeste.Everest.Diagnostics.Commands;
using Celeste.Everest.Reflection.Runtime;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication :
        ISourceRuntimeTypeDiscoveryEnvironment
    {
        public SourceRuntimeTypeDiscovery RuntimeTypeDiscovery { get; } = new();

        public IDisposable RegisterRuntimeAssemblyTypes(Assembly assembly, Type[] types)
        {
            return RuntimeAssemblyTypeRegistration.Register(RuntimeTypeDiscovery, assembly, types,
                definitions => SceneCatalog.RegisterOwnedRuntimeTypes(assembly,
                    definitions.Where(IsUnqualifiedRuntimeSceneType)),
                RebuildRuntimeTypeTracker, RefreshRuntimeTypeConsumers);
        }

        private bool IsUnqualifiedRuntimeSceneType(ISourceTypeMetadata metadata)
        {
            var actualType = metadata.RequireActualType();
            if (!typeof(SceneEntityState).IsAssignableFrom(actualType) &&
                !typeof(SourceComponentState).IsAssignableFrom(actualType)) return false;
            if (!SourceMembers.ContainsSourceType(actualType)) return true;
            var source = SourceMembers.GetOriginalTypeDefinition(actualType);
            var logical = SceneCatalog.Find(actualType);
            if (logical == null || logical.Identity != source.Identity ||
                logical.LogicalAssemblyIdentity != source.AssemblyIdentity ||
                logical.LogicalMetadataToken != source.MetadataToken)
                throw new InvalidOperationException(
                    "The canonical scene type does not own its exact source tracker definition: " + actualType);
            return false;
        }

        private void RebuildRuntimeTypeTracker()
        {
            // Tracker initialization precedes module Initialize callbacks. A callback can fail
            // before Everest marks all modules initialized, so rollback must still rebuild
            // an existing tracker. Before its first initialization keep the boot phase deferred.
            if (TrackerInitialization.TrackedEntityTypes != null) TrackerInitialization.Initialize();
        }

        public void RefreshRuntimeTypeConsumers()
        {
            if (!EverestRuntime.IsInitialized) return;
            var failures = new List<Exception>();
            RefreshRuntimeTypeConsumer(SceneCatalog.PublishSourceTrackerOutputs, failures);
            RefreshRuntimeTypeConsumer(() =>
            {
                if (Frame.Scenes.CurrentScene is ISourceScene scene && scene.SourceScene != null)
                    SceneEntityRegistry.Refresh(scene.SourceScene, true);
            }, failures);
            RefreshRuntimeTypeConsumer(() =>
            {
                if (CommandsOrNull is SourceEverestCommands commands) commands.ReloadCommandsList();
            }, failures);
            if (failures.Count != 0)
                throw new AggregateException("Runtime type consumers could not all be refreshed.", failures);
        }

        private static void RefreshRuntimeTypeConsumer(Action refresh, List<Exception> failures)
        {
            try
            {
                refresh();
            }
            catch (Exception failure)
            {
                failures.Add(failure);
            }
        }
    }
}
