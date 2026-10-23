using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Player.Death;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerDeathStatisticsScene
    {
        void ISourcePlayerDeathStatisticsScene.RegisterPlayerDeath(ChapterCompletionSession capturedSession)
        {
            ((IOriginalGameplayProcess)EngineContext).SaveContext.AddDeath(
                new(capturedSession.AreaID, capturedSession.Mode));
        }
    }
}
