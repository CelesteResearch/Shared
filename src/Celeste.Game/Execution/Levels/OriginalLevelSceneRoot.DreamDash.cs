using System.Numerics;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerDreamDashScene
    {
        DisplacementBurst ISourcePlayerDreamDashScene.AddDreamDashBurst(Vector2 position)
        {
            return Displacement.AddBurst(position, .3f, 0f, 40f);
        }
    }
}
