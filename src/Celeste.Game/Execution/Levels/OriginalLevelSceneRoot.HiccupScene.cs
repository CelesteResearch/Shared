using Celeste.Core.Randomness;
using Celeste.Simulation.Gameplay.Player.Scene;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot :
        ISourceHiccupScene
    {
        ISourceRandom
            ISourceHiccupScene.
            HiccupRandom =>
            HiccupRandom;
    }
}
