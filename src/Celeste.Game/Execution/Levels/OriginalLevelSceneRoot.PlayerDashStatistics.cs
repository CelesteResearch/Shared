using Celeste.Simulation.Gameplay.Player.Statistics;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerDashStatisticsScene
    {
        void ISourcePlayerDashStatisticsScene.RegisterPlayerDash()
        {
            Session.Dashes++;
        }
    }
}
