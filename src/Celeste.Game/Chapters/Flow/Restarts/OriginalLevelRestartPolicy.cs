using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow.Restarts
{
    public sealed class OriginalLevelRestartPolicy : IOriginalLevelRestartPolicy
    {
        public ChapterCompletionSession Restart(ChapterCompletionSession actualSession, string goldenEntryLevel,
            bool fromGolden)
        {
            return actualSession.Restart(fromGolden ? goldenEntryLevel : null);
        }
    }
}
