using System.Numerics;
using Celeste.Simulation.Gameplay.Environment.Wind;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceWindScene
    {
        Vector2 ISourceWindScene.Wind
        {
            get => Wind;
            set => Wind = value;
        }
    }
}
