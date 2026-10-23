using System;
using System.Collections.Generic;
using System.Reflection;
using Celeste.Everest.Modules.Updating;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        private static void TryCleanup(Action cleanup, List<Exception> failures)
        {
            try
            {
                cleanup();
            }
            catch (Exception failure)
            {
                failures.Add(failure);
            }
        }

        private void InitializeModule(SourceEverestModule module)
        {
            try
            {
                module.Initialize();
            }
            catch (Exception failure)
            {
                RollbackModule(module, failure);
                throw;
            }
        }

        internal void LoadModuleContent(SourceEverestModule module, bool firstLoad)
        {
            try
            {
                module.LoadContent(firstLoad);
            }
            catch (Exception failure)
            {
                RollbackModule(module, failure);
                throw;
            }
        }

        private void RollbackModule(SourceEverestModule module, Exception failure)
        {
            lock (Modules)
            {
                if (!Modules.Contains(module))
                    return;
            }

            var cleanupFailures = new List<Exception>();
            TryCleanup(() => Unregister(module), cleanupFailures);
            bool ownerStillActive;
            var assembly = module.GetType().Assembly;
            lock (Modules)
            {
                ownerStillActive = Modules.Exists(candidate => candidate.GetType().Assembly == assembly);
            }

            if (!ownerStillActive)
                TryCleanup(() => ReleaseAssembly(assembly), cleanupFailures);
            if (cleanupFailures.Count != 0)
                failure.Data["EverestModuleRollbackFailures"] = new AggregateException(cleanupFailures);
        }

        private void ReleaseAssembly(Assembly assembly)
        {
            var failures = new List<Exception>();
            TryCleanup(() => ((IEverestLoaderProcessEnvironment)sourceEngine).Loader
                .ReleaseAssemblyRegistrations(assembly), failures);
            if (modDetours.TryRemove(assembly, out var detours))
                foreach (var pair in detours)
                {
                    detourOwners.TryRemove(pair.Key, out _);
                    TryCleanup(pair.Value, failures);
                }

            if (failures.Count != 0) throw new AggregateException("Assembly cleanup failed.", failures);
        }
    }
}
