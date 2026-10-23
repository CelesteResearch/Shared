using Celeste.Scene.Tagging;

namespace Celeste.Scene.Scheduling.ExecutionTags
{
    public interface ISourceGlobalFrozenExecutionTags
    {
        SourceBitTag Global { get; }
        SourceBitTag FrozenUpdate { get; }
    }
}
