using Celeste.Core.Scheduling;

namespace Celeste.Game.Chapters.Flow
{
    public interface IOriginalLevelExitCompletionPolicy
    {
        void PlayMusic(LevelExitSequence exit);
        void Load(LevelExitSequence exit);
        ISourceSceneExecution CreateAreaComplete(LevelExitSequence exit);
    }
}
