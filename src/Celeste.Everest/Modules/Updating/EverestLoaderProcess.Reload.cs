using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Modules.Runtime.Assemblies;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        public void ReloadMod(EverestModuleMetadata meta)
        {
            if (meta.AssemblyContext == null)
            {
                return;
            }

            ((IEverestLoaderContentEnvironment)sourceEngine).QueuedTasks.Do("ReloadModAssembly: " + meta.Name, delegate
            {
                string tag = "loader";
#pragma warning disable CS0168
                bool shouldLog;
#pragma warning restore CS0168
                var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Info);
                if (sourceLog1.ShouldLog) sourceLog1.Write("Reloading mod assemblies: " + (meta.Name));
                ((IEverestAssetReloadEnvironment)sourceEngine).AssetReload.Do(
                    ((IOriginalGameTextEnvironment)sourceEngine).Text.CleanDialog(
                        "ASSETRELOADHELPER_RELOADINGMODASSEMBLY") + " " + meta.Name, delegate
                    {
                        List<EverestModuleMetadata> reloadMods = new List<EverestModuleMetadata>();
                        Dictionary<string, List<SourceEverestModule>> revDeps;
                        HashSet<string> visited;
                        lock (Modules)
                        {
                            revDeps = new Dictionary<string, List<SourceEverestModule>>();
                            Modules.ForEach(delegate(SourceEverestModule mod)
                            {
                                revDeps.TryAdd(mod.Metadata.Name, new List<SourceEverestModule>());
                            });
                            foreach (SourceEverestModule module in Modules)
                            {
                                IEnumerable<SourceEverestModuleAssemblyContext> enumerable =
                                    module.Metadata.AssemblyContext?.ActiveDependencyContexts;
                                foreach (SourceEverestModuleAssemblyContext item in enumerable ??
                                         Enumerable.Empty<SourceEverestModuleAssemblyContext>())
                                {
                                    revDeps.GetValueOrDefault(item.ModuleMeta.Name)?.Add(module);
                                }
                            }

                            visited = new HashSet<string>();
                            VisitMod(meta);
                        }
#pragma warning disable CS0168
                        bool shouldLog2;
#pragma warning restore CS0168
                        foreach (EverestModuleMetadata item2 in reloadMods)
                        {
                            string text = "loader";
                            string tag2 = text;
                            var sourceLog2 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Verbose);
                            if (sourceLog2.ShouldLog) sourceLog2.Write("-> unloading: " + (item2.Name));
                            item2.AssemblyContext?.Dispose();
                            item2.AssemblyContext = null;
                            item2.InvalidateHash();
                        }

                        using (((ISourceEverestModulesProcessEnvironment)sourceEngine).ModulesProcess
                               .BeginInitializationBatch())
                        {
                            foreach (EverestModuleMetadata item3 in Enumerable.Reverse(reloadMods))
                            {
                                if (item3.Dependencies.Any((EverestModuleMetadata dep) => !DependencyLoaded(dep)))
                                {
                                    string text = "loader";
                                    string tag3 = text;
                                    var sourceLog3 = Logger.BeginEnabledMessage(tag3, EverestLogLevel.Warn);
                                    if (sourceLog3.ShouldLog)
                                        sourceLog3.Write("-> skipping reload of mod '" + (item3.Name) +
                                                         "' as dependency failed to load");
                                }
                                else
                                {
                                    string text = "loader";
                                    string tag4 = text;
                                    var sourceLog4 = Logger.BeginEnabledMessage(tag4, EverestLogLevel.Verbose);
                                    if (sourceLog4.ShouldLog) sourceLog4.Write("-> reloading: " + (item3.Name));
                                    if (!LoadMod(item3))
                                    {
                                        text = "loader";
                                        string tag5 = text;
                                        var sourceLog5 = Logger.BeginEnabledMessage(tag5, EverestLogLevel.Warn);
                                        if (sourceLog5.ShouldLog)
                                            sourceLog5.Write("-> failed to reload mod '" + (item3.Name) + "'!");
                                    }
                                }
                            }
                        }

                        void VisitMod(EverestModuleMetadata node)
                        {
                            if (visited.Add(node.Name))
                            {
                                revDeps[node.Name].ForEach(delegate(SourceEverestModule revDep)
                                {
                                    VisitMod(revDep.Metadata);
                                });
                                reloadMods.Add(node);
                            }
                        }
                    },
                    delegate
                    {
                        ((IEverestAssetReloadEnvironment)sourceEngine).AssetReload.ReloadLevel(forceReload: true);
                    });
            });
        }
    }
}
