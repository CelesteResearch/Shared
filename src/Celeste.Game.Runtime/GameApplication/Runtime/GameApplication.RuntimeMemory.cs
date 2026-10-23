using Celeste.Core.Diagnostics.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceRuntimeMemoryDiagnosticsEnvironment,
        ISourceRuntimeMemoryCapacityEnvironment
    {
        public ISourceRuntimeMemoryDiagnostics RuntimeMemoryDiagnostics => PhysicalIO.RuntimeMemoryDiagnostics;
        public ISourceRuntimeMemoryCapacity RuntimeMemoryCapacity => PhysicalIO.RuntimeDiagnostics;
    }
}
