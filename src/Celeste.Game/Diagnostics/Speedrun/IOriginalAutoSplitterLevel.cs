using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Diagnostics.Speedrun
{
    public interface IOriginalAutoSplitterLevel
    {
        ChapterCompletionSession AutoSplitterSession { get; }
        bool AutoSplitterCompleted { get; }
    }
}
