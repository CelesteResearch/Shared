using Celeste.Simulation.Runtime.Session;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public interface ISourcePlayerDeathStatisticsScene
    {
        void RegisterPlayerDeath(ChapterCompletionSession capturedSession);
    }
}
