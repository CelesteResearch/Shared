using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Startup;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        private List<SourceEverestModule> Modules =>
            ((ISourceEverestModulesProcessEnvironment)sourceEngine).ModulesProcess.Modules;

        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)sourceEngine).Logger;

        public bool DependenciesLoaded(EverestModuleMetadata meta)
        {
            foreach (var dependency in meta.Dependencies)
                if (!DependencyLoaded(dependency))
                    return false;

            foreach (var dep in meta.OptionalDependencies)
                if (!DependencyLoaded(dep) && (enforceOptionalDependencies ||
                                               Modules.Any(mod =>
                                                   mod.Metadata?.Name == dep.Name)))
                    return false;

            return true;
        }

        public bool DependencyLoaded(EverestModuleMetadata dep)
        {
            SourceEverestModule module;
            return TryGetDependency(dep, out module);
        }

        public bool TryGetDependency(EverestModuleMetadata dep, out SourceEverestModule module)
        {
            var name = dep.Name;
            var version = dep.Version;
            if (name == "EverestCore") name = ((IEverestCoreModuleEnvironment)sourceEngine).CoreModule.Metadata.Name;

            lock (Modules)
            {
                foreach (var module2 in Modules)
                {
                    var metadata = module2.Metadata;
                    if (ModsWithAssemblyLoadFailures.Contains(metadata)) continue;
                    if (!(metadata.Name != name))
                    {
                        var version2 = metadata.Version;
                        if (VersionSatisfiesDependency(version, version2))
                        {
                            module = module2;
                            return true;
                        }
                    }
                }
            }

            module = null;
            return false;
        }

        public static bool VersionSatisfiesDependency(Version requiredVersion, Version installedVersion)
        {
            if (installedVersion.Major == 0 && installedVersion.Minor == 0) return true;

            if (installedVersion.Major != requiredVersion.Major) return false;

            if (installedVersion.Minor < requiredVersion.Minor) return false;

            if (installedVersion.Minor == requiredVersion.Minor &&
                installedVersion.Build < requiredVersion.Build) return false;

            if (installedVersion.Minor == requiredVersion.Minor && installedVersion.Build == requiredVersion.Build &&
                installedVersion.Revision < requiredVersion.Revision)
                return false;

            return true;
        }

        public void LoadModDelayed(EverestModuleMetadata meta, Action callback)
        {
            if (meta == null)
            {
                callback?.Invoke();
                return;
            }

            if (Modules.Any(module => module.Metadata.Name == meta.Name))
            {
                const string text = "loader";
                var tag = text;
                var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Warn);
                if (sourceLog1.ShouldLog) sourceLog1.Write("Mod " + meta.Name + " already loaded!");
                return;
            }

            foreach (var dependency in meta.Dependencies)
                if (!DependencyLoaded(dependency))
                {
                    const string text = "loader";
                    var tag2 = text;
                    var sourceLog2 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Info);
                    if (sourceLog2.ShouldLog)
                        sourceLog2.Write("Dependency " + dependency + " of mod " + meta + " not loaded! Delaying.");
                    lock (Delayed)
                    {
                        Delayed.Add(Tuple.Create(meta, callback));
                        return;
                    }
                }

            foreach (var dep in meta.OptionalDependencies)
                if (!DependencyLoaded(dep) && (enforceOptionalDependencies ||
                                               Modules.Any(module =>
                                                   module.Metadata?.Name == dep.Name)))
                {
                    const string text = "loader";
                    var tag3 = text;
                    var sourceLog3 = Logger.BeginEnabledMessage(tag3, EverestLogLevel.Info);
                    if (sourceLog3.ShouldLog)
                        sourceLog3.Write(
                            "Optional dependency " + dep + " of mod " + meta + " not loaded! Delaying.");
                    lock (Delayed)
                    {
                        Delayed.Add(Tuple.Create(meta, callback));
                        return;
                    }
                }

            callback?.Invoke();
            ((IEverestSplashEnvironment)sourceEngine).Splash.IncreaseLoadedModCount(meta.Name);
            LoadMod(meta);
        }

        internal void CheckDependenciesOfDelayedMods()
        {
            if (Interlocked.CompareExchange(ref DelayedLock, 1, 0) != 0) return;

            try
            {
                lock (Delayed)
                {
                    var flag = true;
                    var flag2 = false;
                    for (var i = 0; i < Delayed.Count; i++)
                    {
                        var entry = Delayed[i];
                        if (DependenciesLoaded(entry.Item1))
                        {
                            if (flag && checkIfOneOfDependenciesIsDelayedAndCanBeLoaded(
                                    entry.Item1.OptionalDependencies,
                                    [entry.Item1]))
                            {
                                flag2 = true;
                            }
                            else
                            {
                                var text = "core";
                                var tag = text;
                                var sourceLog1 = Logger.BeginEnabledMessage(tag, EverestLogLevel.Info);
                                if (sourceLog1.ShouldLog)
                                    sourceLog1.Write("Dependencies of mod " + entry.Item1 +
                                                     " are now satisfied: loading");
                                ((IEverestSplashEnvironment)sourceEngine).Splash.IncreaseLoadedModCount(
                                    entry.Item1.Name);
                                if (Modules.Any(mod => mod.Metadata.Name == entry.Item1.Name))
                                {
                                    text = "core";
                                    var tag2 = text;
                                    var sourceLog2 = Logger.BeginEnabledMessage(tag2, EverestLogLevel.Warn);
                                    if (sourceLog2.ShouldLog)
                                        sourceLog2.Write("Mod " + entry.Item1.Name + " already loaded!");
                                }
                                else
                                {
                                    entry.Item2?.Invoke();
                                    LoadMod(entry.Item1);
                                }

                                Delayed.RemoveAt(i);
                                i = -1;
                                flag2 = false;
                            }
                        }

                        if (i == Delayed.Count - 1 && flag2)
                        {
                            Logger.Warn("core",
                                "Mods with unsatisfied optional dependencies were delayed but never loaded (probably due to circular optional dependencies), forcing them to load!");
                            flag = false;
                            i = -1;
                            flag2 = false;
                        }
                    }
                }
            }
            finally
            {
                Interlocked.Decrement(ref DelayedLock);
            }
        }

        private bool checkIfOneOfDependenciesIsDelayedAndCanBeLoaded(List<EverestModuleMetadata> dependencies,
            HashSet<EverestModuleMetadata> alreadyChecked)
        {
            foreach (var dependency in dependencies)
            {
                if (DependencyLoaded(dependency) || alreadyChecked.Contains(dependency)) continue;

                var everestModuleMetadata = Delayed
                    .FirstOrDefault(item => item.Item1.Name == dependency.Name)
                    ?.Item1;
                if (everestModuleMetadata != null && !alreadyChecked.Contains(everestModuleMetadata))
                {
                    if (DependenciesLoaded(everestModuleMetadata)) return true;

                    alreadyChecked.Add(everestModuleMetadata);
                    if (checkIfOneOfDependenciesIsDelayedAndCanBeLoaded(everestModuleMetadata.Dependencies,
                            alreadyChecked) ||
                        checkIfOneOfDependenciesIsDelayedAndCanBeLoaded(everestModuleMetadata.OptionalDependencies,
                            alreadyChecked))
                        return true;
                }
            }

            return false;
        }
    }
}
