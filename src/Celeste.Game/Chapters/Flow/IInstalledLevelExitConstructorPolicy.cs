using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public interface IInstalledLevelExitConstructorPolicy
    {
        void BeforeConstructor(ChapterCompletionSession session);

        void AfterConstructor(LevelExitSequence exit, LevelExitMode mode,
            ChapterCompletionSession session, HiresSnowState snow);
    }
}
