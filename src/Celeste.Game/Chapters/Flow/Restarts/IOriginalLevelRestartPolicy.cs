using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow.Restarts
{
    public interface IOriginalLevelRestartPolicy
    {
        ChapterCompletionSession Restart(ChapterCompletionSession actualSession, string goldenEntryLevel,
            bool fromGolden);
    }
}
