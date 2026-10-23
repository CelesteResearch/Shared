using Celeste.Simulation.Gameplay.Player.Runtime;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerAntiSoftlockLevel
    {
        string ISourcePlayerAntiSoftlockLevel.LevelSet =>
            AreaData.LevelSet;
    }
}
