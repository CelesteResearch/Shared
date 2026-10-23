using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Sources;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        private SourceEverestModulesProcess ModulesProcess =>
            ((ISourceEverestModulesProcessEnvironment)sourceEngine).ModulesProcess;

        public bool LoadMod(EverestModuleMetadata meta)
        {
            if (meta == null) return true;

            try
            {
                using (new EverestLoadModFinalizer(delegate { ModulesProcess.Events.LoadMod(meta); }))
                {
                    bool shouldLog;
                    if (!string.IsNullOrEmpty(meta.DLL))
                    {
                        if (meta.AssemblyContext == null)
                            meta.AssemblyContext = new(sourceEngine, meta);
                        var assembly = meta.AssemblyContext.LoadAssemblyFromModPath(meta.DLL);
                        if ((object)assembly == null)
                            throw new InvalidOperationException(
                                "Could not load DLL " + meta.DLL + " for mod " + meta.Name);

                        LoadModAssembly(meta, assembly);
                    }
                    else
                    {
                        ModulesProcess.Register(new SourceNullModule(sourceEngine, meta));
                    }

                    ModsWithAssemblyLoadFailures.Remove(meta);
                    ModulesProcess.RegisterMod(meta);
                    shouldLog = true;
                    return shouldLog;
                }
            }
            catch (Exception failure)
            {
                RollbackFailedMod(meta, failure);
                Logger.Log(EverestLogLevel.Error, "loader", "Failed loading mod " + meta.Name);
                Logger.LogDetailed(failure);
                return false;
            }
        }

        private void RollbackFailedMod(EverestModuleMetadata meta, Exception failure)
        {
            ModsWithAssemblyLoadFailures.Add(meta);
            var cleanupFailures = new List<Exception>();
            var context = meta.AssemblyContext;
            meta.AssemblyContext = null;
            if (context != null)
                try
                {
                    context.Dispose();
                }
                catch (Exception cleanupFailure)
                {
                    cleanupFailures.Add(cleanupFailure);
                }

            SourceEverestModule[] ownedModules;
            lock (ModulesProcess.Modules)
            {
                ownedModules = [.. ModulesProcess.Modules.Where(module => ReferenceEquals(module.Metadata, meta))];
            }

            foreach (var module in ownedModules)
                try
                {
                    ModulesProcess.Unregister(module);
                }
                catch (Exception cleanupFailure)
                {
                    cleanupFailures.Add(cleanupFailure);
                }

            if (cleanupFailures.Count != 0)
                failure.Data["EverestModLoadRollbackFailures"] = new AggregateException(cleanupFailures);
        }

        public void LoadModAssembly(EverestModuleMetadata meta, Assembly asm)
        {
            ApplyModHackfixes(meta, asm);
            ((IEverestContentRegistryEnvironment)sourceEngine).SourceContentRegistry.Crawl(
                new AssemblyContentSource(((IEverestContentRegistryEnvironment)sourceEngine).SourceContentRegistry, asm)
                {
                    Mod = meta,
                    Name = meta.Name,
                });
            var typesSafe = ((IEverestLoaderAssemblyEnvironment)sourceEngine).TypeSafety.GetTypesSafe(asm);
            foreach (var type in typesSafe)
                if (typeof(ISourceModuleMetadataProvider).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    var provider = (ISourceModuleMetadataProvider)Activator.CreateInstance(type);
                    provider.Publish(sourceEngine, asm);
                }

            // Publish actual types before module.Load or late Initialize can query
            // their trackers, entities and commands. The assembly lease owns rollback.
            ProcessAssembly(meta, asm, typesSafe);

            var flag = false;
            var array = typesSafe;
            foreach (var type in array)
            {
                SourceEverestModule everestModule = null;
                try
                {
                    if (typeof(SourceEverestModule).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        flag = true;
                        if (!typeof(SourceNullModule).IsAssignableFrom(type))
                            everestModule = (SourceEverestModule)type
                                .GetConstructor([typeof(ISourceEngineContext)])
                                .Invoke([sourceEngine]);
                    }
                }
                catch (TypeLoadException value)
                {
                    const string text = "loader";
                    var tag2 = text;
                    var sourceLog2 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Warn);
                    if (sourceLog2.ShouldLog)
                        sourceLog2.Write("Skipping type '" + type.FullName +
                                         "' likely depending on optional dependency: " + value);
                }

                if (everestModule != null)
                {
                    everestModule.Metadata = meta;
                    ModulesProcess.Register(everestModule);
                }
            }

            if (!flag) Logger.Log(EverestLogLevel.Warn, "loader", "Assembly doesn't contain an SourceEverestModule!");
        }
    }
}
