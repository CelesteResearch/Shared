using System;
using System.Reflection;
using Celeste.Core.Framework.Startup;
using Celeste.Everest.Detours;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Runtime.Compatibility;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceBootDetourEnvironment,
        ISourceBootDetourFrameIdentity, IEverestLegacyAssemblyMetadataEnvironment
    {
        private ISourceBootDetourRuntime sourceBootDetourRuntime;
        private EverestMonoModPoliceProcess sourceMonoModPolice;
        private EverestLegacyMonoModCompatibilityProcess sourceLegacyCompatibility;
        private IEverestLegacyAssemblyMetadataRuntime? sourceLegacyAssemblyMetadataRuntime;

        public ISourceBootDetourRuntime BootDetourRuntime => sourceBootDetourRuntime ??
                                                             throw new InvalidOperationException(
                                                                 "The actual Boot detour runtime is not constructed.");

        public ISourceBootDetourFrameIdentity BootDetourFrameIdentity => this;

        public EverestMonoModPoliceProcess MonoModPolice => sourceMonoModPolice ??
                                                            throw new InvalidOperationException(
                                                                "The actual MonoMod police process is not constructed.");

        public EverestLegacyMonoModCompatibilityProcess LegacyCompatibility => sourceLegacyCompatibility ??
                                                                               throw new InvalidOperationException(
                                                                                   "The actual legacy MonoMod compatibility process is not constructed.");

        public IEverestLegacyAssemblyMetadataRuntime LegacyAssemblyMetadataRuntime =>
            sourceLegacyAssemblyMetadataRuntime ??
            throw new PlatformNotSupportedException(
                "The selected runtime has no qualified actual module load-context metadata capability.");

        public void BindSourceLegacyAssemblyMetadataRuntime(IEverestLegacyAssemblyMetadataRuntime actualRuntime)
        {
            if (actualRuntime == null) throw new ArgumentNullException(nameof(actualRuntime));
            if (sourceLegacyAssemblyMetadataRuntime != null)
                throw new InvalidOperationException(
                    "The actual module load-context metadata capability is already bound.");
            sourceLegacyAssemblyMetadataRuntime = actualRuntime;
        }

        string ISourceBootDetourFrameIdentity.RequireFrameAssemblyIdentity(
            MethodBase method, out bool stopAtHostBoundary)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));
            stopAtHostBoundary = false;
            if (PhysicalIO.HostRuntime is ISourceExternalFrameAssemblyIdentity
                    external
                && external.TryGetExternalFrameAssemblyIdentity(
                    method, out var externalIdentity, out stopAtHostBoundary))
            {
                // The host's deployed PE must match the actual loaded module.
                // RequireModule caches this check by Module; Godot already checks
                // its host assembly during metadata runtime construction.
                if (stopAtHostBoundary) sourceRuntimeModuleMetadata!.RequireModule(method.Module);
                return externalIdentity;
            }

            if (sourceLoader != null && sourceLoader.TryGetRegisteredModFrameAssemblyIdentity(
                    method.Module.Assembly, out var modIdentity))
            {
                // Both context ownership and its registration lease must still exist.
                // Validate the actual method against the context's authenticated PE.
                sourceRuntimeModuleMetadata!.ResolveDefinition(method);
                return modIdentity;
            }

            return Reflection.SourceMethods.TryGetFrameSourceAssemblyIdentity(SourceMembers, method,
                out var sourceIdentity)
                ? sourceIdentity
                : method.Module.Assembly.FullName;
        }

        internal void ConstructSourceInstalledBootDetourOwners()
        {
            if (sourceBootDetourRuntime != null)
                throw new InvalidOperationException("The actual Boot detour owners are already constructed.");
            sourceBootDetourRuntime = new EverestBootDetourRuntime();
            sourceMonoModPolice =
                new(this, Logger);
            var cacheRuntime = new EverestLegacyDynamicDataRuntime();
            var cacheHooks = new EverestLegacyDynamicDataHookProcess(cacheRuntime, sourceMonoModPolice);
            sourceLegacyCompatibility =
                new(cacheHooks,
                    Logger);
        }
    }
}
