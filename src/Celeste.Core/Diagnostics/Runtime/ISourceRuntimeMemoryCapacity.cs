namespace Celeste.Core.Diagnostics.Runtime
{
    /// <summary>The runtime's process memory capacity, independent of managed heap diagnostics.</summary>
    public interface ISourceRuntimeMemoryCapacity
    {
        long ReadTotalAvailableMemoryBytes();
    }
}
