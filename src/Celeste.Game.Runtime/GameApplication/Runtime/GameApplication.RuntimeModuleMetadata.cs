using System;
using System.IO;
using System.Reflection;
using Celeste.Everest.Modules.Runtime.Assemblies;
using Celeste.Everest.Runtime.Assemblies;
using Celeste.Everest.Runtime.Compatibility;


namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private SourceRuntimeModuleMetadata sourceRuntimeModuleMetadata;

        public SourceRuntimeModuleMetadata RuntimeModuleMetadata =>
            sourceRuntimeModuleMetadata ??
            throw new InvalidOperationException("The physical runtime module reader is not constructed.");

        private void ConstructSourceRuntimeModuleMetadata()
        {
            if (sourceRuntimeModuleMetadata != null)
                throw new InvalidOperationException("The physical runtime module reader is already constructed.");
            if (PhysicalIO.CompiledSourceDeployment != null)
            {
                // The factory already published original source facts before constructing the compiled game.
                // A compiled deployment has no physical CLR module/context owner to authenticate or dispose.
                _ = SourceMembers;
                _ = CanonicalSourceMethods;
                _ = ExternalBaseClosureFacts;
                return;
            }

            sourceRuntimeModuleMetadata = new SourceRuntimeModuleMetadata(RequireSourceRuntimeModulePath);
            if (sourceLegacyAssemblyMetadataRuntime == null && PhysicalIO.AssemblyMetadataRuntimeFactory != null)
                BindSourceLegacyAssemblyMetadataRuntime(
                    PhysicalIO.AssemblyMetadataRuntimeFactory
                        .CreateAssemblyMetadataRuntime(sourceRuntimeModuleMetadata));
            if (sourceLegacyAssemblyMetadataRuntime == null && SourceMonoDomainAssemblyMetadataRuntime.IsSupported)
                BindSourceLegacyAssemblyMetadataRuntime(
                    new SourceMonoDomainAssemblyMetadataRuntime(sourceRuntimeModuleMetadata));
            ActualGame.Disposed += DisposeSourceRuntimeModuleMetadata;
        }

        private void DisposeSourceRuntimeModuleMetadata(object sender, EventArgs args)
        {
            try
            {
                sourceRuntimeModuleMetadata.Dispose();
            }
            finally
            {
                DisposeSourceBootSdkAssemblyResolver();
            }
        }

        private string RequireSourceRuntimeModulePath(Module actualModule)
        {
            string path = actualModule.FullyQualifiedName;
            if (!string.IsNullOrEmpty(path) && Path.IsPathRooted(path) && File.Exists(path)) return path;
            if (ReferenceEquals(actualModule, actualModule.Assembly.ManifestModule))
            {
                path = actualModule.Assembly.Location;
                if (!string.IsNullOrEmpty(path) && Path.IsPathRooted(path) && File.Exists(path)) return path;
                if (PhysicalIO.HostRuntime is Celeste.Core.Framework.Startup.ISourcePhysicalModulePathIO
                        physicalModules &&
                    physicalModules.TryGetPhysicalModulePath(actualModule, out path))
                    return path;

                // A stream-loaded mod owns its actual physical cache PE on both Mono and CoreCLR.
                if (sourceAssemblyContexts != null &&
                    sourceAssemblyContexts.TryGetPhysicalModulePath(actualModule, out path)) return path;

                // Stream-loaded mod assemblies require a genuine CLR context owner and its real relinker cache.
                // Ordinary physical CLR modules never depend on AssemblyLoadContext support.
                if (sourceLegacyAssemblyMetadataRuntime is SourceMonoDomainAssemblyMetadataRuntime)
                    throw new NotSupportedException(
                        "The actual Mono module has no physical file and no CLR module-context cache.");
                var metadata = LegacyAssemblyMetadataRuntime.GetContextModuleMetadata(actualModule.Assembly);
                if (metadata != null)
                    return ((SourceEverestAssemblyRelinker)AssemblyContexts.Relinker)
                        .GetCachedPath(metadata, actualModule.Assembly.GetName().Name);
            }

            throw new NotSupportedException(
                "The actual CLR module has no qualified physical PE file or genuine module-context cache.");
        }
    }
}
