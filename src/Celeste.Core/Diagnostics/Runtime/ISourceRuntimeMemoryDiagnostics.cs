namespace Celeste.Core.Diagnostics.Runtime
{
    public interface ISourceRuntimeMemoryDiagnostics
    {
        SourceRuntimeMemoryAvailability Availability { get; }
        SourceRuntimeGcMemorySnapshot? ReadMemoryInfo();
    }
}
