using System.Reflection;

namespace Celeste.Core.Framework.Startup
{
    // Identifies actual non-source frames. A host boundary terminates Everest's
    // hook-owner scan; a qualified physical creator keeps its precise frame scope.
    public interface ISourceExternalFrameAssemblyIdentity
    {
        bool TryGetExternalFrameAssemblyIdentity(MethodBase actualMethod,
            out string assemblyIdentity, out bool stopAtHostBoundary);
    }
}
