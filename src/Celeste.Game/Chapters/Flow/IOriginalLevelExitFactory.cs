using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public interface IOriginalLevelExitFactory
    {
        LevelExitSequence CreateLevelExit(LevelExitMode mode, ChapterCompletionSession session,
            HiresSnowState snow = null);
    }
}
