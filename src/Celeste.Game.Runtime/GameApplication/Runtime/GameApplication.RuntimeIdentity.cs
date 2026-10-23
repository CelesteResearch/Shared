using Celeste.Core.Diagnostics.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceRuntimeIdentityDiagnosticsEnvironment
    {
        public ISourceRuntimeIdentityDiagnostics RuntimeIdentityDiagnostics => PhysicalIO.RuntimeDiagnostics;
    }
}
