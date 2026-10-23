using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels
{
    public interface IOriginalLevelLoadSourceHooksEnvironment
    {
        void AfterSourceLevelLoad(OriginalLevelSceneRoot actualLevel, PlayerIntroType playerIntro, bool isFromLoader);
    }
}
