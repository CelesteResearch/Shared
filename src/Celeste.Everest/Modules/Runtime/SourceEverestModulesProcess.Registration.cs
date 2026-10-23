using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Everest.Content.Maps.Processing;
using Celeste.Everest.Diagnostics.Commands;
using Celeste.Everest.Reflection;
using Celeste.Everest.Reflection.Runtime;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Tracking.Initialization;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        public void Register(SourceEverestModule module)
        {
            lock (Modules)
            {
                Modules.Add(module);
            }

            try
            {
                module.LoadSettings();
                module.Load();
                if (Runtime.ContentLoaded) module.LoadContent(true);

                if (Runtime.Initialized)
                {
                    if (modInitBatch != null)
                        modInitBatch.LateInitializeModule(module);
                    else
                        LateInitializeModules(Enumerable.Repeat(module, 1));
                }

                module.LogRegistration();
                Events.RegisterModule(module);
            }
            catch (Exception failure)
            {
                RollbackModule(module, failure);
                throw;
            }
        }

        internal void LateInitializeModules(IEnumerable<SourceEverestModule> modules)
        {
            modules = (SourceEverestModule[])[.. modules];
            ((ISourceTrackerInitializationEnvironment)sourceEngine).TrackerInitialization.Initialize();
            ((ISourceRuntimeTypeDiscoveryEnvironment)sourceEngine)
                .RefreshRuntimeTypeConsumers();
            foreach (var module in modules) InitializeModule(module);

            Lifecycle.ActualInput.Initialize();
            ((SourceEverestCommands)
                ((ISourceCommandsProcessEnvironment)sourceEngine).Commands).ReloadCommandsList();
            if (((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave != null)
                foreach (var module2 in modules)
                {
                    var text = "core";
                    var tag = text;
                    var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Verbose);
                    if (sourceLog1.ShouldLog)
                        sourceLog1.Write("Loading save data slot " +
                                         ((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave.FileSlot +
                                         " for " + module2.Metadata);
                    if (module2.SaveDataAsync)
                    {
                        module2.DeserializeSaveData(
                            ((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave.FileSlot,
                            module2.ReadSaveData(((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave
                                .FileSlot));
                    }
                    else
                    {
#pragma warning disable CS0618
                        // Preserve original legacy module override dispatch.
                        module2.LoadSaveData(((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave.FileSlot);
#pragma warning restore CS0618
                    }

                    var currentSessionSafe =
                        ((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave.CurrentSessionSafe;
                    if (currentSessionSafe != null && currentSessionSafe.InArea)
                    {
                        text = "core";
                        var tag2 = text;
                        var sourceLog2 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Verbose);
                        if (sourceLog2.ShouldLog)
                            sourceLog2.Write("Loading session slot " +
                                             ((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave
                                             .FileSlot +
                                             " for " + module2.Metadata);
                        if (module2.SaveDataAsync)
                        {
                            module2.DeserializeSession(
                                ((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave.FileSlot,
                                module2.ReadSession(((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave
                                    .FileSlot));
                        }
                        else
                        {
#pragma warning disable CS0618
                            // Preserve original legacy module override dispatch.
                            module2.LoadSession(
                                ((IOriginalGameplayProcess)sourceEngine).SaveContext.CurrentSave.FileSlot,
                                false);
#pragma warning restore CS0618
                        }
                    }
                }

            foreach (var module3 in modules)
                if (module3.GetType().GetMethod("PrepareMapDataProcessors", [typeof(EverestMapDataFixup)])
                        ?.DeclaringType == module3.GetType())
                {
                    var text = "core";
                    var tag3 = text;
                    var sourceLog3 = Logger.BeginEnabledMessage(tag3, EverestLogLevel.Verbose);
                    if (sourceLog3.ShouldLog)
                        sourceLog3.Write("Module " + module3.Metadata + " has map data processors: reloading maps.");
                    TriggerModInitMapReload();
                    break;
                }
        }

        internal void TriggerModInitMapReload()
        {
            if (modInitBatch != null)
                modInitBatch.ReloadMaps();
            else
                AssetReload.ReloadAllMaps();
        }

        internal void Unregister(SourceEverestModule module)
        {
            lock (Modules)
            {
                if (!Modules.Remove(module)) return;
            }

            var failures = new List<Exception>();
            TryCleanup(module.OnInputDeregister, failures);
            TryCleanup(module.Unload, failures);
            if (!(module is SourceNullModule))
            {
                var members = ((ISourceEverestReflectionEnvironment)sourceEngine)
                    .Reflection.SourceMembers;
                if (members.ContainsSourceType(module.GetType()))
                {
                    TryCleanup(() => Lifecycle.EntityRegistry.OnModAssemblyUnload(
                        members.GetOriginalTypeDefinition(module.GetType()).AssemblyIdentity), failures);
                }
                else
                {
                    bool ownerStillActive;
                    var assembly = module.GetType().Assembly;
                    lock (Modules)
                    {
                        ownerStillActive = Modules.Exists(candidate => candidate.GetType().Assembly == assembly);
                    }

                    if (!ownerStillActive)
                        TryCleanup(() => Lifecycle.EntityRegistry.OnModAssemblyUnload(assembly), failures);
                }
            }

            if (Runtime.Initialized)
                TryCleanup(() => ((SourceEverestCommands)
                    ((ISourceCommandsProcessEnvironment)sourceEngine).Commands).ReloadCommandsList(), failures);
            InvalidateInstallationHash();
            TryCleanup(module.LogUnregistration, failures);
            if (failures.Count != 0) throw new AggregateException("Module unload failed.", failures);
        }

        public void UnloadAssembly(EverestModuleMetadata meta, Assembly asm)
        {
            SourceEverestModule[] ownedModules;
            lock (Modules)
            {
                ownedModules = [.. Modules.Where(module => module.GetType().Assembly == asm)];
            }

            var failures = new List<Exception>();
            foreach (var module in ownedModules)
                TryCleanup(() => Unregister(module), failures);
            TryCleanup(() => ReleaseAssembly(asm), failures);
            if (failures.Count != 0) throw new AggregateException("Assembly unload failed.", failures);
        }
    }
}
