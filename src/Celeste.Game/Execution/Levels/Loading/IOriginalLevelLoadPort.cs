using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels.Loading
{
    public interface IOriginalLevelLoadPort
    {
        // Source UnloadLevel has already committed the outgoing EntityList.
        // This publishes the native loader's real source entities into the same Level.
        void LoadLevel(PlayerIntroType intro, bool isFromLoader);
    }
}
