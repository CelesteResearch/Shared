using Celeste.Game.Diagnostics.Speedrun;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IOriginalAutoSplitterLevel
    {
        ChapterCompletionSession IOriginalAutoSplitterLevel.AutoSplitterSession => Session;
        bool IOriginalAutoSplitterLevel.AutoSplitterCompleted => Completed;
    }
}
