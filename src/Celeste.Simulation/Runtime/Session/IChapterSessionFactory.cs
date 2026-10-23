using Celeste.Simulation.Save.Progress;

namespace Celeste.Simulation.Runtime.Session
{
    public interface IChapterSessionFactory
    {
        int GetMaxArea();
        bool AllowFlagChange(ChapterCompletionSession session, string flag, bool setTo);

        ChapterCompletionSession Restart(ChapterCompletionSession actualSession, string checkpoint,
            ChapterAreaProgress oldStats);
    }
}
