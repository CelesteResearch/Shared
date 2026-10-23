using Celeste.Scene.Tagging;

namespace Celeste.Scene.Scheduling.ExecutionTags
{
    public interface ISourcePersistentTransitionExecutionTags
    {
        SourceBitTag Persistent { get; }
        SourceBitTag TransitionUpdate { get; }
    }
}
