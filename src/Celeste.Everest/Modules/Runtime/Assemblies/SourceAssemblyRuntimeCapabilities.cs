namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public sealed class SourceAssemblyRuntimeCapabilities
    {
        public bool SupportsAssemblyIsolation { get; }
        public bool SupportsAssemblyUnloading { get; }
        public bool SupportsModuleNativeResolution { get; }

        public SourceAssemblyRuntimeCapabilities(bool isolated, bool unloadable, bool nativeResolution)
        {
            SupportsAssemblyIsolation = isolated;
            SupportsAssemblyUnloading = unloadable;
            SupportsModuleNativeResolution = nativeResolution;
        }
    }
}
