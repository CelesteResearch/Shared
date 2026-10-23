using Celeste.Game.Chapters.Flow.Restarts;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Chapters.Flow.Restarts
{
    public sealed class EverestLevelRestartPolicy : IOriginalLevelRestartPolicy
    {
        public ChapterCompletionSession Restart(ChapterCompletionSession actualSession, string goldenEntryLevel,
            bool fromGolden)
        {
            var restarted = actualSession.Restart(fromGolden ? goldenEntryLevel : null);
            if (fromGolden) restarted.RestartedFromGolden = true;
            return restarted;
        }
    }
}
