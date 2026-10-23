using Celeste.Simulation.Gameplay.Environment.Space;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceSpaceScene
    {
        bool ISourceSpaceScene.InSpace => InSpace;
    }
}
