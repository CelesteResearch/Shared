using System.Numerics;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public interface ISourcePlayerDreamDashScene
    {
        DisplacementBurst AddDreamDashBurst(Vector2 position);
    }
}
