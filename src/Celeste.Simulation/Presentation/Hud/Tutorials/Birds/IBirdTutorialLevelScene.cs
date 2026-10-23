using System.Numerics;

namespace Celeste.Simulation.Presentation.Hud.Tutorials.Birds
{
    public interface IBirdTutorialLevelScene
    {
        bool FrozenOrPaused { get; }
        object RetryPlayerCorpse { get; }
        Vector2 CameraPosition { get; }
    }
}
